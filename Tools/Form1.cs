using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tools
{
    public partial class Form1 : Form
    {
        private readonly string path;
        private readonly string filePath;
        private DataModel data;

        public Form1()
        {
            InitializeComponent();

            path = AppDomain.CurrentDomain.BaseDirectory;

            filePath = Path.Combine(path, "data.json");

            if (File.Exists(filePath))
            {
                data = JsonConvert.DeserializeObject<DataModel>(File.ReadAllText(filePath));

                if (data != null)
                {
                    tb_Source.Text = data.EnviromentSource;
                    tb_Target.Text = data.EnviromentTarget;
                    rtx_Source.Text = data.Source;
                    rtx_Target.Text = data.Target;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            var text1 = rtx_Source.Text;
            var text2 = rtx_Target.Text;

            var source = JsonConvert.DeserializeObject<Dictionary<string, object>>(text1);
            var target = JsonConvert.DeserializeObject<Dictionary<string, object>>(text2);

            if (source.Count != target.Count)
            {
                richTextBox1.Text = "difference \n";
            }

            foreach (var sourceProperty in source.Keys)
            {
                if (target.ContainsKey(sourceProperty)) continue;

                richTextBox1.Text += $"Miss From Source: {sourceProperty}\n";
            }

            if (!string.IsNullOrEmpty(richTextBox1.Text)) richTextBox1.Text += "\n\n";

            foreach (var sourceProperty in source.Keys)
            {
                if (data.IgnoreProperties.Contains(sourceProperty)) continue;

                if (!target.ContainsKey(sourceProperty)) continue;

                source.TryGetValue(sourceProperty, out object obj1);
                target.TryGetValue(sourceProperty, out object obj2);

                var _text1 = JsonConvert.SerializeObject(obj1);
                var _text2 = JsonConvert.SerializeObject(obj2);

                if ((_text1.ToLower().Replace(tb_Source.Text.ToLower(), "")) != (_text2.ToLower().Replace(tb_Target.Text.ToLower(), "")))
                {
                    richTextBox1.Text += $"Warring: {sourceProperty}\n";

                    richTextBox1.Text += $"Source: {_text1}\n";
                    richTextBox1.Text += $"Target:  {_text2}\n";

                    richTextBox1.Text += "\n";
                }
            }

            data.EnviromentSource = tb_Source.Text;
            data.EnviromentTarget = tb_Target.Text;
            data.Source = rtx_Source.Text;
            data.Target = rtx_Target.Text;

            File.WriteAllText(filePath, JsonConvert.SerializeObject(data));
        }

        public class DataModel
        {
            public List<string> IgnoreProperties { get; set; } = new List<string>();
            public string EnviromentSource { get; set; }
            public string EnviromentTarget { get; set; }
            public string Target { get; set; }
            public string Source { get; set; }
        }
    }
}
