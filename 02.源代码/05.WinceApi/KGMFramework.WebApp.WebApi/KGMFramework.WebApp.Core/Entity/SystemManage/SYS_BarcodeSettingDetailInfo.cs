using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using KGM.Framework.ControlUtil;

namespace KGMFramework.WebApp.Entity
{
    /// <summary>
    /// 业务类型
    /// </summary>
    [DataContract]
    public class SYS_BarcodeSettingDetailInfo : AppBaseEntity
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
	    public SYS_BarcodeSettingDetailInfo()
		{
            this.F_Id = System.Guid.NewGuid().ToString();
            this.F_Type = 0;
            this.F_Length = 0;
            this.F_AnalyzeMark = false;
            this.F_GenerateMark = false;
            this.F_GenerateRule = 0;
            this.F_GenerateLength = 0;
            this.F_SortCode = 0;
            this.F_DeleteMark = false;
            this.F_EnabledMark = false;
            this.F_IndexSpilt = 0;
  
		}

        #region Property Members
        


        ///// <summary>
        ///// 主键
        ///// </summary>
        //[DataMember]
        //public virtual string F_ParentId { get; set; }


        /// <summary>
        /// 类型
        /// </summary>
		[DataMember]
        public virtual int F_Type { get; set; }

        /// <summary>
        /// 长度
        /// </summary>
		[DataMember]
        public virtual int F_Length { get; set; }

        /// <summary>
        /// 解析标识
        /// </summary>
		[DataMember]
        public virtual bool F_AnalyzeMark { get; set; }

        /// <summary>
        /// 映射表名
        /// </summary>
		[DataMember]
        public virtual string F_Table { get; set; }

        /// <summary>
        /// 映射字段名
        /// </summary>
		[DataMember]
        public virtual string F_ValueFiled { get; set; }

        /// <summary>
        /// 显示字段
        /// </summary>
		[DataMember]
        public virtual string F_DisplayFiled { get; set; }

        /// <summary>
        /// 过滤条件
        /// </summary>
		[DataMember]
        public virtual string F_Condition { get; set; }

        /// <summary>
        /// 自动生成标识
        /// </summary>
		[DataMember]
        public virtual bool F_GenerateMark { get; set; }

        /// <summary>
        /// 生成规则
        /// </summary>
		[DataMember]
        public virtual int F_GenerateRule { get; set; }

        /// <summary>
        /// 生成格式
        /// </summary>
		[DataMember]
        public virtual string F_GenerateFormatter { get; set; }

        /// <summary>
        /// 生成长度
        /// </summary>
		[DataMember]
        public virtual int F_GenerateLength { get; set; }

   

        /// <summary>
        /// 位置截取数
        /// </summary>
		[DataMember]
        public virtual int F_IndexSpilt { get; set; }


        #endregion

    }
}