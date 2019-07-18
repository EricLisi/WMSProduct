using KGM.Framework.Domain.Core;
using KGM.Framework.Infrastructure;
using System;

namespace KGM.Framework.Domain
{
    /// <summary>
    /// 用户类 与数据库结构一致
    /// </summary> 
    [MappingTable(TableName = "Sys_User")]
    public class UserEntity : AggregateRoot
    {
        /// <summary>
        /// 工号
        /// </summary> 
        public string EnCode { get; set; }

        /// <summary>
        /// 账户
        /// </summary> 
        public string Account { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 加密秘钥
        /// </summary>
        public string Secretkey { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary> 
        public string RealName { get; set; }

        /// <summary>
        /// 昵称
        /// </summary> 
        public string NickName { get; set; }

        /// <summary>
        /// 用户头像
        /// </summary> 
        public string HeadIcon { get; set; }

        ///<summary>
        /// 角色性别
        /// </summary> 
        public bool? Gender { get; set; }

        ///<summary>
        /// 电话
        /// </summary> 
        public string PhoneTel { get; set; }

        /// <summary>
        /// 角色ID
        /// </summary> 
        public string RoleId { get; set; }
        /// <summary>
        /// 部门
        /// </summary>
        [MappingFiled(Ignore = true)]
        public RoleEntity Role { get; set; }

        /// <summary>
        /// 机构ID
        /// </summary> 
        public string CompanyId { get; set; }

        /// <summary>
        /// 公司
        /// </summary>
        [MappingFiled(Ignore = true)]
        public CompanyEntity Company { get; set; }

        /// <summary>
        /// 部门ID
        /// </summary> 
        public string DepartmentId { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        [MappingFiled(Ignore = true)]
        public CompanyEntity.DepartmentEntity Department { get; set; }

        /// <summary>
        /// 手机
        /// </summary> 
        public string Mobile { get; set; }

        ///<summary>
        /// 生日
        /// </summary>  
        public DateTime? Birthday { get; set; }

        ///<summary>
        /// 邮箱
        /// </summary> 
        public string Email { get; set; }

        ///<summary>
        /// QQ
        /// </summary> 
        public string OICQ { get; set; }

        ///<summary>
        /// 微信
        /// </summary> 
        public string WeChat { get; set; }
    }
}
