using System.Runtime.Serialization;

namespace KGMFramework.WebApp.WebApi.Models
{
    /// <summary>
    /// 打印对象
    /// </summary>
    [DataContract]
    public class BartendPrintModel
    {
        /// <summary>
        /// 打印内容
        /// 以键值对的方式 变量:值  
        /// 例如 模板上存在3个变量 a b c  
        /// 此处传值为 [{"a":"a的值","b":"b的值","c":"c的值"}]
        /// </summary>
        [DataMember]
        public string printContent { get; set; }
        //打印内容
        /// <summary>
        /// 打印的模板名称
        /// </summary>
        [DataMember]
        public string printModel { get; set; }
        //模版名称
        /// <summary>
        /// 打印的份数
        /// </summary>
        [DataMember]
        public short copies { get; set; }
        //打印份数
        /// <summary>
        /// 调用的打印机名
        /// </summary>
        [DataMember]
        public string printName { get; set; } //打印机名称
    }
}
