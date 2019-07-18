using System;
using System.Collections.Generic; 
using System.Text;

namespace KgmSoft.Scan.Project
{
    /// <summary>
    /// API返回对象
    /// </summary> 
    public class KgmApiResultEntity
    {
        /// <summary>
        /// 返回结果 true/false
        /// </summary> 
        public bool result { get; set; }

        /// <summary>
        /// 返回信息
        /// 当result为false是,返回错误信息
        /// 当result为true时,返回空或正确的信息
        /// </summary> 
        public string message { get; set; }
    }
}
