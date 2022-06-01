
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
            this.SuspendLayout();
            // 
            // rtx_Source
            // 
            this.rtx_Source.Location = new System.Drawing.Point(12, 35);
            this.rtx_Source.Name = "rtx_Source";
            this.rtx_Source.Size = new System.Drawing.Size(346, 690);
            this.rtx_Source.TabIndex = 1;
            this.rtx_Source.Text = "";
            // 
            // rtx_Target
            // 
            this.rtx_Target.Location = new System.Drawing.Point(364, 35);
            this.rtx_Target.Name = "rtx_Target";
            this.rtx_Target.Size = new System.Drawing.Size(344, 690);
            this.rtx_Target.TabIndex = 2;
            this.rtx_Target.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(283, 756);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(714, 35);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.richTextBox1.Size = new System.Drawing.Size(769, 690);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            this.richTextBox1.WordWrap = false;
            // 
            // tb_Source
            // 
            this.tb_Source.Location = new System.Drawing.Point(78, 12);
            this.tb_Source.Name = "tb_Source";
            this.tb_Source.Size = new System.Drawing.Size(143, 20);
            this.tb_Source.TabIndex = 5;
            // 
            // tb_Target
            // 
            this.tb_Target.Location = new System.Drawing.Point(380, 12);
            this.tb_Target.Name = "tb_Target";
            this.tb_Target.Size = new System.Drawing.Size(157, 20);
            this.tb_Target.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1495, 791);
            this.Controls.Add(this.tb_Target);
            this.Controls.Add(this.tb_Source);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.rtx_Target);
            this.Controls.Add(this.rtx_Source);
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
    }
}

