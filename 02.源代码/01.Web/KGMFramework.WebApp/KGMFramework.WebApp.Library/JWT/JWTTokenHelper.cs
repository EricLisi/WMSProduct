/*******************************************************************************
 * Copyright © 2017 KGMFramework 版权所有
 * Author: KGM
 * Description: KGM 快速开发平台
 * Website：http://www.kgmsoft.com.cn
*********************************************************************************/
using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGMFramework.WebApp.Library
{
    /// <summary>
    /// token帮助类
    /// </summary>
    public class JWTTokenHelper
    {
        #region Token认证相关
        /// <summary>
        /// TOKEN加密字符串
        /// </summary>
        private const string TOKEN_SECRET = "GQDstcKsx0NHjPOuXOYg5MbeJ1XT0uFiwDVvVBrk";
        /// <summary>
        /// 证书颁发者
        /// </summary>
        private const string ISS_VALUE = "KgmSoft";
        /// <summary>
        /// TOKEN唯一值
        /// </summary>
        private static string JTI_VALUE = Guid.NewGuid().ToString();
        /// <summary>
        /// 启用日期
        /// </summary>
        private const string NBF_TIME = "2018-01-16";
        /// <summary>
        /// TOKEN开始日期
        /// </summary>
        private static DateTime TOKEN_STARTDATE = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);



        #endregion

        /// <summary>
        /// 创建Token
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="bAdmin">是否超级管理员</param>
        /// <returns></returns>
        public static Task<string> GetTokenAsync(string userId, bool bAdmin)
        {
            return Task.Run(() =>
            {
                return GetToken(userId, bAdmin);
            });
        }

        /// <summary>
        /// 创建Token
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="bAdmin">是否超级管理员</param>
        /// <returns></returns>
        public static string GetToken(string userId, bool bAdmin)
        {
            //生成过期时间
            IDateTimeProvider provider = new UtcDateTimeProvider();
            var now = provider.GetNow();//token颁发时间
            var exp = now.AddHours(ConstValue.TOKEN_EXPTIME);//token过期时间
            var nbf = Convert.ToDateTime(NBF_TIME);//启用日期
            var secondsSinceEpoch = Math.Round((now - TOKEN_STARTDATE).TotalSeconds);
            var secondsExp = Math.Round((exp - TOKEN_STARTDATE).TotalSeconds);
            var secondsNbf = Math.Round((nbf - TOKEN_STARTDATE).TotalSeconds);

            //生成token
            var payload = new Dictionary<string, object>
                {
                    {ConstValue.SUB_KEY_NODE, userId},// 该JWT所面向的用户
                    {ConstValue.ISS_KEY_NODE, ISS_VALUE},//该JWT的签发者
                    {ConstValue.IAT_KEY_NODE, secondsSinceEpoch},//在什么时候签发的token
                    {ConstValue.EXP_KEY_NODE, secondsExp},// token什么时候过期
                    {ConstValue.NBF_KEY_NODE, secondsNbf},//token在此时间之前不能被接收处理
                    {ConstValue.JTI_KEY_NODE, JTI_VALUE}, //JWT ID为web token提供唯一标识 
                    {ConstValue.ADMIN_KEY_NODE, bAdmin} //是否超级管理员
                };

            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);

            return encoder.Encode(payload, TOKEN_SECRET); ;
        }


        /// <summary>
        /// 解析token获取token信息
        /// </summary>
        /// <param name="token">token字符串</param>
        /// <returns>返回JWT对象字典
        /// var payload = new Dictionary<string, object>
        /// {
        ///     {ConstValue.SUB_KEY_NODE, userId},// 该JWT所面向的用户
        ///     {ConstValue.ISS_KEY_NODE, ISS_VALUE},//该JWT的签发者
        ///     {ConstValue.IAT_KEY_NODE, secondsSinceEpoch},//在什么时候签发的token
        ///     {ConstValue.EXP_KEY_NODE, secondsExp},// token什么时候过期
        ///     {ConstValue.NBF_KEY_NODE, secondsNbf},//token在此时间之前不能被接收处理
        ///     {ConstValue.JTI_KEY_NODE, JTI_VALUE}, //JWT ID为web token提供唯一标识 
        ///     {ConstValue.ADMIN_KEY_NODE, bAdmin} //是否超级管理员
        ///}; 
        /// </returns>
        public static Task<Dictionary<string, object>> AnalyzeTokenAsync(string token)
        {
            return Task.Run(() =>
            {
                return AnalyzeToken(token);
            });
        }


        /// <summary>
        /// 解析token获取token信息
        /// </summary>
        /// <param name="token">token字符串</param>
        /// <returns>返回JWT对象字典
        /// var payload = new Dictionary<string, object>
        /// {
        ///     {ConstValue.SUB_KEY_NODE, userId},// 该JWT所面向的用户
        ///     {ConstValue.ISS_KEY_NODE, ISS_VALUE},//该JWT的签发者
        ///     {ConstValue.IAT_KEY_NODE, secondsSinceEpoch},//在什么时候签发的token
        ///     {ConstValue.EXP_KEY_NODE, secondsExp},// token什么时候过期
        ///     {ConstValue.NBF_KEY_NODE, secondsNbf},//token在此时间之前不能被接收处理
        ///     {ConstValue.JTI_KEY_NODE, JTI_VALUE}, //JWT ID为web token提供唯一标识 
        ///     {ConstValue.ADMIN_KEY_NODE, bAdmin} //是否超级管理员
        ///}; 
        /// </returns>
        public static Dictionary<string, object> AnalyzeToken(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new ApplicationException("没有token信息");
            }

            IJsonSerializer serializer = new JsonNetSerializer();
            IDateTimeProvider provider = new UtcDateTimeProvider();
            IJwtValidator validator = new JwtValidator(serializer, provider);
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);
            var json = decoder.Decode(token, TOKEN_SECRET, verify: true);
            if (string.IsNullOrEmpty(json))
            {
                throw new ApplicationException("token不正确");
            }
            //解析获得JSON对象
            return JsonAppHelper.ToObject<Dictionary<string, object>>(json);
        }
    }
}
