﻿namespace VSIX_OneKeyDeploy.Forms
{
    partial class form_inputDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_checkCode = new System.Windows.Forms.TextBox();
            this.btn_checkCodeConfirm = new System.Windows.Forms.Button();
            this.btn_checkCodeCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "校验码";
            // 
            // txt_checkCode
            // 
            this.txt_checkCode.Location = new System.Drawing.Point(71, 12);
            this.txt_checkCode.Name = "txt_checkCode";
            this.txt_checkCode.Size = new System.Drawing.Size(100, 21);
            this.txt_checkCode.TabIndex = 1;
            this.txt_checkCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_checkCode_KeyPress);
            // 
            // btn_checkCodeConfirm
            // 
            this.btn_checkCodeConfirm.Location = new System.Drawing.Point(16, 51);
            this.btn_checkCodeConfirm.Name = "btn_checkCodeConfirm";
            this.btn_checkCodeConfirm.Size = new System.Drawing.Size(75, 23);
            this.btn_checkCodeConfirm.TabIndex = 2;
            this.btn_checkCodeConfirm.Text = "确认";
            this.btn_checkCodeConfirm.UseVisualStyleBackColor = true;
            this.btn_checkCodeConfirm.Click += new System.EventHandler(this.btn_checkCodeConfirm_Click);
            // 
            // btn_checkCodeCancel
            // 
            this.btn_checkCodeCancel.Location = new System.Drawing.Point(111, 51);
            this.btn_checkCodeCancel.Name = "btn_checkCodeCancel";
            this.btn_checkCodeCancel.Size = new System.Drawing.Size(75, 23);
            this.btn_checkCodeCancel.TabIndex = 3;
            this.btn_checkCodeCancel.Text = "取消";
            this.btn_checkCodeCancel.UseVisualStyleBackColor = true;
            this.btn_checkCodeCancel.Click += new System.EventHandler(this.btn_checkCodeCancel_Click);
            // 
            // inputDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(202, 85);
            this.Controls.Add(this.btn_checkCodeCancel);
            this.Controls.Add(this.btn_checkCodeConfirm);
            this.Controls.Add(this.txt_checkCode);
            this.Controls.Add(this.label1);
            this.Name = "inputDialog";
            this.Text = "输入校验码";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_checkCode;
        private System.Windows.Forms.Button btn_checkCodeConfirm;
        private System.Windows.Forms.Button btn_checkCodeCancel;
    }
}