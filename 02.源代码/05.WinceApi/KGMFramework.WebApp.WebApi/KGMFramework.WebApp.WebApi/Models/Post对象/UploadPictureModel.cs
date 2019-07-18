using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace KGMFramework.WebApp.WebApi.Models
{
    /// <summary>
    /// 上传文件对象
    /// </summary>
    [DataContract]
    public class UploadPictureModel
    {
        /// <summary>
        /// 资产表id
        /// </summary>
        [DataMember]
        public string id { get; set; }

        /// <summary>
        /// 条码
        /// </summary>
        [DataMember]
        public string barcode { get; set; }

        /// <summary>
        /// 图片集合
        /// </summary>
        [DataMember]
        public List<string> imgs { get; set; }
    }
}