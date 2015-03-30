using System;
using System.Windows.Forms;

namespace Aws.ControlPanel
{
    public partial class InputBoxForm : Form
    {
        public string Caption
        {
            get { return lblCaption.Text; }
            set { lblCaption.Text = value; }
        }

        public string Input { get { return txtText.Text; } }

        public InputBoxForm(string caption)
        {
            InitializeComponent();
            Caption = caption;
            txtText.Focus();
        }

        private void InputBoxForm_Activated(object sender, EventArgs e)
        {
            txtText.Focus();
        }
    }
}