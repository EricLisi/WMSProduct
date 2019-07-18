using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using KGM.Framework.ControlUtil;

namespace KGMFramework.WebApp.Entity
{
    /// <summary>
    /// 行政区域表
    /// </summary>
    [DataContract]
    public class TreeInfoEntity
    {
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public TreeInfoEntity()
        {

        }

        #region Property Members
        /// <summary>
        /// 表名
        /// </summary>
        [DataMember]
        public virtual string F_TableName { get; set; }

        /// <summary>
        /// KEY字段
        /// </summary>
        [DataMember]
        public virtual string F_KeyFiled { get; set; }

        /// <summary>
        /// 父节点字段
        /// </summary>
        [DataMember]
        public virtual string F_ParentFiled { get; set; }

        /// <summary>
        /// 过滤条件
        /// </summary>
        [DataMember]
        public virtual string F_Condition { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
        [DataMember]
        public virtual string F_SortCode { get; set; }

        /// <summary>
        /// 类别 0 父找子 1 子找父 2 不寻找直接全部查询
        /// </summary>
        [DataMember]
        public virtual int? F_CType { get; set; }
        #endregion

    }
}