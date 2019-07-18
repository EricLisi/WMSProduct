using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using KGM.Framework.ControlUtil;

namespace KGMFramework.WebApp.Entity
{
    /// <summary>
    /// 角色授权表
    /// </summary>
    [DataContract]
    public class Sys_RoleAuthorizeInfo : AppBaseEntity
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
	    public Sys_RoleAuthorizeInfo()
		{
            this.F_Id= System.Guid.NewGuid().ToString();
             this.F_ItemType= 0;
              this.F_ObjectType= 0;
              this.F_SortCode= 0;
    
		}

        #region Property Members
        
        /// <summary>
        /// 角色授权主键
        /// </summary>
		[DataMember]
        public virtual string F_Id { get; set; }

        /// <summary>
        /// 项目类型1-模块2-按钮3-列表
        /// </summary>
		[DataMember]
        public virtual int? F_ItemType { get; set; }

        /// <summary>
        /// 项目主键
        /// </summary>
		[DataMember]
        public virtual string F_ItemId { get; set; }

        /// <summary>
        /// 对象分类1-角色2-部门-3用户
        /// </summary>
		[DataMember]
        public virtual int? F_ObjectType { get; set; }

        /// <summary>
        /// 对象主键
        /// </summary>
		[DataMember]
        public virtual string F_ObjectId { get; set; }

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