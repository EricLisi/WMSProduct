﻿using System;
using System.Runtime.Serialization;

namespace KGM.Framework.Application.Dtos
{
    /// <summary>
    /// 权限配置Dto
    /// </summary>
    [DataContract]
    public class UserDepartmentGetDto
    {
        /// <summary>
        /// 初始化本身
        /// </summary>
        public UserDepartmentGetDto() {
            this.Id = System.Guid.NewGuid().ToString();
            this.CreatorTime = DateTime.Now;
            this.EnabledMark = false;
            this.DeleteMark = false;
            this.SortCode = 0;
        }
        /// <summary>
        /// 用户Id
        /// </summary>
        [DataMember]
        public string Id { get; set; }

        /// <summary>
        ///用户ID
        /// </summary>
        [DataMember]
        public string UserId { get; set; }

        /// <summary>
        ///部门Id
        /// </summary>
        [DataMember]
        public string DepartmentId { get; set; }

        /// <summary>
        /// 描述
        /// </summary> 
         [DataMember]
        public virtual string Description { get; set; }

        /// <summary>
        /// 排序码
        /// </summary> 
  
        public virtual int? SortCode { get; set; }

        /// <summary>
        /// 删除标志
        /// </summary> 

        public virtual bool? DeleteMark { get; set; }

        /// <summary>
        /// 有效标志
        /// </summary> 

        public virtual bool? EnabledMark { get; set; }


        /// <summary>
        /// 创建时间
        /// </summary>

        public virtual DateTime? CreatorTime { get; set; }

        /// <summary>
        /// 创建用户
        /// </summary>

        public virtual string CreatorUserId { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>

        public virtual DateTime? LastModifyTime { get; set; }

        /// <summary>
        /// 最后修改用户
        /// </summary>

        public virtual string LastModifyUserId { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
        public virtual DateTime? DeleteTime { get; set; }

        /// <summary>
        /// 删除用户
        /// </summary> 
        public virtual string DeleteUserId { get; set; }

    

    }
}
