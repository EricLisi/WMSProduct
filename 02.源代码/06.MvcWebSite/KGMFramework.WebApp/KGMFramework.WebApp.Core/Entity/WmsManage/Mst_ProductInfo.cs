using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using KGM.Framework.ControlUtil;

namespace KGMFramework.WebApp.Entity
{
    /// <summary>
    /// 商品信息表
    /// </summary>
    [DataContract]
    public class Mst_ProductInfo : AppBaseEntity
    {
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public Mst_ProductInfo()
        {
            this.F_Id = System.Guid.NewGuid().ToString();
            this.F_Length = 0;
            this.F_Height = 0;
            this.F_Width = 0;
            this.F_NetWeight = 0;
            this.F_Weight = 0;
            this.F_PurchasePrice = 0;
            this.F_SalesPrice = 0;
            this.F_BatchManagement = false;
            this.F_SnManagement = false;
            this.F_EffectiveManagement = false;
            this.F_EffectiveDays = 0;
            this.F_EffectiveUnit = 0;
            this.F_Package = 0;
            this.F_SortCode = 0;
            this.F_DeleteMark = false;
            this.F_EnabledMark = false;
        }

        #region Property Members

        /// <summary>
        /// 商品编号
        /// </summary>
        [DataMember]
        public virtual string F_EnCode { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        [DataMember]
        public virtual string F_FullName { get; set; }

        /// <summary>
        /// 商品简码
        /// </summary>
        [DataMember]
        public virtual string F_ShortCode { get; set; }

        /// <summary>
        /// 商品简称
        /// </summary>
        [DataMember]
        public virtual string F_ShortName { get; set; }

        /// <summary>
        /// 商品分类Id
        /// </summary>
        [DataMember]
        public virtual string F_ProductClassId { get; set; }

        /// <summary>
        /// 商品权属Id
        /// </summary>
        [DataMember]
        public virtual string F_OwnershipId { get; set; }

        /// <summary>
        /// 规格
        /// </summary>
        [DataMember]
        public virtual string F_Standard { get; set; }

        /// <summary>
        /// 品牌
        /// </summary>
        [DataMember]
        public virtual string F_Brand { get; set; }

        /// <summary>
        /// 颜色
        /// </summary>
        [DataMember]
        public virtual string F_Color { get; set; }

        /// <summary>
        /// 长
        /// </summary>
        [DataMember]
        public virtual decimal F_Length { get; set; }

        /// <summary>
        /// 高
        /// </summary>
        [DataMember]
        public virtual decimal F_Height { get; set; }

        /// <summary>
        /// 宽
        /// </summary>
        [DataMember]
        public virtual decimal F_Width { get; set; }

        /// <summary>
        /// 净重
        /// </summary>
        [DataMember]
        public virtual decimal F_NetWeight { get; set; }

        /// <summary>
        /// 毛重
        /// </summary>
        [DataMember]
        public virtual decimal F_Weight { get; set; }

        /// <summary>
        /// 采购单价
        /// </summary>
        [DataMember]
        public virtual decimal F_PurchasePrice { get; set; }

        /// <summary>
        /// 销售单价
        /// </summary>
        [DataMember]
        public virtual decimal F_SalesPrice { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        [DataMember]
        public virtual string F_Unit { get; set; }

        /// <summary>
        /// 批次管理
        /// </summary>
        [DataMember]
        public virtual bool F_BatchManagement { get; set; }

        /// <summary>
        /// 序列号管理
        /// </summary>
        [DataMember]
        public virtual bool F_SnManagement { get; set; }

        /// <summary>
        /// 效期管理
        /// </summary>
        [DataMember]
        public virtual bool F_EffectiveManagement { get; set; }

        /// <summary>
        /// 保质期
        /// </summary>
        [DataMember]
        public virtual int F_EffectiveDays { get; set; }

        /// <summary>
        /// 保质期单位(0 日 1 月 2 年)
        /// </summary>
        [DataMember]
        public virtual int F_EffectiveUnit { get; set; }

        /// <summary>
        /// 包装规格
        /// </summary>
        [DataMember]
        public virtual int F_Package { get; set; }

        /// <summary>
        /// 自定义项1
        /// </summary>
        [DataMember]
        public virtual string F_Define1 { get; set; }

        /// <summary>
        /// 自定义项2
        /// </summary>
        [DataMember]
        public virtual string F_Define2 { get; set; }

        /// <summary>
        /// 自定义项3
        /// </summary>
        [DataMember]
        public virtual string F_Define3 { get; set; }

        /// <summary>
        /// 自定义项4
        /// </summary>
        [DataMember]
        public virtual string F_Define4 { get; set; }

        /// <summary>
        /// 自定义项5
        /// </summary>
        [DataMember]
        public virtual string F_Define5 { get; set; }

        /// <summary>
        /// 自定义项6
        /// </summary>
        [DataMember]
        public virtual string F_Define6 { get; set; }

        /// <summary>
        /// 自定义项7
        /// </summary>
        [DataMember]
        public virtual string F_Define7 { get; set; }

        /// <summary>
        /// 自定义项8
        /// </summary>
        [DataMember]
        public virtual string F_Define8 { get; set; }

        /// <summary>
        /// 自定义项9
        /// </summary>
        [DataMember]
        public virtual string F_Define9 { get; set; }

        /// <summary>
        /// 自定义项10
        /// </summary>
        [DataMember]
        public virtual string F_Define10 { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public virtual string F_Description { get; set; }

        /// <summary>
        /// 排序号
        /// </summary>
        [DataMember]
        public virtual int F_SortCode { get; set; }

        /// <summary>
        /// 删除标记
        /// </summary>
        [DataMember]
        public virtual bool F_DeleteMark { get; set; }

        /// <summary>
        /// 有效标记
        /// </summary>
        [DataMember]
        public virtual bool F_EnabledMark { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DataMember]
        public virtual DateTime F_CreatorTime { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        [DataMember]
        public virtual string F_CreatorUserId { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        [DataMember]
        public virtual DateTime F_LastModifyTime { get; set; }

        /// <summary>
        /// 最后修改人
        /// </summary>
        [DataMember]
        public virtual string F_LastModifyUserId { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
        [DataMember]
        public virtual DateTime F_DeleteTime { get; set; }

        /// <summary>
        /// 删除操作人
        /// </summary>
        [DataMember]
        public virtual string F_DeleteUserId { get; set; }


        #endregion

    }
}