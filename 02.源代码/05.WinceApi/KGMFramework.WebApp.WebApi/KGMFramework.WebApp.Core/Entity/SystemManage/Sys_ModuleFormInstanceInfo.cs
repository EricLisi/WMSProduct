using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using KGM.Framework.ControlUtil;

namespace KGMFramework.WebApp.Entity
{
    /// <summary>
    /// 模块表单实例
    /// </summary>
    [DataContract]
    public class Sys_ModuleFormInstanceInfo : AppBaseEntity
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
	    public Sys_ModuleFormInstanceInfo()
		{
            this.F_Id= System.Guid.NewGuid().ToString();
                this.F_SortCode= 0;
    
		}

        #region Property Members
        
        /// <summary>
        /// 表单实例主键
        /// </summary>
		[DataMember]
        public virtual string F_Id { get; set; }

        /// <summary>
        /// 表单主键
        /// </summary>
		[DataMember]
        public virtual string F_FormId { get; set; }

        /// <summary>
        /// 对象主键
        /// </summary>
		[DataMember]
        public virtual string F_ObjectId { get; set; }

        /// <summary>
        /// 表单实例Json
        /// </summary>
		[DataMember]
        public virtual string F_InstanceJson { get; set; }

        /// <summary>
        /// 排序码
        /// </summary>
		[DataMember]
        public virtual int? F_SortCode { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
		[DataMember]
        public virtual DateTime? F_CreatorTime { get; set; }

        /// <summary>
        /// 创建用户
        /// </summary>
		[DataMember]
        public virtual string F_CreatorUserId { get; set; }


        #endregion

    }
}