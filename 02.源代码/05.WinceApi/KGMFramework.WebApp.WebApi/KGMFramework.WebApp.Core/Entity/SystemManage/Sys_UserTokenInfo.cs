using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using KGM.Framework.ControlUtil;

namespace KGMFramework.WebApp.Entity
{
    /// <summary>
    /// 用户令牌
    /// </summary>
    [DataContract]
    public class Sys_UserTokenInfo : BaseEntity
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
	    public Sys_UserTokenInfo()
		{
            this.F_Id= System.Guid.NewGuid().ToString();
                 this.F_Sortid= 0;
             this.F_DeleteMark= false;
             this.F_SortCode= 0;
             this.F_EnabledMark= false;
        
		}

        #region Property Members
        
        /// <summary>
        /// 模块主键  
        /// </summary>
		[DataMember]
        public virtual string F_Id { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
		[DataMember]
        public virtual string F_EnCode { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
		[DataMember]
        public virtual string F_FullName { get; set; }

        /// <summary>
        /// 用户Id
        /// </summary>
		[DataMember]
        public virtual string F_UserId { get; set; }

        /// <summary>
        /// 令牌
        /// </summary>
		[DataMember]
        public virtual string F_Token { get; set; }

        /// <summary>
        /// 排序号
        /// </summary>
		[DataMember]
        public virtual double F_Sortid { get; set; }

        /// <summary>
        /// 删除标志
        /// </summary>
		[DataMember]
        public virtual bool F_DeleteMark { get; set; }

        /// <summary>
        /// 排序码
        /// </summary>
		[DataMember]
        public virtual int F_SortCode { get; set; }

        /// <summary>
        /// 有效标志
        /// </summary>
		[DataMember]
        public virtual bool F_EnabledMark { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
		[DataMember]
        public virtual DateTime F_CreatorTime { get; set; }

        /// <summary>
        /// 创建用户主键
        /// </summary>
		[DataMember]
        public virtual string F_CreatorUserId { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
		[DataMember]
        public virtual DateTime F_LastModifyTime { get; set; }

        /// <summary>
        /// 最后修改用户
        /// </summary>
		[DataMember]
        public virtual string F_LastModifyUserId { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
		[DataMember]
        public virtual DateTime F_DeleteTime { get; set; }

        /// <summary>
        /// 删除用户
        /// </summary>
		[DataMember]
        public virtual string F_DeleteUserId { get; set; }


        #endregion

    }
}