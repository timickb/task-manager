using System.ComponentModel;

namespace TaskManagerGUI
{
    partial class InputDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.applyButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.textBox1.Location = new System.Drawing.Point(22, 25);
            this.textBox1.Margin = new System.Windows.Forms.Padding(22, 25, 22, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(483, 31);
            this.textBox1.TabIndex = 0;
            // 
            // applyButton
            // 
            this.applyButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.applyButton.Location = new System.Drawing.Point(537, 25);
            this.applyButton.Margin = new System.Windows.Forms.Padding(22, 25, 22, 25);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(83, 40);
            this.applyButton.TabIndex = 1;
            this.applyButton.Text = "OK";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += applyButton_Click;
            // 
            // InputDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 90);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.textBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(664, 146);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(664, 146);
            this.Name = "InputDialog";
            this.Padding = new System.Windows.Forms.Padding(22, 25, 22, 25);
            this.ShowIcon = false;
            this.Text = "InputDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button applyButton;

        private System.Windows.Forms.TextBox textBox1;

        #endregion
    }
}