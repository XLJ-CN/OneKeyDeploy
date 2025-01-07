namespace VSIX_OneKeyDeploy.Forms
{
    partial class form_main
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
            this.btn_getpath = new System.Windows.Forms.Button();
            this.txt_apppath = new System.Windows.Forms.TextBox();
            this.btn_release = new System.Windows.Forms.Button();
            this.txt_releasepath = new System.Windows.Forms.TextBox();
            this.btn_build = new System.Windows.Forms.Button();
            this.txt_imagename = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_release = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txt_exelog = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkedListBox_runningserver = new System.Windows.Forms.CheckedListBox();
            this.checkBox_runmode_online = new System.Windows.Forms.CheckBox();
            this.checkBox_runmode_preview = new System.Windows.Forms.CheckBox();
            this.checkBox_runmode_test = new System.Windows.Forms.CheckBox();
            this.checkBox_runmode_dev = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.progressBar_build = new System.Windows.Forms.ProgressBar();
            this.txt_build_projectname = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox_imageServer = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_tag = new System.Windows.Forms.TextBox();
            this.tabPage_settings = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txt_runningServerName_add = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_runningserver_add = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btn_runningserver_add = new System.Windows.Forms.Button();
            this.txt_runningserverport_add = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txt_imageserver = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_addimageserver = new System.Windows.Forms.Button();
            this.txt_projectname = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage_release.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage_settings.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_getpath
            // 
            this.btn_getpath.Location = new System.Drawing.Point(6, 20);
            this.btn_getpath.Name = "btn_getpath";
            this.btn_getpath.Size = new System.Drawing.Size(124, 23);
            this.btn_getpath.TabIndex = 0;
            this.btn_getpath.Text = "获取项目位置";
            this.btn_getpath.UseVisualStyleBackColor = true;
            this.btn_getpath.Visible = false;
            this.btn_getpath.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_apppath
            // 
            this.txt_apppath.Location = new System.Drawing.Point(140, 22);
            this.txt_apppath.Name = "txt_apppath";
            this.txt_apppath.Size = new System.Drawing.Size(637, 21);
            this.txt_apppath.TabIndex = 1;
            this.txt_apppath.Visible = false;
            // 
            // btn_release
            // 
            this.btn_release.Location = new System.Drawing.Point(6, 51);
            this.btn_release.Name = "btn_release";
            this.btn_release.Size = new System.Drawing.Size(124, 23);
            this.btn_release.TabIndex = 2;
            this.btn_release.Text = "手动发布项目";
            this.btn_release.UseVisualStyleBackColor = true;
            this.btn_release.Visible = false;
            this.btn_release.Click += new System.EventHandler(this.btn_build_Click);
            // 
            // txt_releasepath
            // 
            this.txt_releasepath.Location = new System.Drawing.Point(140, 51);
            this.txt_releasepath.Name = "txt_releasepath";
            this.txt_releasepath.Size = new System.Drawing.Size(637, 21);
            this.txt_releasepath.TabIndex = 3;
            this.txt_releasepath.Visible = false;
            // 
            // btn_build
            // 
            this.btn_build.Location = new System.Drawing.Point(645, 46);
            this.btn_build.Name = "btn_build";
            this.btn_build.Size = new System.Drawing.Size(123, 23);
            this.btn_build.TabIndex = 4;
            this.btn_build.Text = "发布 build push";
            this.btn_build.UseVisualStyleBackColor = true;
            this.btn_build.Click += new System.EventHandler(this.btn_build_Click_1);
            // 
            // txt_imagename
            // 
            this.txt_imagename.Location = new System.Drawing.Point(74, 47);
            this.txt_imagename.Name = "txt_imagename";
            this.txt_imagename.ReadOnly = true;
            this.txt_imagename.Size = new System.Drawing.Size(286, 21);
            this.txt_imagename.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "镜像名称";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_release);
            this.tabControl1.Controls.Add(this.tabPage_settings);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 611);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage_release
            // 
            this.tabPage_release.Controls.Add(this.groupBox3);
            this.tabPage_release.Controls.Add(this.groupBox2);
            this.tabPage_release.Controls.Add(this.groupBox1);
            this.tabPage_release.Location = new System.Drawing.Point(4, 22);
            this.tabPage_release.Name = "tabPage_release";
            this.tabPage_release.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_release.Size = new System.Drawing.Size(792, 585);
            this.tabPage_release.TabIndex = 0;
            this.tabPage_release.Text = "发布";
            this.tabPage_release.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txt_exelog);
            this.groupBox3.Location = new System.Drawing.Point(6, 287);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(785, 290);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "执行日志";
            // 
            // txt_exelog
            // 
            this.txt_exelog.Location = new System.Drawing.Point(6, 20);
            this.txt_exelog.Multiline = true;
            this.txt_exelog.Name = "txt_exelog";
            this.txt_exelog.Size = new System.Drawing.Size(773, 264);
            this.txt_exelog.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkedListBox_runningserver);
            this.groupBox2.Controls.Add(this.checkBox_runmode_online);
            this.groupBox2.Controls.Add(this.checkBox_runmode_preview);
            this.groupBox2.Controls.Add(this.checkBox_runmode_test);
            this.groupBox2.Controls.Add(this.checkBox_runmode_dev);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.btn_getpath);
            this.groupBox2.Controls.Add(this.txt_releasepath);
            this.groupBox2.Controls.Add(this.btn_release);
            this.groupBox2.Controls.Add(this.txt_apppath);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(783, 161);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "基础信息配置";
            // 
            // checkedListBox_runningserver
            // 
            this.checkedListBox_runningserver.FormattingEnabled = true;
            this.checkedListBox_runningserver.Location = new System.Drawing.Point(77, 19);
            this.checkedListBox_runningserver.Name = "checkedListBox_runningserver";
            this.checkedListBox_runningserver.Size = new System.Drawing.Size(330, 132);
            this.checkedListBox_runningserver.TabIndex = 16;
            // 
            // checkBox_runmode_online
            // 
            this.checkBox_runmode_online.AutoSize = true;
            this.checkBox_runmode_online.Location = new System.Drawing.Point(670, 19);
            this.checkBox_runmode_online.Name = "checkBox_runmode_online";
            this.checkBox_runmode_online.Size = new System.Drawing.Size(60, 16);
            this.checkBox_runmode_online.TabIndex = 15;
            this.checkBox_runmode_online.Text = "online";
            this.checkBox_runmode_online.UseVisualStyleBackColor = true;
            // 
            // checkBox_runmode_preview
            // 
            this.checkBox_runmode_preview.AutoSize = true;
            this.checkBox_runmode_preview.Location = new System.Drawing.Point(598, 19);
            this.checkBox_runmode_preview.Name = "checkBox_runmode_preview";
            this.checkBox_runmode_preview.Size = new System.Drawing.Size(66, 16);
            this.checkBox_runmode_preview.TabIndex = 14;
            this.checkBox_runmode_preview.Text = "preview";
            this.checkBox_runmode_preview.UseVisualStyleBackColor = true;
            // 
            // checkBox_runmode_test
            // 
            this.checkBox_runmode_test.AutoSize = true;
            this.checkBox_runmode_test.Location = new System.Drawing.Point(544, 19);
            this.checkBox_runmode_test.Name = "checkBox_runmode_test";
            this.checkBox_runmode_test.Size = new System.Drawing.Size(48, 16);
            this.checkBox_runmode_test.TabIndex = 13;
            this.checkBox_runmode_test.Text = "test";
            this.checkBox_runmode_test.UseVisualStyleBackColor = true;
            // 
            // checkBox_runmode_dev
            // 
            this.checkBox_runmode_dev.AutoSize = true;
            this.checkBox_runmode_dev.Location = new System.Drawing.Point(496, 19);
            this.checkBox_runmode_dev.Name = "checkBox_runmode_dev";
            this.checkBox_runmode_dev.Size = new System.Drawing.Size(42, 16);
            this.checkBox_runmode_dev.TabIndex = 12;
            this.checkBox_runmode_dev.Text = "dev";
            this.checkBox_runmode_dev.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(413, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 11;
            this.label12.Text = "RunMode:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 7;
            this.label11.Text = "运行服务器";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.progressBar_build);
            this.groupBox1.Controls.Add(this.txt_build_projectname);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.comboBox_imageServer);
            this.groupBox1.Controls.Add(this.btn_build);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txt_imagename);
            this.groupBox1.Controls.Add(this.txt_tag);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 173);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(783, 108);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "镜像处理";
            // 
            // progressBar_build
            // 
            this.progressBar_build.Location = new System.Drawing.Point(8, 75);
            this.progressBar_build.Name = "progressBar_build";
            this.progressBar_build.Size = new System.Drawing.Size(760, 23);
            this.progressBar_build.TabIndex = 13;
            // 
            // txt_build_projectname
            // 
            this.txt_build_projectname.Location = new System.Drawing.Point(415, 17);
            this.txt_build_projectname.Name = "txt_build_projectname";
            this.txt_build_projectname.ReadOnly = true;
            this.txt_build_projectname.Size = new System.Drawing.Size(214, 21);
            this.txt_build_projectname.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(379, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 11;
            this.label7.Text = "项目";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "镜像服务器";
            // 
            // comboBox_imageServer
            // 
            this.comboBox_imageServer.FormattingEnabled = true;
            this.comboBox_imageServer.Location = new System.Drawing.Point(74, 17);
            this.comboBox_imageServer.Name = "comboBox_imageServer";
            this.comboBox_imageServer.Size = new System.Drawing.Size(286, 20);
            this.comboBox_imageServer.TabIndex = 9;
            this.comboBox_imageServer.SelectedIndexChanged += new System.EventHandler(this.comboBox_imageServer_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(386, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "Tag";
            // 
            // txt_tag
            // 
            this.txt_tag.Location = new System.Drawing.Point(415, 47);
            this.txt_tag.Name = "txt_tag";
            this.txt_tag.ReadOnly = true;
            this.txt_tag.Size = new System.Drawing.Size(214, 21);
            this.txt_tag.TabIndex = 7;
            // 
            // tabPage_settings
            // 
            this.tabPage_settings.Controls.Add(this.groupBox5);
            this.tabPage_settings.Controls.Add(this.groupBox4);
            this.tabPage_settings.Location = new System.Drawing.Point(4, 22);
            this.tabPage_settings.Name = "tabPage_settings";
            this.tabPage_settings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_settings.Size = new System.Drawing.Size(792, 651);
            this.tabPage_settings.TabIndex = 1;
            this.tabPage_settings.Text = "配置";
            this.tabPage_settings.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txt_runningServerName_add);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.txt_runningserver_add);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.btn_runningserver_add);
            this.groupBox5.Controls.Add(this.txt_runningserverport_add);
            this.groupBox5.Location = new System.Drawing.Point(8, 114);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(776, 71);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "运行服务器配置";
            // 
            // txt_runningServerName_add
            // 
            this.txt_runningServerName_add.Location = new System.Drawing.Point(552, 20);
            this.txt_runningServerName_add.Name = "txt_runningServerName_add";
            this.txt_runningServerName_add.Size = new System.Drawing.Size(138, 21);
            this.txt_runningServerName_add.TabIndex = 12;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(517, 25);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 12);
            this.label13.TabIndex = 11;
            this.label13.Text = "别名";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(359, 12);
            this.label10.TabIndex = 10;
            this.label10.Text = "运行服务器需要填写http头，通常一台服务器只会运行两种runmode";
            // 
            // txt_runningserver_add
            // 
            this.txt_runningserver_add.Location = new System.Drawing.Point(86, 20);
            this.txt_runningserver_add.Name = "txt_runningserver_add";
            this.txt_runningserver_add.Size = new System.Drawing.Size(208, 21);
            this.txt_runningserver_add.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 5;
            this.label8.Text = "运行服务器ip";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(299, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 12);
            this.label9.TabIndex = 7;
            this.label9.Text = "Agent端口号";
            // 
            // btn_runningserver_add
            // 
            this.btn_runningserver_add.Location = new System.Drawing.Point(695, 19);
            this.btn_runningserver_add.Name = "btn_runningserver_add";
            this.btn_runningserver_add.Size = new System.Drawing.Size(75, 23);
            this.btn_runningserver_add.TabIndex = 9;
            this.btn_runningserver_add.Text = "新增";
            this.btn_runningserver_add.UseVisualStyleBackColor = true;
            this.btn_runningserver_add.Click += new System.EventHandler(this.btn_runningserver_add_Click);
            // 
            // txt_runningserverport_add
            // 
            this.txt_runningserverport_add.Location = new System.Drawing.Point(372, 20);
            this.txt_runningserverport_add.Name = "txt_runningserverport_add";
            this.txt_runningserverport_add.Size = new System.Drawing.Size(138, 21);
            this.txt_runningserverport_add.TabIndex = 8;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txt_imageserver);
            this.groupBox4.Controls.Add(this.linkLabel1);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.btn_addimageserver);
            this.groupBox4.Controls.Add(this.txt_projectname);
            this.groupBox4.Location = new System.Drawing.Point(8, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(776, 102);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "镜像服务器配置";
            // 
            // txt_imageserver
            // 
            this.txt_imageserver.Location = new System.Drawing.Point(145, 24);
            this.txt_imageserver.Name = "txt_imageserver";
            this.txt_imageserver.Size = new System.Drawing.Size(221, 21);
            this.txt_imageserver.TabIndex = 1;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(151, 67);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(119, 12);
            this.linkLabel1.TabIndex = 6;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "OneKeySettings.json";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(74, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "镜像服务器";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(76, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(401, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "已有的配置在                    文件中(镜像服务器不需要填写http头)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(372, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "项目名";
            // 
            // btn_addimageserver
            // 
            this.btn_addimageserver.Location = new System.Drawing.Point(572, 24);
            this.btn_addimageserver.Name = "btn_addimageserver";
            this.btn_addimageserver.Size = new System.Drawing.Size(75, 23);
            this.btn_addimageserver.TabIndex = 4;
            this.btn_addimageserver.Text = "新增";
            this.btn_addimageserver.UseVisualStyleBackColor = true;
            this.btn_addimageserver.Click += new System.EventHandler(this.btn_addimageserver_Click);
            // 
            // txt_projectname
            // 
            this.txt_projectname.Location = new System.Drawing.Point(419, 24);
            this.txt_projectname.Name = "txt_projectname";
            this.txt_projectname.Size = new System.Drawing.Size(138, 21);
            this.txt_projectname.TabIndex = 3;
            // 
            // form_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 611);
            this.Controls.Add(this.tabControl1);
            this.Name = "form_main";
            this.Text = "一键部署主窗体";
            this.Load += new System.EventHandler(this.form_main_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage_release.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage_settings.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_getpath;
        private System.Windows.Forms.TextBox txt_apppath;
        private System.Windows.Forms.Button btn_release;
        private System.Windows.Forms.TextBox txt_releasepath;
        private System.Windows.Forms.Button btn_build;
        private System.Windows.Forms.TextBox txt_imagename;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_release;
        private System.Windows.Forms.TabPage tabPage_settings;
        private System.Windows.Forms.TextBox txt_projectname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_imageserver;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_addimageserver;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_tag;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox_imageServer;
        private System.Windows.Forms.TextBox txt_build_projectname;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ProgressBar progressBar_build;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txt_exelog;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_runningserver_add;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btn_runningserver_add;
        private System.Windows.Forms.TextBox txt_runningserverport_add;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox checkBox_runmode_online;
        private System.Windows.Forms.CheckBox checkBox_runmode_preview;
        private System.Windows.Forms.CheckBox checkBox_runmode_test;
        private System.Windows.Forms.CheckBox checkBox_runmode_dev;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_runningServerName_add;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckedListBox checkedListBox_runningserver;
    }
}