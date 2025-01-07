using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.Shell;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using VSIX_OneKeyDeploy.Helper;

namespace VSIX_OneKeyDeploy.Forms
{
    public partial class form_main : Form
    {
        string logpath = "/log";
        string workpath = "/";//插件的工作目录
        string SolutionPath = "/";//解决方案目录 用于添加配置文件的
        string servicename = "";

        public form_main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str_path = Directory.GetCurrentDirectory(); //获取应用程序的当前工作目录。 宿主目录的/bin/debug中C:\Users\Administrator\source\repos\VSIXProject1\VSIXProject1\bin\Debug
            txt_apppath.Text = str_path.Replace(@"\bin\Debug", "");
            workpath = txt_apppath.Text;
        }

        private void form_main_Load(object sender, EventArgs e)

        {

            #region 处理路径

            var dte2 = Package.GetGlobalService(typeof(DTE)) as DTE2;
            var solution = dte2.Solution;
            var projects = (UIHierarchyItem[])dte2?.ToolWindows.SolutionExplorer.SelectedItems;
            var project = projects[0].Object as Project;
            var SolutionName = Path.GetFileName(solution.FullName);//解决方案名称
            var SolutionDir = Path.GetDirectoryName(solution.FullName);//解决方案路径 D:\博思\代码\.Net Core新接口\WebApi4iflysse
            SolutionPath = SolutionDir;
            var ProjectName = Path.GetFileName(project.FullName);//项目名称 可以用来作为镜像名称 全文是 appindex31.csproj
            var ProjectDir = Path.GetDirectoryName(project.FullName);//项目路径 

            workpath = ProjectDir;
            txt_apppath.Text = workpath;

            SetExeLog(txt_exelog, $"工作目录={workpath}");
            #endregion

            #region 处理服务名称
            var serviceDesc = GetFileString(workpath + @"\服务说明.txt");
            if (string.IsNullOrEmpty(serviceDesc))
            {
                MessageBox.Show("没有有效的服务说明文件信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!serviceDesc.Contains("此服务在网关声明的名称是"))
            {
                MessageBox.Show("服务说明文件信息中没有服务名称！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var reg = new Regex(@"(?<=此服务在网关声明的名称是：)\w+");
            servicename = reg.Match(serviceDesc).Value.ToLower();
            if (string.IsNullOrEmpty(servicename))
            {
                MessageBox.Show("正则没有匹配到服务名称！参考写法【此服务在网关声明的名称是：appindex】!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txt_imagename.Text = servicename;
            #endregion

            #region  处理下拉框的数据

            initImageServerComboBox();//镜像服务器
            initRunningServerComboBox();//运行服务器

            #endregion
        }


        private void initImageServerComboBox()
        {
            try
            {
                var model = GetOneKeySettings(SolutionPath);
                var datasource = new List<Site>();
                if (model == null)
                {
                    MessageBox.Show("没有有效的配置文件，请转到配置Tab页配置！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                foreach (var item in model.imageServerInfo)
                {
                    datasource.Add(new Site { Text = item.imageServer + "/" + item.projectName, Value = item.projectName });
                }
                comboBox_imageServer.DisplayMember = "Text";
                comboBox_imageServer.ValueMember = "Value";
                comboBox_imageServer.DataSource = datasource;
            }
            catch (Exception ex)
            {
                MessageBox.Show("获取镜像服务器信息错误，请检查配置", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void initRunningServerComboBox()
        {
            try
            {
                var model = GetOneKeySettings(SolutionPath);
                var datasource = new List<Site>();
                if (model == null)
                {
                    MessageBox.Show("没有有效的配置文件，请转到配置Tab页配置！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                foreach (var item in model.runningServerInfo)
                {
                    datasource.Add(new Site { Text = item.ServerName, Value = item.ServerIP + ":" + item.AgentPort });
                }

                checkedListBox_runningserver.DataSource = datasource;
                checkedListBox_runningserver.DisplayMember = "Text";
                checkedListBox_runningserver.ValueMember = "Value";

            }
            catch (Exception ex)
            {
                MessageBox.Show("获取运行服务器信息错误，请检查配置", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_build_Click(object sender, EventArgs e)
        {
            dotnetRelease();
        }

        private void dotnetRelease()
        {
            SetExeLog(txt_exelog, "******************发布项目******************");
            SetProgressBar(progressBar_build, 5);
            var release_path = txt_apppath.Text.Trim();
            logpath = release_path;
            var res = ExeShell("dotnet", release_path, "publish -c Release --no-restore");
            //appindex31->D:\博思\代码\.Net Core新接口\WebApi4iflysse\appindex31\bin\Release\netcoreapp3.1\appindex31.dll
            //appindex31->D:\博思\代码\.Net Core新接口\WebApi4iflysse\appindex31\bin\Release\netcoreapp3.1\publish\
            //txt_releaseres.Text = "error=" + res.Item2 + "\r\n outmsg=" + res.Item1;
            if (!string.IsNullOrEmpty(res.Item2))
            {
                SetExeLog(txt_exelog, "******************执行发布命令时出现错误******************");
                MessageBox.Show("执行发布命令时出现错误msg=" + res.Item1, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // 分隔标准输出
            SetProgressBar(progressBar_build, 8);
            string[] arr = res.Item1.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            var laststr = arr[arr.Length - 2];//倒数第一行其实是空值
            if (string.IsNullOrEmpty(laststr) || !laststr.Contains("publish"))
            {

                SetExeLog(txt_exelog, "******************发布项目未出现意料中的结果，请手动检查日志******************");
                MessageBox.Show("执行发布命令并未出现意料中的结果，请手动检查日志！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Regex reg_release = new Regex(@"\D{1}:{1}.*\\?");
            var match = reg_release.Match(laststr).Value;
            if (string.IsNullOrEmpty(match))
            {
                SetExeLog(txt_exelog, "******************未能匹配到有效的发布后目,请手动填写******************");
                MessageBox.Show("未能匹配到有效的发布后目录，请手动填写", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SetExeLog(txt_releasepath, $"发布目录={match}");
            SetTextBox(txt_releasepath, match);
            SetProgressBar(progressBar_build, 12);
            SetExeLog(txt_exelog, "******************项目发布完成******************");
        }


        /// <summary>
        /// 执行命令
        /// </summary>
        /// <param name="FileName">命令前缀 例如sh  dotnet </param>
        /// <param name="path">执行命令的所在目录 例如 D:\site\appindex</param>
        /// <param name="sh">具体命令 例如 publish-c release</param>
        /// <returns>item1是标准输出 item2是错误输出</returns>
        private Tuple<string, string> ExeShell(string FileName, string path, string sh)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = FileName;
            process.StartInfo.WorkingDirectory = path;//20200928
            process.StartInfo.StandardErrorEncoding = Encoding.UTF8;
            process.StartInfo.UseShellExecute = false;//20200928
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.Arguments = sh;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;


            process.Start();

            var sm_error = process.StandardError;
            var sm_out = process.StandardOutput;
            //  process.WaitForExit();
            process.Close();

            var msgout = sm_out.ReadToEnd();
            var errorout = sm_error.ReadToEnd();// sm.ReadToEnd();     

            sm_error.Close();
            sm_out.Close();
            AddLgoToTXT(logpath, $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}执行命令log********\r\n" +
                $"error信息********\r\n{errorout}\r\n" +
                $"标准输出信息*******\r\n{msgout}");

            return new Tuple<string, string>(msgout, errorout);

        }

        private void btn_build_Click_1(object sender, EventArgs e)
        {



            System.Threading.Tasks.Task t = new System.Threading.Tasks.Task(OneKeyDeploy);
            t.Start();
            // OneKeyDeploy();
        }

        private void OneKeyDeploy()
        {
            var isDeploy = true;//是不是一键部署 如果不选runmode 那就是只推送镜像  如果选择了runmode 那就是一键部署
            #region 检测运行服务器和runmode

            if (!checkBox_runmode_dev.Checked && !checkBox_runmode_test.Checked && !checkBox_runmode_preview.Checked && !checkBox_runmode_online.Checked)
            {
                isDeploy = false;
                MessageBox.Show("您没有勾选RunMode,只会将镜像推送到服务器不会发布！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            #endregion

            #region 发布项目

            dotnetRelease();

            #endregion

            #region 处理镜像名
            SetProgressBar(progressBar_build, 15);

            SetExeLog(txt_exelog, "***********处理镜像和获取tag***********");

            if (txt_imagename.Text.Trim() == "")
            {
                SetExeLog(txt_exelog, "***********没有有效的镜像名称***********");
                MessageBox.Show("没有有效的镜像名称！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var imagename = txt_imagename.Text.Trim();
            //下拉框获取镜像库地址和项目名称
            var tagPrefix = "";
            var projectname = "";
            Invoke(new MethodInvoker(delegate ()
   {
       tagPrefix = comboBox_imageServer.Text.ToString();//形如 192.168.1.45:8080/netcore
       projectname = comboBox_imageServer.SelectedValue.ToString();
   }));
            SetProgressBar(progressBar_build, 18);
            if (string.IsNullOrEmpty(tagPrefix))
            {
                MessageBox.Show("没有有效的镜像服务器！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            SetTextBox(txt_build_projectname, projectname);
            var imageserver = tagPrefix.Replace($"/{projectname}", "");//把192.168.1.45:8080/netcore中的/netcore替换掉 就成了镜像服务器地址

            var tag = getANewTag(imageserver, projectname, imagename);

            SetTextBox(txt_tag, tag);
            //处理tag
            var imageFullName = tagPrefix + "/" + imagename + ":" + tag;
            imageFullName = imageFullName.ToLower();//必须小写
            SetProgressBar(progressBar_build, 20);
            #endregion

            #region build 镜像 和 推送


            SetExeLog(txt_exelog, "***********build镜像***********");
            SetProgressBar(progressBar_build, 30);
            var buildpath = txt_releasepath.Text.Trim();//发布完成后的路径 就是build的工作目录
            var res = ExeShell("docker", buildpath, $"build -t {imageFullName} .");
            SetProgressBar(progressBar_build, 60);
            var reg = new Regex($"{imageFullName} .* done");//20220617XLJ

            //#8 naming to 139.196.113.202:8080/netcore/bosisso:20230223001 0.1s done
            //#8 DONE 1.0s
            //if (reg.IsMatch(res.Item2))
            //if ((res.Item2).Contains($"{imageFullName} done")) //20230223更改 docker的中会打印DONE 0.1s这样
            if ((res.Item2).Contains($"DONE"))
            {

                SetExeLog(txt_exelog, "***********推送镜像***********");
                SetProgressBar(progressBar_build, 70);
                var pushres = ExeShell("docker", "", $"push {imageFullName}");

                if (!isDeploy)
                {
                    //只推送镜像  到此就是100
                    SetProgressBar(progressBar_build, 100);
                }

                if (pushres.Item1.Contains($"{tag}: digest"))
                {
                    SetExeLog(txt_exelog, "***********推送镜像成功***********");
                    //    MessageBox.Show("镜像推送成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

            }
            else
            {
                MessageBox.Show("镜像build失败，请检查docker中的镜像！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion


            #region 判断是不是全自动部署
            if (isDeploy)
            {
                //判断有没有勾选online环境  如果有 则需要提示数次校验码
                if (checkBox_runmode_online.Checked)
                {

                    string strText = string.Empty;
                    InputDialog.Show(out strText);
                    if (!strText.Equals("xlj666"))
                    {
                        MessageBox.Show("校验码不正确，请联系管理员！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                //处理之后的业务
                //拿到运行服务器

                var runningServer = new List<Site>();

                Invoke(new MethodInvoker(delegate ()
                {

                    foreach (Site item in checkedListBox_runningserver.CheckedItems)
                    {
                        //item就是选中的值
                        runningServer.Add(item);
                    }


                }));
                // GetFileString
                // 读取  docker-compose.yml 文件
                // 读取1.sh文件
                model4OneDeployRequest model_request = new model4OneDeployRequest();

                var dockerComposeString = GetFileString(workpath + @"\docker-compose.yml");
                //docker-compose.yml需要使用command: runmode=dev 来指定运行模式

                if (string.IsNullOrEmpty(dockerComposeString))
                {
                    MessageBox.Show("没有有效的docker-compose.yml文件信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //dockerComposeString 要处理build的问题 不让其build
                dockerComposeString = dockerComposeString.Replace("build: .", "");
                model_request.dockerComposeString = dockerComposeString;
                SetExeLog(txt_exelog, "***********处理runmode相关命令数据信息***********");

                #region dev数据处理
                if (checkBox_runmode_dev.Checked)
                {
                    model_request.runMode.Add("dev");
                    var dev_shString = GetFileString(workpath + @"\1.dev.sh");
                    if (string.IsNullOrEmpty(dev_shString))
                    {
                        MessageBox.Show("没有有效的sh脚本文件信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    //处理 sh中build问题  不让其build
                    dev_shString = dev_shString.Replace("--build", "");

                    model_request.shString.Add(dev_shString);
                }



                #endregion

                #region test数据处理
                if (checkBox_runmode_test.Checked)
                {
                    model_request.runMode.Add("test");
                    var test_shString = GetFileString(workpath + @"\1.test.sh");
                    if (string.IsNullOrEmpty(test_shString))
                    {
                        MessageBox.Show("没有有效的sh脚本文件信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    test_shString = test_shString.Replace("--build", "");
                    model_request.shString.Add(test_shString);
                }
                #endregion

                #region preview数据处理
                if (checkBox_runmode_preview.Checked)
                {
                    model_request.runMode.Add("preview");
                    var preview_shString = GetFileString(workpath + @"\1.preview.sh");
                    if (string.IsNullOrEmpty(preview_shString))
                    {
                        MessageBox.Show("没有有效的sh脚本文件信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    preview_shString = preview_shString.Replace("--build", "");
                    model_request.shString.Add(preview_shString);
                }
                #endregion

                #region online数据处理

                if (checkBox_runmode_online.Checked)
                {
                    model_request.runMode.Add("online");
                    var online_shString = GetFileString(workpath + @"\1.online.sh");
                    if (string.IsNullOrEmpty(online_shString))
                    {
                        MessageBox.Show("没有有效的sh脚本文件信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    online_shString = online_shString.Replace("--build", "");
                    model_request.shString.Add(online_shString);
                }
                #endregion
                SetProgressBar(progressBar_build, 80);
                model_request.imageName = imageFullName;


                model_request.serviceName = servicename;
                //此时进度是80  还差20 那么每次前进的距离就是  20/数量 +80
                int processVal = 0;
                foreach (var server in runningServer)
                {
                    processVal += (10 / runningServer.Count);
                    var url = server.Value + "/autoupdateapi/AutoUpdate/oneKeyDeploy";
                    SetExeLog(txt_exelog, $"***********发送请求到{server.Text}***********");
                    AddLgoToTXT(workpath, $"***********发送请求body={JsonConvert.SerializeObject(model_request)}***********");

                    var response = RequestHelper.HttpPost(url, model_request);

                    SetProgressBar(progressBar_build, processVal + 80);

                    if (response == null)
                    {
                        SetExeLog(txt_exelog, $"***********请求{server.Text}Agent发生错误***********");
                        return;
                    }

                    SetExeLog(txt_exelog, $"***********请求{server.Text}Agent返回值={JsonConvert.SerializeObject(response.Content)}***********");
                    if (response.Content.Contains("执行失败") && !response.Content.Contains("执行成功"))
                    {
                        SetExeLog(txt_exelog, $"***********发布到{server.Text}没有成功，请检查日志查找问题***********");
                        //MessageBox.Show("一键发布没有成功，请检查日志查找问题！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //return;
                    }
                    else if (response.Content.Contains("执行成功") && !response.Content.Contains("执行失败"))
                    {
                        SetExeLog(txt_exelog, $"***********发布到{server.Text}成功!***********");
                        //MessageBox.Show("一键发布成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //return;
                    }
                    else if (response.Content.Contains("执行成功") && response.Content.Contains("执行失败"))
                    {
                        SetExeLog(txt_exelog, $"***********发布到{server.Text}部分RunMode成功，部分失败!***********");
                        //MessageBox.Show("一键发布部分RunMode成功，部分失败！请检查日志。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //return;
                    }
                    else
                    {
                        SetExeLog(txt_exelog, $"***********请求{server.Text}Agent没有期望的返回值，请检查Agent日志***********");
                    }
                }

                SetProgressBar(progressBar_build, 100);
                MessageBox.Show("一键发布任务结束！请查看日志输出。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            #endregion
        }



        /// <summary>
        /// 跨线程的文本赋值
        /// </summary>
        /// <param name="txt"></param>
        /// <param name="str"></param>
        private void SetExeLog(TextBox txt, string str)
        {
            Invoke(new MethodInvoker(delegate ()
            {
                txt.Text += str + "logtime=" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n";


            }));
        }

        /// <summary>
        /// 跨线程设置文本
        /// </summary>
        /// <param name="txt"></param>
        /// <param name="str"></param>
        private void SetTextBox(TextBox txt, string str)
        {
            Invoke(new MethodInvoker(delegate ()
            {
                txt.Text = $"{str}";
            }));
        }

        /// <summary>
        /// 设置进度条
        /// </summary>
        /// <param name="pb"></param>
        /// <param name="val"></param>
        public void SetProgressBar(ProgressBar pb, int val)
        {
            Invoke(new MethodInvoker(delegate ()
            {
                pb.Value = val;

            }));

        }

        //简洁版
        public void AddLgoToTXT(string workpath, string logstring)
        {
            string path = workpath + @"\OneKeyDeploy.log";
            if (!System.IO.File.Exists(path))
            {
                FileStream stream = System.IO.File.Create(path);
                stream.Close();
                stream.Dispose();
            }
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(logstring);
            }
        }


        /// <summary>
        /// 获取指定镜像的最后一个tag
        /// </summary>
        /// <param name="imageserver">镜像服务器地址</param>
        /// <param name="projectname">项目名称</param>
        /// <param name="imagename">镜像名称</param>
        /// <returns></returns>
        private string getLastTag(string imageserver, string projectname, string imagename)
        {
            var lastTag = "";
            try
            {
                //http://139.196.113.202:8080/api/v2.0/projects/onlinecompile/repositories/compilecentos_online/artifacts?page=1&page_size=10&with_tag=true&with_label=false&with_scan_overview=false&with_signature=false&with_immutable_status=false
                var url = imageserver + $"/api/v2.0/projects/{projectname}/repositories/{imagename}/artifacts?page=1&page_size=1&with_tag=true&with_label=false&with_scan_overview=false&with_signature=false&with_immutable_status=false";//通过harbor获取镜像最后一次提交的信息
                if (!url.StartsWith("http") && !url.StartsWith("https"))
                {
                    url = "http://" + url;//没有协议头的  要增加协议  默认是http
                }
                var response = RequestHelper.HttpGetSimple(url);
                //返回的数据结构是这样的
                //                [
                //    {
                //                    "addition_links": {
                //                        "build_history": {
                //                            "absolute": false,
                //                "href": "/api/v2.0/projects/onlinecompile/repositories/compilecentos_online/artifacts/sha256:1a13eb373df07c3fce2d7ccc7cb9415167faaac190746f7a400fb8f9633c3e9e/additions/build_history"
                //                        }
                //                    },
                //        "digest": "sha256:1a13eb373df07c3fce2d7ccc7cb9415167faaac190746f7a400fb8f9633c3e9e",
                //        "extra_attrs": {
                //                        "architecture": "amd64",
                //            "author": null,
                //            "created": "2021-05-28T01:01:55.059673945Z",
                //            "os": "linux"
                //        },
                //        "id": 15,
                //        "labels": null,
                //        "manifest_media_type": "application/vnd.docker.distribution.manifest.v2+json",
                //        "media_type": "application/vnd.docker.container.image.v1+json",
                //        "project_id": 5,
                //        "pull_time": "2021-06-29T07:07:46.592Z",
                //        "push_time": "2021-05-28T01:02:17.404Z",
                //        "references": null,
                //        "repository_id": 4,
                //        "size": 3608931332,
                //        "tags": [
                //            {
                //                        "artifact_id": 15,
                //                "id": 17,
                //                "immutable": false,
                //                "name": "v11.0",
                //                "pull_time": "2021-06-28T00:58:07.804Z",
                //                "push_time": "2021-05-28T01:02:17.422Z",
                //                "repository_id": 4,
                //                "signed": false
                //            }
                //        ],
                //        "type": "IMAGE"
                //    }
                //]
                if (response.StatusCode == HttpStatusCode.OK)
                {

                    var jsonstr = response.Content;
                    var lstmodel = JsonConvert.DeserializeObject<List<model4Image>>(jsonstr);
                    if (lstmodel.Count > 0)
                    {
                        lastTag = lstmodel[0].tags[0].name;
                    }

                }
            }
            catch (Exception ex)
            {
                AddLgoToTXT(workpath, "获取镜像的tag发生了位置错误ex=" + ex);
            }

            return lastTag;
        }

        /// <summary>
        /// 获取一个最新的tag 用
        /// </summary>
        /// <param name="imageserver">镜像服务器地址</param>
        /// <param name="projectname">项目名称</param>
        /// <param name="imagename">镜像名称</param>
        /// <returns></returns>
        private string getANewTag(string imageserver, string projectname, string imagename)
        {

            var lastTag = getLastTag(imageserver, projectname, imagename);
            if (string.IsNullOrEmpty(lastTag))
            {
                return Convert.ToInt64(DateTime.Now.ToString("yyyyMMdd") + "001").ToString();
            }
            else
            {
                var tagDate = lastTag.Substring(0, 8);
                var nowDate = DateTime.Now.ToString("yyyyMMdd");
                if (tagDate == nowDate)
                {
                    //都是今天  那就+1处理
                    return (Convert.ToInt64(lastTag) + 1).ToString();
                }
                else
                {
                    return nowDate + "001";
                }
            }
        }



        /// <summary>
        /// 新增镜像服务器的新增按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_addimageserver_Click(object sender, EventArgs e)
        {
            try
            {
                //OneKeyDeploySettings.json

                var model_imageserver = new model4OneKeySettingsImageServer();
                model_imageserver.imageServer = txt_imageserver.Text.Trim();
                model_imageserver.projectName = txt_projectname.Text.Trim();
                if (string.IsNullOrEmpty(model_imageserver.imageServer) || string.IsNullOrEmpty(model_imageserver.projectName))
                {
                    MessageBox.Show("镜像服务器地址或项目名不能为空！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                AddSettings2Json_imageServer(SolutionPath, model_imageserver);
                MessageBox.Show("新增配置成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                initImageServerComboBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show("新增配置发生未知错误ex=" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        /// <summary>
        /// 写入一键部署的镜像服务器配置文件
        /// </summary>
        /// <param name="workpath"></param>
        /// <param name="logstring"></param>
        public void AddSettings2Json_imageServer(string workpath, model4OneKeySettingsImageServer model)
        {
            string path = workpath + @"\OneKeyDeploySettings.json";
            var lst = new List<model4OneKeySettingsImageServer>();
            var model_Settings = new model4OneKeySettings();
            if (!System.IO.File.Exists(path))
            {
                FileStream stream = System.IO.File.Create(path);
                stream.Close();
                stream.Dispose();
                model_Settings.imageServerInfo = new List<model4OneKeySettingsImageServer>();
                model_Settings.runningServerInfo = new List<model4OneKeySettingsRunningServer>();
            }
            else
            {
                //配置存在  读取原来的数据
                //读取数据
                StreamReader sr = new StreamReader(path, Encoding.UTF8);
                var jsonstr = sr.ReadToEnd();
                sr.Close();
                model_Settings = JsonConvert.DeserializeObject<model4OneKeySettings>(jsonstr);
                lst = model_Settings.imageServerInfo;//源数据赋值
            }
            lst.Add(model);//新增的配置
            model_Settings.imageServerInfo = lst;
            if (model_Settings.runningServerInfo == null)
            {
                model_Settings.runningServerInfo = new List<model4OneKeySettingsRunningServer>();
            }
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                writer.WriteLine(JsonConvert.SerializeObject(model_Settings));
            }
        }



        /// <summary>
        /// 写入一键部署的运行服务器配置文件
        /// </summary>
        /// <param name="workpath"></param>
        /// <param name="logstring"></param>
        public void AddSettings2Json_runningServer(string workpath, model4OneKeySettingsRunningServer model)
        {
            string path = workpath + @"\OneKeyDeploySettings.json";
            var lst = new List<model4OneKeySettingsRunningServer>();
            var model_Settings = new model4OneKeySettings();
            if (!System.IO.File.Exists(path))
            {
                FileStream stream = System.IO.File.Create(path);
                stream.Close();
                stream.Dispose();
                model_Settings.imageServerInfo = new List<model4OneKeySettingsImageServer>();
                model_Settings.runningServerInfo = new List<model4OneKeySettingsRunningServer>();
            }
            else
            {//配置存在  读取原来的数据
                //读取数据
                StreamReader sr = new StreamReader(path, Encoding.UTF8);
                var jsonstr = sr.ReadToEnd();
                sr.Close();
                model_Settings = JsonConvert.DeserializeObject<model4OneKeySettings>(jsonstr);
                lst = model_Settings.runningServerInfo;//源数据赋值
            }
            lst.Add(model);//新增的配置
            model_Settings.runningServerInfo = lst;
            if (model_Settings.imageServerInfo == null)
            {
                model_Settings.imageServerInfo = new List<model4OneKeySettingsImageServer>();
            }
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                writer.WriteLine(JsonConvert.SerializeObject(model_Settings));
            }
        }



        /// <summary>
        /// 获取并设置项目和解决方案绝对路径
        /// </summary>
        /// <returns></returns>
        protected void GetSetPath()
        {
            var dte2 = Package.GetGlobalService(typeof(DTE)) as DTE2;
            var solution = dte2.Solution;
            var projects = (UIHierarchyItem[])dte2?.ToolWindows.SolutionExplorer.SelectedItems;
            var project = projects[0].Object as Project;
            var SolutionName = Path.GetFileName(solution.FullName);//解决方案名称
            var SolutionDir = Path.GetDirectoryName(solution.FullName);//解决方案路径
            var ProjectName = Path.GetFileName(project.FullName);//项目名称
            var ProjectDir = Path.GetDirectoryName(project.FullName);//项目路径 
        }

        /// <summary>
        /// 读取配置
        /// </summary>
        /// <param name="workpath"></param>
        /// <returns></returns>
        public model4OneKeySettings GetOneKeySettings(string workpath)
        {
            try
            {

                string path = workpath + @"\OneKeyDeploySettings.json";
                var model = new model4OneKeySettings();
                if (!System.IO.File.Exists(path))
                {
                    return model;
                }
                else
                {
                    //读取数据
                    StreamReader sr = new StreamReader(path, Encoding.UTF8);
                    var jsonstr = sr.ReadToEnd();
                    sr.Close();
                    var tmp = JsonConvert.DeserializeObject<model4OneKeySettings>(jsonstr);
                    model = tmp;
                    return model;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("获取配置文件发生未知错误，请删除后重新配置！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        /// <summary>
        /// 读取文件内容
        /// </summary>
        /// <param name="workpath"></param>
        /// <returns></returns>
        public string GetFileString(string path)
        {
            try
            {
                // string path = workpath + @"\docker-compose.yml";
                var model = new model4OneKeySettings();
                if (!System.IO.File.Exists(path))
                {
                    return "";
                }
                else
                {
                    //读取数据
                    StreamReader sr = new StreamReader(path, Encoding.UTF8);
                    var str = sr.ReadToEnd();
                    sr.Close();
                    return str;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("获取文件内容发生未知错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }




        /// <summary>
        /// 一键部署的对象
        /// </summary>
        public class model4OneKeySettings
        {
            public List<model4OneKeySettingsImageServer> imageServerInfo { get; set; }


            public List<model4OneKeySettingsRunningServer> runningServerInfo { get; set; }

        }


        /// <summary>
        /// 一键部署的镜像服务器配置信息
        /// </summary>
        public class model4OneKeySettingsImageServer
        {
            /// <summary>
            /// 镜像服务器的地址  这里其实是要求harbor
            /// 形如192.168.1.7:8080
            /// 注意不能带上协议头
            /// </summary>
            public string imageServer { get; set; }
            /// <summary>
            /// 项目名称
            /// </summary>
            public string projectName { get; set; }


        }

        /// <summary>
        /// 一键部署的运行服务器配置信息
        /// </summary>
        public class model4OneKeySettingsRunningServer
        {
            /// <summary>
            /// 服务器的ip 需要带上协议头http这些
            /// </summary>
            public string ServerIP { get; set; }
            /// <summary>
            /// 自动发布向导的端口号
            /// </summary>
            public string AgentPort { get; set; }

            /// <summary>
            /// 服务别名
            /// </summary>

            public string ServerName { get; set; }

        }


        public class model4OneDeployRequest
        {
            /// <summary>
            /// 镜像名称
            /// </summary>
            public string imageName { get; set; }
            /// <summary>
            /// 命令文件
            /// </summary>
            public List<string> shString { get; set; } = new List<string>();

            /// <summary>
            /// 运行模式 请与shString顺序对应上
            /// </summary>
            public List<string> runMode { get; set; } = new List<string>();

            /// <summary>
            /// docker-compose文件
            /// </summary>
            public string dockerComposeString { get; set; }
            /// <summary>
            /// 服务名
            /// </summary>
            public string serviceName { get; set; }
        }

        /// <summary>
        /// 打开OneKeyDeploySettings.json的方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {

                string path = SolutionPath + @"\OneKeyDeploySettings.json";

                if (!System.IO.File.Exists(path))
                {
                    MessageBox.Show("配置文件不存在，请先新增配置", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {

                    StreamReader sr = new StreamReader(path, Encoding.UTF8);
                    var jsonstr = sr.ReadToEnd();
                    sr.Close();
                    MessageBox.Show($"{jsonstr}", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("读取配置发生未知错误ex=" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public class Site
        {
            public string Value { get; set; }
            public string Text { get; set; }
            public string Identifier { get; set; }
        }

        public class model4Image
        {
            public List<model4Tags> tags { get; set; }

        }
        public class model4Tags
        {
            // {
            //                        "artifact_id": 15,
            //                "id": 17,
            //                "immutable": false,
            //                "name": "v11.0",
            public string name { get; set; }
            //                "pull_time": "2021-06-28T00:58:07.804Z",
            //                "push_time": "2021-05-28T01:02:17.422Z",
            public DateTime push_time { get; set; }
            //                "repository_id": 4,
            //                "signed": false
            //            }

        }

        private void comboBox_imageServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_build_projectname.Text = comboBox_imageServer.SelectedValue.ToString();
        }

        private void btn_runningserver_add_Click(object sender, EventArgs e)
        {
            try
            {
                //OneKeyDeploySettings.json

                var model_runningserver = new model4OneKeySettingsRunningServer();
                model_runningserver.ServerIP = txt_runningserver_add.Text.Trim();

                var res = new Regex(@"https?");//检测是否含有http或者https
                if (!res.IsMatch(model_runningserver.ServerIP))
                {

                    model_runningserver.ServerIP = "http://" + model_runningserver.ServerIP;//没有匹配到  就默认http
                }

                model_runningserver.AgentPort = txt_runningserverport_add.Text.Trim();
                model_runningserver.ServerName = txt_runningServerName_add.Text.Trim();
                if (string.IsNullOrEmpty(model_runningserver.ServerIP) || string.IsNullOrEmpty(model_runningserver.AgentPort) || string.IsNullOrEmpty(model_runningserver.AgentPort))
                {
                    MessageBox.Show("运行服务器ip、端口、别名不能为空！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                AddSettings2Json_runningServer(SolutionPath, model_runningserver);
                MessageBox.Show("新增配置成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                initRunningServerComboBox();

            }
            catch (Exception ex)
            {
                MessageBox.Show("新增配置发生未知错误ex=" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }



}
