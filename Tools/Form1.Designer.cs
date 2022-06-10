
namespace Tools
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rtx_Source = new System.Windows.Forms.RichTextBox();
            this.rtx_Target = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tb_Source = new System.Windows.Forms.TextBox();
            this.tb_Target = new System.Windows.Forms.TextBox();
            this.btn_Switch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtx_Source
            // 
            this.rtx_Source.Location = new System.Drawing.Point(16, 43);
            this.rtx_Source.Margin = new System.Windows.Forms.Padding(4);
            this.rtx_Source.Name = "rtx_Source";
            this.rtx_Source.Size = new System.Drawing.Size(460, 883);
            this.rtx_Source.TabIndex = 1;
            this.rtx_Source.Text = "";
            // 
            // rtx_Target
            // 
            this.rtx_Target.Location = new System.Drawing.Point(485, 43);
            this.rtx_Target.Margin = new System.Windows.Forms.Padding(4);
            this.rtx_Target.Name = "rtx_Target";
            this.rtx_Target.Size = new System.Drawing.Size(457, 883);
            this.rtx_Target.TabIndex = 2;
            this.rtx_Target.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(459, 12);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(952, 43);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.richTextBox1.Size = new System.Drawing.Size(1451, 883);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            this.richTextBox1.WordWrap = false;
            // 
            // tb_Source
            // 
            this.tb_Source.Location = new System.Drawing.Point(104, 15);
            this.tb_Source.Margin = new System.Windows.Forms.Padding(4);
            this.tb_Source.Name = "tb_Source";
            this.tb_Source.Size = new System.Drawing.Size(189, 22);
            this.tb_Source.TabIndex = 5;
            // 
            // tb_Target
            // 
            this.tb_Target.Location = new System.Drawing.Point(585, 15);
            this.tb_Target.Margin = new System.Windows.Forms.Padding(4);
            this.tb_Target.Name = "tb_Target";
            this.tb_Target.Size = new System.Drawing.Size(208, 22);
            this.tb_Target.TabIndex = 6;
            // 
            // btn_Switch
            // 
            this.btn_Switch.Location = new System.Drawing.Point(377, 13);
            this.btn_Switch.Name = "btn_Switch";
            this.btn_Switch.Size = new System.Drawing.Size(75, 23);
            this.btn_Switch.TabIndex = 7;
            this.btn_Switch.Text = "switch";
            this.btn_Switch.UseVisualStyleBackColor = true;
            this.btn_Switch.Click += new System.EventHandler(this.btn_Switch_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1924, 974);
            this.Controls.Add(this.btn_Switch);
            this.Controls.Add(this.tb_Target);
            this.Controls.Add(this.tb_Source);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.rtx_Target);
            this.Controls.Add(this.rtx_Source);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtx_Source;
        private System.Windows.Forms.RichTextBox rtx_Target;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox tb_Source;
        private System.Windows.Forms.TextBox tb_Target;
        private System.Windows.Forms.Button btn_Switch;
    }
}

