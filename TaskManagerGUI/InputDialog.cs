using System;
using System.Windows.Forms;

namespace TaskManagerGUI
{
    public partial class InputDialog : Form
    {
        public string Value { get; private set; }
        
        public InputDialog(string text)
        {
            InitializeComponent();
            this.Text = text;
        }

        public sealed override string Text
        {
            get => base.Text;
            set => base.Text = value;
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            Value = textBox1.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void applyButton_Click_1(object sender, EventArgs e)
        {

        }
    }
}