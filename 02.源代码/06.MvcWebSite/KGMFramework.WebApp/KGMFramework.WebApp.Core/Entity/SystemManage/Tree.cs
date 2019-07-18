using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using KGM.Framework.ControlUtil;

namespace KGMFramework.WebApp.Entity
{

    public class GridColumnEntity
    {
        /// <summary>
        /// 列显示
        /// </summary>
        [DataMember]
        public string label { get; set; }

        /// <summary>
        /// 映射字段
        /// </summary>
        [DataMember]
        public string name { get; set; }

        /// <summary>
        /// 是否隐藏
        /// </summary>
        [DataMember]
        public bool? hidden { get; set; }

        /// <summary>
        /// 是否主键
        /// </summary>
        [DataMember]
        public bool? key { get; set; }

        /// <summary>
        /// 宽度
        /// </summary>
        [DataMember]
        public int width { get; set; }

        /// <summary>
        /// 对齐方式
        /// </summary>
        [DataMember]
        public string align { get; set; }

        /// <summary>
        /// 格式化函数
        /// </summary>
        [DataMember]
        public string formatter { get; set; }

        /// <summary>
        /// 格式化函数
        /// </summary>
        [DataMember]
        public string formatoptions { get; set; }
    }
}