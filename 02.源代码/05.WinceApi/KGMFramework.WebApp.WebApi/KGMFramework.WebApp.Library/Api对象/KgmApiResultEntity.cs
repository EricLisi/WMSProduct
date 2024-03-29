﻿using System.ComponentModel;
using System.Runtime.Serialization;

namespace KGMFramework.WebApp.Library
{
    /// <summary>
    /// API返回对象
    /// </summary>
    [DataContract]
    public class KgmApiResultEntity
    {
        /// <summary>
        /// 返回结果 true/false
        /// </summary>
        [DataMember]
        [DefaultValue(false)]
        public bool result { get; set; }

        /// <summary>
        /// 返回信息
        /// 当result为false是,返回错误信息
        /// 当result为true时,返回空或正确的信息
        /// </summary>
        [DataMember]
        public string message { get; set; }
    }
}
