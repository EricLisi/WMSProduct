namespace KGMFramework.WebApp.WebApi.Models
{
    /// <summary>
    /// 枚举类
    /// </summary>
    public class MyEnum
    {
        /// <summary>
        /// 登录系统
        /// </summary>
        public enum LoginSystemEnum
        {
            /// <summary>
            /// 后台管理系统
            /// </summary>
            后台管理系统 = 0,
            /// <summary>
            /// 移动端系统
            /// </summary>
            移动端系统 = 1
        }

        /// <summary>
        /// 单据类型
        /// </summary>
        public enum orderType
        {
            /// <summary>
            /// 资产登记
            /// </summary>
            资产登记 = 0,
            /// <summary>
            /// 资产领用
            /// </summary>
            资产领用 = 1,
            /// <summary>
            /// 资产借用
            /// </summary>
            资产借用 = 2,
            /// <summary>
            /// 资产归还
            /// </summary>
            资产归还 = 3,
            /// <summary>
            /// 资产调出
            /// </summary>
            资产调出 = 4,
            /// <summary>
            /// 资产调入
            /// </summary>
            资产调入 = 5,
            /// <summary>
            /// 资产维修
            /// </summary>
            资产维修 = 6,
            /// <summary>
            /// 资产处置
            /// </summary>
            资产处置 = 7,
            /// <summary>
            /// 资产盘点
            /// </summary>
            资产盘点 = 8
        }
    }
}