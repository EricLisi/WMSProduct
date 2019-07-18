using System.Runtime.Serialization;

/*
    返回对象 
 */
namespace KGMFramework.WebApp.WebApi.Models
{
    /// <summary>
    /// 返回对象
    /// </summary>
    [DataContract]
    public class LoginSystemModel
    { 
        /// <summary>
        /// 登录用户
        /// </summary>
        [DataMember]
        public string Account { get; set; }
        /// <summary>
        /// 登录密码
        /// </summary>
        [DataMember]
        public string Password { get; set; }
        /// <summary>
        /// 登录系统
        /// </summary>
        [DataMember]
        public string LoginSystem { get; set; }
    }
}