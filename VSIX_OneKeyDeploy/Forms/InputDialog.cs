﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VSIX_OneKeyDeploy.Forms
{
    public static class InputDialog
    {
        public static DialogResult Show(out string strText)
        {
            string strTemp = string.Empty;

            form_inputDialog inputDialog = new form_inputDialog();
            inputDialog.TextHandler = (str) => { strTemp = str; };

            DialogResult result = inputDialog.ShowDialog();
            strText = strTemp; 
            return result;
        }
    }
}
