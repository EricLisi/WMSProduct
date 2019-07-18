using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace KGMFramework.WebApp.Library
{
    /// <summary>
    /// 硬件帮助类
    /// </summary>
    public class HardwareHelper
    {
        /// <summary>
        /// 获取mac地址
        /// </summary>
        /// <returns></returns>
        public static string GetMacAddress()
        {
            //读取MAC地址
            string macAddress = null;
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                if ((bool)mo["IPEnabled"] == true)
                {
                    macAddress = mo["MacAddress"].ToString();
                    mo.Dispose();
                    break;
                }
            }

            return DESEncrypt.Encrypt(macAddress);
        }

    }
}
