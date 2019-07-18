using System;
using System.Runtime.Serialization;

namespace KGM.Framework.Application.Dtos
{
    /// <summary>
    /// MST_SETUPInfo
    /// </summary>
    [DataContract]
    public class SetUpGetDto
    {
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public SetUpGetDto()
        {
            this.Id = System.Guid.NewGuid().ToString();
            this.NumberLength = 0;
            this.IsBatch = false;
            this.SortCode = 0;
            this.DeleteMark = false;
            this.EnabledMark = false;

        }

        #region Property Members
        
        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public string Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public string EnCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public string FullName { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public string PreFix { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public int NumberLength { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public bool IsBatch { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public bool HavePL { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public string Define1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public string Define2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
		[DataMember]
        public string Define3 { get; set; }

        /// <summary>
        /// 排序码
        /// </summary>
		[DataMember]
        public virtual int? SortCode { get; set; }

        /// <summary>
        /// 删除标志
        /// </summary>
		[DataMember]
        public virtual bool? DeleteMark { get; set; }

        /// <summary>
        /// 有效标志
        /// </summary>
		[DataMember]
        public virtual bool? EnabledMark { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
		[DataMember]
        public virtual string Description { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
		[DataMember]
        public virtual DateTime? CreatorTime { get; set; }

        /// <summary>
        /// 创建用户
        /// </summary>
		[DataMember]
        public virtual string CreatorUserId { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
		[DataMember]
        public virtual DateTime? LastModifyTime { get; set; }

        /// <summary>
        /// 最后修改用户
        /// </summary>
		[DataMember]
        public virtual string LastModifyUserId { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
		[DataMember]
        public virtual DateTime? DeleteTime { get; set; }

        /// <summary>
        /// 删除用户
        /// </summary>
		[DataMember]
        public virtual string DeleteUserId { get; set; }


        #endregion

    }
}