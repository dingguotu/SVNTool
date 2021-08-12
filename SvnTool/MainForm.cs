using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace SvnTool
{
    public partial class MainForm : Form
    {
        private static string _svnRoot = string.Empty;
        private static string _rootDir = string.Empty;
        private List<LogFormat> _logFormats = new List<LogFormat>();

        private static string[] _ignoreFile = Util.GetConfig("IgnoreFile").Split(';').Where(s => !string.IsNullOrEmpty(s)).ToArray();
        private static string[] _ignoreFolder = Util.GetConfig("IgnoreFolder").Split(';').Where(s => !string.IsNullOrEmpty(s)).ToArray();

        public MainForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void urlBtn_Click(object sender, EventArgs e)
        {
            if (urlFBD.ShowDialog() == DialogResult.OK)
            {
                urlTextBox.Text = urlFBD.SelectedPath;
                _rootDir = urlFBD.SelectedPath;
            }
        }

        private void logBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_rootDir))
            {
                MessageBox.Show("请输入正确的项目地址");
                return;
            }

            // 检查SVNLog文件夹是否存在，不存在创建
            var logPath = $@"{Application.StartupPath}\SVNLog";
            if (!Directory.Exists(logPath))
            {
                Directory.CreateDirectory(logPath);
            }

            LoadingHelper.ShowLoadingScreen();
            // 下载svn log文件
            string fileName = $"{_rootDir.Split('\\').ToList().LastOrDefault()}.log";
            string logResult = DownloadLogFile(logPath, fileName);
            if (logResult.Contains("E200007"))
            {
                LoadingHelper.CloseForm();
                MessageBox.Show("请输入正确的项目地址");
                return;
            }

            // 读取log文件并转为Log对象
            GetLog(logPath, fileName, out Log log);
            if (log == null)
            {
                LoadingHelper.CloseForm();
                MessageBox.Show("未知错误");
                return;
            }

            // 获取SVN根目录，用来替换文件目录
            GetSvnRoot();
            // 格式化Log对象，并计算修改行数
            GetLogFormats(log);

            logDataGrid.DataSource = _logFormats;
            var authors = _logFormats.Select(x => x.author).Distinct().OrderByDescending(a=>a).ToList();
            authors.Add("");
            authors.Reverse();
            authorCMB.DataSource = authors;
            LoadingHelper.CloseForm();
        }

        /// <summary>
        /// 下载Log文件
        /// </summary>
        /// <param name="logPath"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private string DownloadLogFile(string logPath, string fileName)
        {
            var startTime = startDTP.Value.ToString("yyyy-MM-dd");
            var endTime = endDTP.Value.AddDays(1).ToString("yyyy-MM-dd");
            var cmd = $"svn log -v --xml -r {{\"{startTime}\"}}:{{\"{endTime}\"}} {_rootDir} > {logPath}\\{fileName}";
            return Util.ExecCMD(cmd);
        }

        /// <summary>
        /// 将XML格式的Log文件读取为对象
        /// </summary>
        /// <param name="logPath"></param>
        /// <param name="fileName"></param>
        /// <param name="log"></param>
        private void GetLog(string logPath, string fileName, out Log log)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Log));
                using (TextReader reader = new StringReader(File.ReadAllText($"{logPath}\\{fileName}")))
                {
                    log = (Log)serializer.Deserialize(reader);
                }
            }
            catch (Exception)
            {
                log = null;
            }
        }

        /// <summary>
        /// 将Log对象转为格式化数组
        /// </summary>
        /// <param name="log"></param>
        /// <returns></returns>
        private void GetLogFormats(Log log)
        {
            // 初始化数组
            _logFormats = new List<LogFormat>();

            var logentrys = log.Logentry.Where(x => x.Date.Value >= startDTP.Value.Date && x.Date.Value < endDTP.Value.AddDays(1).Date).ToList();
            foreach (var logentry in logentrys)
            {
                int revision = logentry.ReVision;
                string author = logentry.Author.Value;
                DateTime checkDate = logentry.Date.Value;

                List<Path> paths = logentry.Paths.Path.Where(x => 
                                                        x.Kind == "file" &&
                                                        !IsIgnoreFile(x.Value) 
                                                        ).ToList();

                foreach (var path in paths)
                {
                    GetLineDiff(path.Value, revision, out int appendLines, out int removeLines);
                    if (appendLines == 0 && removeLines == 0)
                    {
                        continue;
                    }

                    var logFormat = new LogFormat();
                    logFormat.author = author;
                    logFormat.fileName = path.Value;
                    logFormat.appendLines = appendLines;
                    logFormat.removeLines = removeLines;
                    logFormat.totalLines = appendLines - removeLines;
                    logFormat.checkTime = checkDate.ToLocalTime();
                    _logFormats.Add(logFormat);
                }
            }
        }

        /// <summary>
        /// 排除不需要计算的文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private bool IsIgnoreFile(string filePath)
        {
            filePath = filePath.ToLower();
            foreach (var ignoreFile in _ignoreFile)
            {
                if (filePath.EndsWith(ignoreFile.ToLower()))
                    return true;
            }

            foreach (var ignoreFfolder in _ignoreFolder)
            {
                if (filePath.Contains(ignoreFfolder.ToLower()))
                    return true;
            }

            return filePath.Contains("bin/") ||
                   filePath.Contains("obj/") ||
                   filePath.Contains("AutoConfigs/") ||
                   filePath.EndsWith(".cache") ||
                   filePath.EndsWith(".csproj") ||
                   filePath.EndsWith(".sln") ||
                   filePath.EndsWith(".txt") ||
                   filePath.EndsWith(".md") ||
                   filePath.EndsWith(".xlsx") ||
                   filePath.EndsWith(".xls") ||
                   filePath.EndsWith(".doc") ||
                   filePath.EndsWith(".docs") ||
                   filePath.EndsWith(".pdf") ||
                   filePath.EndsWith(".jpg") ||
                   filePath.EndsWith(".jpge") ||
                   filePath.EndsWith(".png") ||
                   filePath.EndsWith(".ico");
        }

        /// <summary>
        /// 计算单个文件单次提交中的修改行数
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="revision"></param>
        /// <param name="appendLines"></param>
        /// <param name="removeLines"></param>
        private void GetLineDiff(string fileName, int revision, out int appendLines, out int removeLines)
        {
            appendLines = 0;
            removeLines = 0;

            string diffBuffer = CallSvnDiff(fileName, revision);
            var lines = diffBuffer.Split(new string[] { "\r\n" }, StringSplitOptions.None).ToList();

            foreach (var line in lines)
            {
                if (line.StartsWith("+ "))
                {
                    appendLines++;
                }
                if (line.StartsWith("- "))
                {
                    removeLines++;
                }
            }
        }

        /// <summary>
        /// 调用svn diff操作，返回diff结果
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="revision"></param>
        /// <returns></returns>
        private string CallSvnDiff(string fileName, int revision)
        {
            fileName = fileName.Substring(fileName.IndexOf(_svnRoot) + _svnRoot.Length);
            if (!fileName.StartsWith("/"))
            {
                fileName = "/" + fileName;
            }

            var cmd = $"svn diff --old {_rootDir}{fileName}@{revision - 1} --new {_rootDir}{fileName}@{revision}";
            var fileDiff = Util.ExecCMD(cmd);
            return fileDiff;
        }

        /// <summary>
        /// 获取svn根目录
        /// </summary>
        /// <returns></returns>
        private void GetSvnRoot()
        {
            var cmd = $"svn info --xml {_rootDir}";
            var info = Util.ExecCMD(cmd);
            XmlDocument infoXML = new XmlDocument();
            infoXML.LoadXml(info);
            var root = infoXML.SelectSingleNode("info/entry/relative-url").InnerXml;
            _svnRoot = HttpUtility.UrlDecode(root).Substring(1);
        }

        private void authorCMB_SelectedValueChanged(object sender, EventArgs e)
        {
            var value = authorCMB.SelectedValue.ToString();
            if (string.IsNullOrWhiteSpace(value))
            {
                logDataGrid.DataSource = _logFormats;
                appendBox.Text = "";
                removeBox.Text = "";
                totalBox.Text = "";
            }
            else {
                var logFormats = _logFormats.Where(x => x.author == value).ToList();
                logDataGrid.DataSource = logFormats;
                appendBox.Text = logFormats.Sum(x => x.appendLines).ToString();
                removeBox.Text = logFormats.Sum(x => x.removeLines).ToString();
                totalBox.Text = logFormats.Sum(x => x.totalLines).ToString();
            }
        }
    }
}
