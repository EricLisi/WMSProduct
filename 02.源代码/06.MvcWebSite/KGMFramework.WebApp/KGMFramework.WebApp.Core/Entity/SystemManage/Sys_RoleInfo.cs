using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using KGM.Framework.ControlUtil;

namespace KGMFramework.WebApp.Entity
{
    /// <summary>
    /// 角色表
    /// </summary>
    [DataContract]
    public class Sys_RoleInfo : AppBaseEntity
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
	    public Sys_RoleInfo()
		{
            this.F_Id= System.Guid.NewGuid().ToString();
              this.F_Category= 0;
                this.F_AllowEdit= false;
             this.F_AllowDelete= false;
             this.F_SortCode= 0;
             this.F_DeleteMark= false;
             this.F_EnabledMark= false;
         
		}

        #region Property Members
        
        /// <summary>
        /// 角色主键
        /// </summary>
		[DataMember]
        public virtual string F_Id { get; set; }

        /// <summary>
        /// 组织主键
        /// </summary>
		[DataMember]
        public virtual string F_OrganizeId { get; set; }

        /// <summary>
        /// 分类:1-角色2-岗位
        /// </summary>
		[DataMember]
        public virtual int? F_Category { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
		[DataMember]
        public virtual string F_EnCode { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
		[DataMember]
        public virtual string F_FullName { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
		[DataMember]
        public virtual string F_Type { get; set; }

        /// <summary>
        /// 允许编辑
        /// </summary>
		[DataMember]
        public virtual bool? F_AllowEdit { get; set; }

        /// <summary>
        /// 允许删除
        /// </summary>
		[DataMember]
        public virtual bool? F_AllowDelete { get; set; }

        /// <summary>
        /// 排序码
        /// </summary>
		[DataMember]
        public virtual int? F_SortCode { get; set; }

        /// <summary>
        /// 删除标志
        /// </summary>
		[DataMember]
        public virtual bool? F_DeleteMark { get; set; }

        /// <summary>
        /// 有效标志
        /// </summary>
		[DataMember]
        public virtual bool? F_EnabledMark { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
		[DataMember]
        public virtual string F_Description { get; set; }

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

        /// <summary>
        /// 最后修改时间
        /// </summary>
		[DataMember]
        public virtual DateTime? F_LastModifyTime { get; set; }

        /// <summary>
        /// 最后修改用户
        /// </summary>
		[DataMember]
        public virtual string F_LastModifyUserId { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
		[DataMember]
        public virtual DateTime? F_DeleteTime { get; set; }

        /// <summary>
        /// 删除用户
        /// </summary>
		[DataMember]
        public virtual string F_DeleteUserId { get; set; }


        #endregion

    }
}