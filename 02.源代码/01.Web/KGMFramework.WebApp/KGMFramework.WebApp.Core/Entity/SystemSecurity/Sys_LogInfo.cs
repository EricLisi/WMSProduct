using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using KGM.Framework.ControlUtil;

namespace KGMFramework.WebApp.Entity
{
    /// <summary>
    /// 系统日志
    /// </summary>
    [DataContract]
    public class Sys_LogInfo : AppBaseEntity
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
	    public Sys_LogInfo()
		{
            this.F_Id= System.Guid.NewGuid().ToString();
                     this.F_Result= false;
     
		}

        #region Property Members
        
        /// <summary>
        /// 日志主键
        /// </summary>
		[DataMember]
        public virtual string F_Id { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
		[DataMember]
        public virtual DateTime? F_Date { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
		[DataMember]
        public virtual string F_Account { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
		[DataMember]
        public virtual string F_NickName { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
		[DataMember]
        public virtual string F_Type { get; set; }

        /// <summary>
        /// IP地址
        /// </summary>
		[DataMember]
        public virtual string F_IPAddress { get; set; }

        /// <summary>
        /// IP所在城市
        /// </summary>
		[DataMember]
        public virtual string F_IPAddressName { get; set; }

        /// <summary>
        /// 系统模块Id
        /// </summary>
		[DataMember]
        public virtual string F_ModuleId { get; set; }

        /// <summary>
        /// 系统模块
        /// </summary>
		[DataMember]
        public virtual string F_ModuleName { get; set; }

        /// <summary>
        /// 结果
        /// </summary>
		[DataMember]
        public virtual bool? F_Result { get; set; }

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


        #endregion

    }
}