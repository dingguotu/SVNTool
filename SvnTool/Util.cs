using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SvnTool
{
    public static class Util
    {
        /// <summary>
        /// 执行CMD命令，并返回结果
        /// </summary>
        /// <param name="command">命令</param>
        /// <returns></returns>
        public static string ExecCMD(string command)
        {
            Process pro = new Process();
            pro.StartInfo.FileName = "cmd.exe";
            pro.StartInfo.UseShellExecute = false;
            pro.StartInfo.RedirectStandardError = true;
            pro.StartInfo.RedirectStandardInput = true;
            pro.StartInfo.RedirectStandardOutput = true;
            pro.StartInfo.CreateNoWindow = true;
            pro.Start();
            pro.StandardInput.AutoFlush = true;
            pro.StandardInput.WriteLine("@echo off");
            pro.StandardInput.WriteLine(command + " & exit");
            //获取cmd窗口的输出信息
            string output = pro.StandardOutput.ReadToEnd();
            pro.WaitForExit();//等待程序执行完退出进程
            pro.Close();
            return output.Substring(output.IndexOf("& exit") + 8);
        }

        public static string GetConfig(string key)
        {
            return ConfigurationManager.AppSettings.Get(key);
        }
    }
}
