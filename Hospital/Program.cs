using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Models;
using System.Diagnostics;

namespace Hospital
{

   public  static class Program
    {
      //  public static string conn;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {

            //只允许一个客户端运行
            Process current = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(current.ProcessName);
            foreach (Process process in processes)
            {
                if (process.Id != current.Id)
                {
                    if (process.MainModule.FileName
                    == current.MainModule.FileName)
                    {
                        MessageBox.Show("程序已经运行！", Application.ProductName,
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            PatientInfo.conn = Application.StartupPath;
            Application.Run(new FrmMain());
          
        }
    }
}
