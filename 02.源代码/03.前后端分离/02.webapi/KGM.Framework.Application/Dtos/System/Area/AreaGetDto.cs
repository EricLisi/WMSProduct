﻿using System;
using System.Runtime.Serialization;

namespace KGM.Framework.Application.Dtos
{
    /// <summary>
    /// 区域Dto
    /// </summary>
    [DataContract]
    public class AreaGetDto
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public AreaGetDto()
        {
            this.Id = System.Guid.NewGuid().ToString();
            this.SortCode = 0;
            this.CreatorTime = DateTime.Now;
            this.EnabledMark = false;
            this.DeleteMark = false;

        }


        /// <summary>
        /// 主键
        /// </summary>
        [DataMember]
        public string Id { get; set; }

        /// <summary>
        /// 节点
        /// </summary> 
        [DataMember]
        public string ParentId { get; set; }

        /// <summary>
        /// 层
        /// </summary> 
        [DataMember]
        public int Layers { get; set; }

        /// <summary>
        /// 编号
        /// </summary> 
        [DataMember]
        public string EnCode { get; set; }

        /// <summary>
        /// 名称
        /// </summary> 
        [DataMember]
        public string FullName { get; set; }

        /// <summary>
        /// 简称
        /// </summary>
        [DataMember]
        public string SimpleSpelling { get; set; }


        /// <summary>
        /// 层
        /// </summary>
        [DataMember]
        public int? Layer { get; set; }

        /// <summary>
        /// 排序码
        /// </summary> 
        [DataMember]
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
