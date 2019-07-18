using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using KGM.Framework.ControlUtil;

namespace KGMFramework.WebApp.Entity
{
    /// <summary>
    /// 用户表
    /// </summary>
    [DataContract]
    public class Sys_UserInfo : AppBaseEntity
    {
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public Sys_UserInfo()
        {
            this.F_Id = System.Guid.NewGuid().ToString();
            this.F_Gender = false;
            this.F_SecurityLevel = 0;
            this.F_IsAdministrator = false;
            this.F_SortCode = 0;
            this.F_DeleteMark = false;
            this.F_EnabledMark = false;
            this.F_CreatorTime = System.DateTime.Now;

        }

        #region Property Members

        /// <summary>
        /// 仓库Id
        /// </summary>
        [DataMember]
        public virtual string F_WarehouseId { get; set; }
        /// <summary>
        /// 仓库名称
        /// </summary>
        [DataMember]
        public virtual string F_WarehouseName { get; set; }
        /// <summary>
        /// 账户
        /// </summary>
        [DataMember]
        public virtual string F_Account { get; set; }

        /// <summary>
        /// 用户密码
        /// </summary>
        [DataMember]
        public virtual string F_UserPassword { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [DataMember]
        public virtual string F_RealName { get; set; }

        /// <summary>
        /// 呢称
        /// </summary>
        [DataMember]
        public virtual string F_NickName { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        [DataMember]
        public virtual string F_HeadIcon { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [DataMember]
        public virtual bool? F_Gender { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        [DataMember]
        public virtual DateTime? F_Birthday { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        [DataMember]
        public virtual string F_MobilePhone { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [DataMember]
        public virtual string F_Email { get; set; }

        /// <summary>
        /// 微信
        /// </summary>
        [DataMember]
        public virtual string F_WeChat { get; set; }

        /// <summary>
        /// 主管主键
        /// </summary>
        [DataMember]
        public virtual string F_ManagerId { get; set; }

        /// <summary>
        /// 安全级别
        /// </summary>
        [DataMember]
        public virtual int? F_SecurityLevel { get; set; }

        /// <summary>
        /// 个性签名
        /// </summary>
        [DataMember]
        public virtual string F_Signature { get; set; }

        /// <summary>
        /// 组织主键
        /// </summary>
        [DataMember]
        public virtual string F_OrganizeId { get; set; }


        /// <summary>
        /// 组织名称
        /// </summary>
        [DataMember]
        public virtual string F_OrganizeName { get; set; }

        /// <summary>
        /// 部门主键
        /// </summary>
        [DataMember]
        public virtual string F_DepartmentId { get; set; }


        /// <summary>
        /// 部门名称
        /// </summary>
        [DataMember]
        public virtual string F_DepartmentName { get; set; }

        /// <summary>
        /// 角色主键
        /// </summary>
        [DataMember]
        public virtual string F_RoleId { get; set; }


        /// <summary>
        /// 角色名称
        /// </summary>
        [DataMember]
        public virtual string F_RoleName { get; set; }

        /// <summary>
        /// 岗位主键
        /// </summary>
        [DataMember]
        public virtual string F_DutyId { get; set; }


        /// <summary>
        /// 岗位名称
        /// </summary>
        [DataMember]
        public virtual string F_DutyName { get; set; }

        /// <summary>
        /// 是否管理员
        /// </summary>
        [DataMember]
        public virtual bool? F_IsAdministrator { get; set; }

  


        [DataMember]
        public virtual string F_CompanyName { get; set; }

        #endregion

    }
}