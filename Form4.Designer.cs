using System.Windows.Forms;
using System;

namespace NoAutoRestartsWin10
{
    partial class Form4
    {

        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            Program.ForceExit();
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(466, 262);
            this.label1.TabIndex = 0;
            this.label1.Text = resources.GetString("label1.Text");
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;

            this.button1.Location = new System.Drawing.Point(208, 240);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Continue";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(button1_clicked);

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 275);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "Form4";
            this.Text = "[ADMINISTRATOR] NoAutoRestartsWin10 - (Build 001 by Kilovice)";
            this.ResumeLayout(false);

        }

        private void button1_clicked(object sender, EventArgs e)
        {
            this.Hide();
            Program.RegistryCreateIfNotExist();
        }

        #endregion

        private Label label1;
        private Button button1;
    }
}