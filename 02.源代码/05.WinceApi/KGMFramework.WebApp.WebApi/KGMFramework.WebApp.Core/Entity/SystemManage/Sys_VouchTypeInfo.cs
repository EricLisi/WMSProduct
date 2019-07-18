using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using KGM.Framework.ControlUtil;

namespace KGMFramework.WebApp.Entity
{
    /// <summary>
    /// 业务类型
    /// </summary>
    [DataContract]
    public class Sys_VouchTypeInfo : AppBaseEntity
    {
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public Sys_VouchTypeInfo()
        {
            this.F_Id = System.Guid.NewGuid().ToString();//主键
            this.F_Layers = 0;//层级
            this.F_InoutType = 0;//出入库类型
            this.F_DeleteMark = false;//删除标志
            this.F_SortCode = 0;//排序号
            this.F_EnabledMark = false;//有效标志
            this.F_BrbFlag = false;//是否红字
            this.F_IsNeedDverfy= false;//是否审核
            this.F_IsAllMatch= false;//是否完全匹配
            this.F_IsFiFo= false;//先进先出
            this.F_Bprint= false;//是否打印
            this.F_Bdefalut = false;//是否默认来源

           

        }

        #region Property Members


        /// <summary>
        /// 层次
        /// </summary>
        [DataMember]
        public virtual int F_Layers { get; set; }
     

        /// <summary>
        /// 业务类型前缀
        /// </summary>
        [DataMember]
        public virtual string F_Prefix { get; set; }

        /// <summary>
        /// 模块ID
        /// </summary>
        [DataMember]
        public virtual string F_ModuleId { get; set; }

        /// <summary>
        /// 出入库类型
        /// </summary>
        [DataMember]
        public virtual int F_InoutType { get; set; }

        /// <summary>
        /// 来源类型
        /// </summary>
        [DataMember]
        public virtual string F_Source { get; set; }

        /// <summary>
        /// 来源库
        /// </summary>
        [DataMember]
        public virtual string F_SourceDb { get; set; }

        /// <summary>
        /// 来源表
        /// </summary>
        [DataMember]
        public virtual string F_SourceTable { get; set; }

        /// <summary>
        /// 来源业务类型
        /// </summary>
        [DataMember]
        public virtual string F_SourceBusiness { get; set; }
        /// <summary>
        /// 红字
        /// </summary>
        [DataMember]
        public virtual bool F_BrbFlag { get; set; }
        /// <summary>
        /// 审核
        /// </summary>
        [DataMember]
        public virtual bool F_IsNeedDverfy { get; set; }
        /// <summary>
        /// 完全匹配
        /// </summary>
        [DataMember]
        public virtual bool F_IsAllMatch { get; set; }
        /// <summary>
        /// 先进先出
        /// </summary>
        [DataMember]
        public virtual bool F_IsFiFo { get; set; }
        /// <summary>
        /// 是否打印
        /// </summary>
        [DataMember]
        public virtual bool F_Bprint { get; set; }
        /// <summary>
        /// 默认来源
        /// </summary>
        [DataMember]
        public virtual bool F_Bdefalut { get; set; }
        #endregion

    }
}