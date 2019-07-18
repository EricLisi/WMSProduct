using System.Text;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace KgmSoft.Scan.Project
{
    public static class WebAPIUtil
    {
        /// <summary>
        /// 将一个对象转换成json
        /// </summary>
        /// <returns></returns>
        public static string ConvertObjToJson(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        /// <summary>
        /// 将一个json转换为对象
        /// </summary>
        /// <returns></returns>
        public static T ConvertJsonToObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        /// <summary>
        /// post方式提交 json
        /// </summary>
        /// <param name="Url">方法url 不需要全路径 只需要方法段路径</param>
        /// <param name="JSONData">传入的json信息</param>
        /// <returns></returns>
        public static string PostAPIByJson(string Url, string JSONData)
        {
            return GetWebAPIResponseData(Url, "post", QSConstValue.DEFALUT_CONTENTTYPE, JSONData);
        }

        /// <summary>
        /// get方式提交 json
        /// </summary>
        /// <param name="Url">方法url 不需要全路径 只需要方法段路径</param> 
        /// <returns></returns>
        public static string GetAPIByJson(string Url)
        {
            return GetWebAPIResponseData(Url, "get", QSConstValue.DEFALUT_CONTENTTYPE, string.Empty);
        }


        /// <summary>
        /// delete方式提交 json
        /// </summary>
        /// <param name="Url">方法url 不需要全路径 只需要方法段路径</param> 
        /// <returns></returns>
        public static string DeleteAPIByJson(string Url)
        {
            return GetWebAPIResponseData(Url, "delete", QSConstValue.DEFALUT_CONTENTTYPE, string.Empty);
        }



        /// <summary>
        /// post方式提交 json  返回一个result对象
        /// </summary>
        /// <param name="Url">方法url 不需要全路径 只需要方法段路径</param>
        /// <param name="JSONData">传入的json信息</param>
        /// <returns></returns>
        public static KgmApiResultEntity PostAPIByJsonToAPIResult(string Url, string JSONData)
        {
            string returnjson = GetWebAPIResponseData(Url, "post", QSConstValue.DEFALUT_CONTENTTYPE, JSONData);
            return JsonConvert.DeserializeObject<KgmApiResultEntity>(returnjson);
        }

        /// <summary>
        /// get方式提交 json 返回一个result对象
        /// </summary>
        /// <param name="Url">方法url 不需要全路径 只需要方法段路径</param> 
        /// <returns></returns>
        public static KgmApiResultEntity GetToAPIByJsonToAPIResult(string Url)
        {
            string returnjson = GetWebAPIResponseData(Url, "get", QSConstValue.DEFALUT_CONTENTTYPE, string.Empty);
            return JsonConvert.DeserializeObject<KgmApiResultEntity>(returnjson);
        }


        /// <summary>
        /// delete方式提交 json 返回一个result对象
        /// </summary>
        /// <param name="Url">方法url 不需要全路径 只需要方法段路径</param> 
        /// <returns></returns>
        public static KgmApiResultEntity DeleteToAPIByJsonToAPIResult(string Url)
        {
            string returnjson = GetWebAPIResponseData(Url, "delete", QSConstValue.DEFALUT_CONTENTTYPE, string.Empty);
            return JsonConvert.DeserializeObject<KgmApiResultEntity>(returnjson);
        }

        /// <summary>
        /// post方式提交 json  返回一个泛型对象
        /// </summary>
        /// <param name="Url">方法url 不需要全路径 只需要方法段路径</param>
        /// <param name="JSONData">传入的json信息</param>
        /// <returns></returns>
        public static T PostAPIByJsonToGeneric<T>(string Url, string JSONData)
        {
            string returnjson = GetWebAPIResponseData(Url, "post", QSConstValue.DEFALUT_CONTENTTYPE, JSONData);
            return JsonConvert.DeserializeObject<T>(returnjson);
        }

        /// <summary>
        /// get方式提交 json  返回一个泛型对象
        /// </summary>
        /// <param name="Url">方法url 不需要全路径 只需要方法段路径</param>
        /// <param name="JSONData">传入的json信息</param>
        /// <returns></returns>
        public static T GetAPIByJsonToGeneric<T>(string Url)
        {
            string returnjson = GetWebAPIResponseData(Url, "get", QSConstValue.DEFALUT_CONTENTTYPE, string.Empty);
            return JsonConvert.DeserializeObject<T>(returnjson);
        }

        /// <summary>
        /// delete方式提交 json  返回一个泛型对象
        /// </summary>
        /// <param name="Url">方法url 不需要全路径 只需要方法段路径</param>
        /// <param name="JSONData">传入的json信息</param>
        /// <returns></returns>
        public static T DeleteAPIByJsonToGeneric<T>(string Url)
        {
            string returnjson = GetWebAPIResponseData(Url, "delete", QSConstValue.DEFALUT_CONTENTTYPE, string.Empty);
            return JsonConvert.DeserializeObject<T>(returnjson);
        }


        /// <summary>
        /// 调用API
        /// </summary>
        /// <param name="url">方法url</param>
        /// <param name="method">post get put...</param>
        /// <param name="body">参数格式</param>
        /// <param name="contentType">参数类型</param>
        /// <returns></returns>
        private static string GetWebAPIResponseData(string url, string method, string contentType, string body)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(QSCommonValue.WebAPIUri.AbsoluteUri + url);
            httpWebRequest.ContentType = contentType;
            httpWebRequest.Method = method;
            httpWebRequest.Timeout = 20000;


            if (!string.IsNullOrEmpty(QSCommonValue.token))
            {
                httpWebRequest.Headers.Add(string.Format("Bearer:{0} ", QSCommonValue.token));
            }

            if (!string.IsNullOrEmpty(body) && method.ToLower() != "get")
            {
                byte[] bytes = Encoding.UTF8.GetBytes(body);
                httpWebRequest.ContentLength = bytes.Length;
                Stream reqstream = httpWebRequest.GetRequestStream();
                reqstream.Write(bytes, 0, bytes.Length);
                reqstream.Flush();
                reqstream.Close(); 
            }

            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream());
            string responseContent = streamReader.ReadToEnd();

            httpWebResponse.Close();
            streamReader.Close();
            httpWebRequest.Abort();
            httpWebResponse.Close();

            return responseContent;
        } 
    }
}
