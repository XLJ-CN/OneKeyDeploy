using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VSIX_OneKeyDeploy.Forms
{
    public partial class form_inputDialog : Form
    {
        public delegate void TextEventHandler(string strText);

        public TextEventHandler TextHandler;
        public form_inputDialog()
        {
            InitializeComponent();

        }

        private void btn_checkCodeConfirm_Click(object sender, EventArgs e)
        {
            if (null != TextHandler)
            {
                TextHandler.Invoke(txt_checkCode.Text);
                DialogResult = DialogResult.OK;
            }
        }

        private void btn_checkCodeCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void txt_checkCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Keys.Enter == (Keys)e.KeyChar)
            {
                if (null != TextHandler)
                {
                    TextHandler.Invoke(txt_checkCode.Text);
                    DialogResult = DialogResult.OK;
                }
            }
        }
    }
}
