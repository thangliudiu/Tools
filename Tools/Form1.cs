using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Tools
{
    public partial class Form1 : Form
    {
        private readonly string path;
        private readonly string filePath;
        private readonly DataModel data;
        private readonly List<int> diff;
        public Form1()
        {
            InitializeComponent();

            path = AppDomain.CurrentDomain.BaseDirectory;

            filePath = Path.Combine(path, "data.json");

            data = new DataModel();

            diff = new List<int>();

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

            richTextBox1.Font = new Font("Times New Roman", 12);
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
                richTextBox1.Text = "Difference \n";
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

                ShowDifference(string.Empty, sourceProperty, obj1, obj2);

                ChangeColor(richTextBox1, "Source:", Color.Green);
                ChangeColor(richTextBox1, "Target:", Color.Blue);
                ChangeColor(richTextBox1, "Difference", Color.Red);
                //ChangeColor(richTextBox1, "Warring:", Color.Orange);
                ChangeColor(richTextBox1, "Miss From Source: ", Color.Blue);

                ShowChangeText(richTextBox1, diff, Color.LightGray);
            }

            data.EnviromentSource = tb_Source.Text;
            data.EnviromentTarget = tb_Target.Text;
            data.Source = rtx_Source.Text;
            data.Target = rtx_Target.Text;

            File.WriteAllText(filePath, JsonConvert.SerializeObject(data));
        }

        public static void ShowChangeText(RichTextBox box, List<int> diffs, Color color)
        {
            foreach (var index in diffs)
            {
                box.SelectionStart = index;

                box.SelectionLength = 1;

                box.SelectionBackColor = color;
            }
        }

        public static void ChangeColor(RichTextBox box, string text, Color color)
        {
            var groups = Regex.Matches(box.Text, text, RegexOptions.IgnoreCase);

            foreach (Match item in groups)
            {
                box.SelectionStart = item.Index;

                box.SelectionLength = item.Length;

                box.SelectionColor = color;
            }
        }

        private void ShowDifference(string prefix, string sourceProperty, object obj1, object obj2)
        {
            var _text1 = JsonConvert.SerializeObject(obj1, Formatting.Indented);
            var _text2 = JsonConvert.SerializeObject(obj2, Formatting.Indented);

            var _text1Compare = _text1.ToLower().Replace(tb_Source.Text.ToLower(), "").Replace("api2.relationshop.net", "api.relationshop.net");
            var _text2Compare = _text2.ToLower().Replace(tb_Target.Text.ToLower(), "").Replace("api2.relationshop.net", "api.relationshop.net");

            if (_text1Compare != _text2Compare)
            {
                if (IsObject(obj1) && IsObject(obj2))
                {
                    var source = JsonConvert.DeserializeObject<Dictionary<string, object>>(_text1);
                    var target = JsonConvert.DeserializeObject<Dictionary<string, object>>(_text2);

                    string difference = $"Difference: {prefix.ToUpper()} {sourceProperty.ToUpper()}\n";

                    bool isDifference = false;

                    foreach (var subSourceProperty in source.Keys)
                    {
                        if (target.ContainsKey(subSourceProperty)) continue;

                        isDifference = true;

                        difference += $"Miss From Source: {subSourceProperty}\n";
                    }
                    if (isDifference)
                    {
                        richTextBox1.Text += difference + "\n";
                    }

                    foreach (var subSourceProperty in source.Keys)
                    {
                        source.TryGetValue(subSourceProperty, out object subObj1);
                        target.TryGetValue(subSourceProperty, out object subObj2);

                        var _prefix = prefix != string.Empty ? prefix + "." : "";
                        ShowDifference(_prefix + sourceProperty, subSourceProperty, subObj1, subObj2);
                    }
                }
                else
                {
                    richTextBox1.Text += $"Warring: {prefix}.{sourceProperty}\n";

                    string prefixSource = "Source: ";
                    string prefixTarget = "Target:  ";

                    int index1 = richTextBox1.Text.Length + prefixSource.Length;

                    richTextBox1.Text += $"{prefixSource}{_text1}\n";

                    int index2 = richTextBox1.Text.Length + prefixTarget.Length;

                    richTextBox1.Text += $"{prefixTarget}{_text2}\n";
                    richTextBox1.Text += "\n";

                    if (_text1.Length == _text2.Length)
                    {
                        for (int i = 0; i < _text1.Length; i++)
                        {
                            char letter1 = _text1[i];
                            char letter2 = _text2[i];

                            if (letter1 == letter2) continue;

                            diff.Add(index1 + i);
                            diff.Add(index2 + i);
                        }
                    }
                    else
                    {

                        if (prefix == "ServicesBusSetting")
                        {
                            int a = 0;
                        }
                        var List1 = _text1.Split(new char[] { ',', ';' }).Select((value1, index) => new { value1, index }).ToList();
                        var List2 = _text2.Split(new char[] { ',', ';' }).Select((value2, index) => new { value2, index }).ToList();

                        var leftdifference = from word1 in List1
                                             from word2 in List2.Where(word2 => word1.index == word2.index).DefaultIfEmpty()
                                             where word2 == null || word1.value1 != word2.value2
                                             select new { word1, word2 };

                        //Right outer join
                        var rightdifference = from word2 in List2
                                              from word1 in List1.Where(word1 => word1.index == word2.index).DefaultIfEmpty()
                                              where word1 == null || word1.value1 != word2.value2
                                              select new { word1, word2 };

                        var fulldifference = leftdifference.Union(rightdifference).ToList();

                        foreach (var item in fulldifference)
                        {
                            if (item.word1 != null)
                            {
                                int _index = 0;
                                for (int i = 0; i < List1.Count() && i < item.word1.index; i++)
                                {
                                    _index += List1[i].value1?.Length ?? 0;
                                }

                                for (int i = 0; i < item.word1.value1?.Length; i++)
                                {
                                    diff.Add(index1 + _index + i);
                                }
                            }

                            if (item.word2 != null)
                            {
                                int _index = 0;
                                for (int i = 0; i < List2.Count() && i < item.word2.index; i++)
                                {
                                    _index += List2[i].value2?.Length ?? 0;
                                }

                                for (int i = 0; i < item.word2.value2?.Length; i++)
                                {
                                    diff.Add(index2 + _index + i);
                                }
                            }
                            break;
                        }

                    }
                }
            }
        }

        public static bool IsObject(object obj)
        {
            if (obj is null) return false;

            if (obj is int) return false;

            if (obj is string) return false;

            Type type = obj.GetType();

            return !type.IsPrimitive && type.Name != "JArray";
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
