using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using KgmSoft.DeviceFramework.Utility;
using KgmSoft.DeviceFrameworkControl.WinGui;

namespace KgmSoft.Scan.Project
{
    static class Program
    {
        [DllImport("coredll.Dll")]
        private static extern int ReleaseMutex(IntPtr hMutex);
        [DllImport("coredll.dll", EntryPoint = "CreateMutex", SetLastError = true)]
        public static extern IntPtr CreateMutex(IntPtr lpMutexAttributes, bool InitialOwner, string MutexName);
        const int ERROR_ALREADY_EXISTS = 0183;
        [DllImport("coredll.dll", EntryPoint = "FindWindowW", SetLastError = true)]
        public static extern IntPtr FindWindowCE(string lpClassName, string lpWindowName);
        [DllImport("coredll.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [MTAThread]
        static void Main()
        {
            try
            {
                string strAppName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
                IntPtr hMutex = CreateMutex(IntPtr.Zero, true, strAppName);
                if (Marshal.GetLastWin32Error() == ERROR_ALREADY_EXISTS)
                {
                    ReleaseMutex(hMutex);
                    //通过Class找到对应的窗口句柄  #NETCF_AGL_BASE_ 为窗口的ClassName
                    IntPtr mainWin = FindWindowCE("#NETCF_AGL_BASE_", null);
                    //SetForegroundWindow函数将创建指定的窗口，并激活到前台窗口的线程
                    bool result = SetForegroundWindow(mainWin);
                    return;
                }
                else
                {
                    string strTerminal = AppUtil.GetXmlNodeValue(QSConstValue.TERMINAL_NODE);
                    //终端类型检查
                    if (string.IsNullOrEmpty(strTerminal) || !KgmUtil.IsInt(strTerminal)
                        || !Enum.IsDefined(typeof(Terminal), int.Parse(strTerminal)))
                    {
                        AppUtil.ShowError("终端类型不正确，请检查配置文件！");
                        return;
                    }

                    FrmMain frm = new FrmMain();
                    frm.Text = "金戈马条码管理软件-" + AppUtil.GetXmlNodeValue(QSConstValue.SERIALNO_NODE); //QSConstValue.FORM_TITLE;
                    frm.Term = (Terminal)Enum.Parse(typeof(Terminal), strTerminal, true);
                    frm.ScaleDown(true);
                    frm.LoadFormType = typeof(FrmLogin);
                    Application.Run(frm);
                }
            }
            catch (Exception ex)
            {
                AppUtil.ShowError(ex.ToString());
            }
        }
    }
}