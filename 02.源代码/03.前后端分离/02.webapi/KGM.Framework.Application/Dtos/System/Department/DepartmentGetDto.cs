using System;
using System.Runtime.Serialization;

namespace KGM.Framework.Application.Dtos
{
    /// <summary>
    /// 查询用户Dto
    /// </summary>
    [DataContract]
    public class DepartmentGetDto
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public DepartmentGetDto()
        {
            this.Id = System.Guid.NewGuid().ToString();
            this.SortCode = 0;
            this.CreatorTime = DateTime.Now;
            this.EnabledMark = false;
            this.DeleteMark = false;
            this.Nature = 0;
        }


        /// <summary>
        /// 图标
        /// </summary> 
        [DataMember]
        public string Icon { get; set; }

        /// <summary>
        /// 是否展开
        /// </summary> 
        [DataMember]
        public bool Showcheck { get; set; }
        /// <summary>
        ///节点
        /// </summary>
        [DataMember]
        public string ParentId { get; set; }

        /// <summary>
        /// 主键
        /// </summary> 
        [DataMember]
        public string Id { get; set; }

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
        /// 所属公司
        /// </summary> 
        [DataMember]
        public string CompanyId { get; set; }

        /// <summary>
        /// 所属公司
        /// </summary> 
        [DataMember]
        public string CompanyCode { get; set; }

        /// <summary>
        /// 所属公司
        /// </summary> 
        [DataMember]
        public string CompanyName { get; set; }

        /// <summary>
        /// 简称
        /// </summary> 
        [DataMember]
        public string ShortName { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        [DataMember]
        public int? Nature { get; set; }


        /// <summary>
        /// 联系人
        /// </summary>
        [DataMember]
        public string Manager { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        [DataMember]
        public string Phone { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [DataMember]
        public string Email { get; set; }

        /// <summary>
        /// 传真
        /// </summary>
        [DataMember]
        public string Fax { get; set; }

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
