/*******************************************************************************
 * Copyright © 2017 KGMFramework 版权所有
 * Author: KGM
 * Description: KGM 快速开发平台
 * Website：http://www.kgmsoft.com.cn
*********************************************************************************/
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Data;

namespace KGMFramework.WebApp.Library
{
    public static class JsonAppHelper
    {
        /// <summary>
        /// 将JSON字符串转换成object对象
        /// </summary>
        /// <param name="Json">json字符串</param>
        /// <returns>object对象</returns>
        public static object ToJson(this string Json)
        {
            return Json == null ? null : JsonConvert.DeserializeObject(Json);
        }

        /// <summary>
        /// 将object对象转换成JSON字符串
        /// </summary>
        /// <param name="obj">object对象</param>
        /// <returns>json字符串</returns>
        public static string ToJson(this object obj)
        {
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = ConstValue.DATETIME_FORMATTER_120 };
            return JsonConvert.SerializeObject(obj, timeConverter);
        }

        /// <summary>
        ///  将object对象转换成JSON字符串
        /// </summary>
        /// <param name="obj">object对象</param>
        /// <param name="datetimeformats">日期格式</param>
        /// <returns>json字符串</returns>
        public static string ToJson(this object obj, string datetimeformats)
        {
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = datetimeformats };
            return JsonConvert.SerializeObject(obj, timeConverter);
        }

        /// <summary>
        /// 将字符串转换成泛型类
        /// </summary>
        /// <typeparam name="T">泛型类</typeparam>
        /// <param name="Json">JSON字符串</param>
        /// <returns>泛型实体类</returns>
        public static T ToObject<T>(this string Json)
        {
            return Json == null ? default(T) : JsonConvert.DeserializeObject<T>(Json);
        }

        /// <summary>
        /// 将字符串转换成泛型类集合
        /// </summary>
        /// <typeparam name="T">泛型类</typeparam>
        /// <param name="Json">JSON字符串</param>
        /// <returns>泛型实体类集合</returns>
        public static List<T> ToList<T>(this string Json)
        {
            return Json == null ? null : JsonConvert.DeserializeObject<List<T>>(Json);
        }

        /// <summary>
        /// 将DataTable转换成泛型类集合
        /// </summary>
        /// <typeparam name="T">泛型类</typeparam>
        /// <param name="dt">datatable</param>
        /// <returns>泛型实体类集合</returns>
        public static List<T> ToList<T>(this DataTable dt)
        {
            string Json = JsonConvert.SerializeObject(dt);
            return Json == null ? null : JsonConvert.DeserializeObject<List<T>>(Json);
        }

        /// <summary>
        /// 将JSON
        /// </summary>
        /// <param name="Json"></param>
        /// <returns></returns>
        public static DataTable ToTable(this string Json)
        {
            return Json == null ? null : JsonConvert.DeserializeObject<DataTable>(Json);
        }
    }
}
