using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using KGM.Framework.ControlUtil;

namespace KGMFramework.WebApp.Entity
{
    /// <summary>
    /// 用户信息照片表
    /// </summary>
    [DataContract]
    public class Sys_UsersInfo : AppBaseEntity
    {
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        /// 

        public Sys_UsersInfo()
        {
            this.F_Id = System.Guid.NewGuid().ToString();
            this.F_SortCode = 0;
            this.F_DeleteMark = false;
            this.F_EnabledMark = false;

        }

        #region 用户信息
  
        ///// <summary>
        ///// F_FullName
        ///// </summary>
        //[DataMember]
        //public virtual string F_FullName { get; set; }      
        /// 
        /// </summary>

        /// <summary>F_EnCode
        /// 所属部门
        /// </summary>
        [DataMember]
        public virtual string F_DepartmentId { get; set; }

        /// <summary>
        /// 所属机构
        /// </summary>
        [DataMember]
        public virtual string F_OrganizeId { get; set; }


        /// <summary>
        /// 用户账号
        /// </summary>
        [DataMember]
        public virtual string F_Account { get; set; }

        /// <summary>
        /// 所属部门
        /// </summary>
        [DataMember]
        public string F_Password { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
		[DataMember]
        public virtual string F_MobilePhone { get; set; }

        /// <summary>
        /// 自由项1
        /// </summary>
        [DataMember]
        public virtual string F_FreeTerm1 { get; set; }

        /// <summary>
        /// 自由项2
        /// </summary>
        [DataMember]
        public virtual string F_FreeTerm2 { get; set; }

        /// <summary>
        /// 自由项3
        /// </summary>
        [DataMember]
        public virtual string F_FreeTerm3 { get; set; }

        /// <summary>
        /// 自由项4
        /// </summary>
        [DataMember]
        public virtual string F_FreeTerm4 { get; set; }

        /// <summary>
        /// 自由项5
        /// </summary>
        [DataMember]
        public virtual string F_FreeTerm5 { get; set; }

        /// <summary>
        /// 自由项6
        /// </summary>
        [DataMember]
        public virtual string F_FreeTerm6 { get; set; }

        /// <summary>
        /// 自由项7
        /// </summary>
        [DataMember]
        public virtual string F_FreeTerm7 { get; set; }

        /// <summary>
        /// 自由项8
        /// </summary>
        [DataMember]
        public virtual string F_FreeTerm8 { get; set; }

        /// <summary>
        /// 自由项9
        /// </summary>
        [DataMember]
        public virtual string F_FreeTerm9 { get; set; }

        /// <summary>
        /// 自由项10
        /// </summary>
        [DataMember]
        public virtual string F_FreeTerm10 { get; set; }

        #endregion

    }
}