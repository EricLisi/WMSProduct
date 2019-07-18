/*******************************************************************************
 * Copyright © 2017 KGMFramework 版权所有
 * Author: KGM
 * Description: KGM 快速开发平台
 * Website：http://www.kgmsoft.com.cn
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGMFramework.WebApp.Library
{
    /// <summary>
    /// 共通常量类
    /// </summary>
    public static class ConstValue
    {
        #region 后台管理员相关
        /// <summary>
        /// 管理员账号
        /// </summary>
        public const string KGMADMIN_USERID = "kgmAdmin";
        /// <summary>
        /// 管理员密码
        /// </summary>
        public const string KGMADMIN_PASSWORD = "Kgm123!@#";
        /// <summary>
        /// 管理员名称
        /// </summary>
        public const string KGMADMIN_USERNAME = "超级管理员";
        #endregion

        #region Token认证相关
        /// <summary>
        /// Token过期时间 小时
        /// </summary>
        public const double TOKEN_EXPTIME = 24;
        /// <summary>
        /// 验证表头
        /// </summary>
        public const string TOKEN_HEADER = "Authorization";
        /// <summary>
        /// 该JWT所面向的用户
        /// </summary>
        public const string SUB_KEY_NODE = "sub";
        /// <summary>
        /// 该JWT的签发者
        /// </summary>
        public const string ISS_KEY_NODE = "iss";
        /// <summary>
        /// 在什么时候签发的token
        /// </summary>
        public const string IAT_KEY_NODE = "iat";
        /// <summary>
        /// token什么时候过期
        /// </summary>
        public const string EXP_KEY_NODE = "exp";
        /// <summary>
        /// token在此时间之前不能被接收处理
        /// </summary>
        public const string NBF_KEY_NODE = "nbf";
        /// <summary>
        /// token在此时间之前不能被接收处理
        /// </summary>
        public const string JTI_KEY_NODE = "jti";
        /// <summary>
        /// 当前用户是否是超级管理员
        /// </summary>
        public const string ADMIN_KEY_NODE = "adm";

        /// <summary>
        /// 当前登录的公司
        /// </summary>
        public const string CORP_KEY_NODE = "corp";
        #endregion

        #region 日期相关
        /// <summary>
        /// 日期格式 yyyy-MM-dd
        /// </summary>
        public const string DATE_FORMATTER_120 = "yyyy-MM-dd";

        /// <summary>
        /// 日期格式 yyyy-MM-dd HH:mm:ss
        /// </summary>
        public const string DATETIME_FORMATTER_120 = "yyyy-MM-dd HH:mm:ss";

        /// <summary>
        /// 日期格式 yyyyMMdd
        /// </summary>
        public const string DATE_FORMATTER_112 = "yyyyMMdd";

        /// <summary>
        /// 日期格式 HH:mm:ss
        /// </summary>
        public const string TIME_FORMATTER_108 = "HH:mm:ss";
        #endregion
    }
}
