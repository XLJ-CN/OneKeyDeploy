using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VSIX_OneKeyDeploy.Helper
{
    public static class RequestHelper
    {
        //static ELLogHelper LogHelper = new ELLogHelper();


        public static IRestResponse HttpGetSimple(string url)
        {
            try
            {
                var _client = new RestClient(url);
                var _request = new RestRequest(Method.GET);
                var _response = _client.Execute(_request);
                return _response;
            }
            catch (Exception ex)
            {
                //       LogHelper.Error($"发送简单get请求发生未知错误url={url}ex={ex}");
                return null;
            }
        }

        /// <summary>
        /// get 请求  含有超时数据
        /// </summary>
        /// <param name="url"></param>
        /// <param name="timeout"></param>
        /// <returns>返回response对象</returns>
        public static IRestResponse HttpGet(string url, int timeout)
        {
            try
            {
                var _client = new RestClient(url);
                //  _client.Timeout = timeout;
                var _request = new RestRequest(Method.GET);
                _request.Timeout = timeout;
                var _response = _client.Execute(_request);
                return _response;
            }
            catch (Exception ex)
            {
                //LogHelper.Error($"发送简单get请求发生未知错误url={url}ex={ex}");
                return null;
            }
        }


        /// <summary>
        /// 发送简单的get请求
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>

        public static async Task<IRestResponse> HttpGetSimpleAsync(string url)
        {
            try
            {
                var _client = new RestClient(url);
                var _request = new RestRequest(Method.GET);
                var _response = await _client.ExecuteAsync(_request);
                return _response;
            }
            catch (Exception ex)
            {
                // LogHelper.Error($"发送简单get请求发生未知错误url={url}ex={ex}");
                return null;
            }
        }

        /// <summary>
        /// 发送简单post请求
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static async Task<IRestResponse> HttpPostSimple(string url)
        {
            try
            {
                var _client = new RestClient(url);
                var _request = new RestRequest(Method.POST);
                var _response = await _client.ExecuteAsync(_request);
                return _response;
            }
            catch (Exception ex)
            {
                // LogHelper.Error($"发送简单post请求发生未知错误url={url}ex={ex}");
                return null;
            }
        }








        /// <summary>
        /// 发送post请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public static async Task<IRestResponse> HttpPostAsync(string url, object o)
        {
            try
            {
                var _client = new RestClient(url);
                var _request = new RestRequest(Method.POST);
                _request.AddJsonBody(o);
                var _response = await _client.ExecuteAsync(_request);
                return _response;
            }
            catch (Exception ex)
            {
                //  LogHelper.Error($"发送post请求发生未知错误url={url}ex={ex}");
                return null;
            }
        }








        /// <summary>
        /// 发送post请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public static IRestResponse HttpPost(string url, object o)
        {
            try
            {
                var _client = new RestClient(url);
                var _request = new RestRequest(Method.POST);
                _request.AddJsonBody(o);
                var _response = _client.Execute(_request);
                return _response;
            }
            catch (Exception ex)
            {
                //  LogHelper.Error($"发送post请求发生未知错误url={url}ex={ex}");
                return null;
            }
        }







        /// <summary>
        /// 发送带header的post请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="o"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        public static async Task<IRestResponse> HttpHeaderPostAsync(string url, object o, ICollection<KeyValuePair<string, string>> headers)
        {

            try
            {
                //  LogHelper.Info($"PostUrl={url},Body={o}");
                var _client = new RestClient(url);
                var _request = new RestRequest(Method.POST);
                _request.AddJsonBody(o);
                _request.AddHeaders(headers);
                var _response = await _client.ExecuteAsync(_request);
                return _response;
            }
            catch (Exception ex)
            {
                //  LogHelper.Error($"发送post请求发生未知错误url={url}ex={ex}");
                return null;
            }
        }

    }
}
