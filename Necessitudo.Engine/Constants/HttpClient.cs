using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Necessitudo.Engine.Constants
{
    public class HttpClientUtil
    {
        public const int REST_REQUEST_TIMEOUT = 120;
        public object defaultHeader;
        public ILogger Logger { get; set; }

        public HttpClientUtil(string proxyAddress = null)
        {
            FlurlHttp.Configure(opt =>
            {
                //opt.HttpClientFactory = new ProxyHttpClientFactory(proxyAddress);
                opt.AllowedHttpStatusRange = "*";
            });
        }

        public T GetJSON<T>(string path, object queryParams = null, object headers = null, object cookies = null)
        {
            try
            {
                if (defaultHeader != null) headers = defaultHeader;

                var obj = new Url(path)
                   .SetQueryParams(queryParams ?? new { })
                   .WithCookies(cookies ?? new { })
                   .WithTimeout(REST_REQUEST_TIMEOUT)
                   .WithHeaders(headers ?? new { })
                   .GetAsync().ReceiveJson<T>();
                return obj.Result;
            }
            catch (TaskCanceledException)
            {
                return default(T);
            }
            catch (Exception ex)
            {
                if (Logger != null) Logger.LogError(ex, "Flurl handled exception");
                return default(T);
            }
        }

        public string GetString(string path, object queryParams = null, object headers = null,
            object cookies = null)
        {
            try
            {
                if (defaultHeader != null) headers = defaultHeader;

                return new Url(path)
                    .SetQueryParams(queryParams ?? new { })
                    .WithCookies(cookies ?? new { })
                   .WithTimeout(REST_REQUEST_TIMEOUT)
                    .WithHeaders(headers ?? new { })
                    .GetStringAsync().Result;
            }
            catch (TaskCanceledException)
            {
                return string.Empty;
            }
            catch (IOException)
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// Sending a Get request with a json body
        /// </summary>
        /// <param name="url"></param>
        /// <param name="headers"></param>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<string> GetWithBody(string url, Dictionary<string, string> headers = null, object req = null)
        {
            var jsonString = string.Empty;
            var responseBody = string.Empty;
            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri(url),
                    Method = HttpMethod.Get,
                };
                jsonString = JsonConvert.SerializeObject(req);
                if(req != null)
                {
                    request.Content = new StringContent(jsonString, Encoding.UTF8);
                    request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                }

                try
                {
                    if (headers != null)
                    {
                        foreach (var item in headers)
                        {
                            request.Headers.Add(item.Key, item.Value);
                        }
                    }

                    var result = client.SendAsync(request).Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var jsonContent = new MediaTypeHeaderValue("application/json").MediaType;
                        var content = result.Content.Headers.ContentType.MediaType;
                        if (content != jsonContent)
                        {
                            //do XML to json conversion here
                            responseBody = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
                            XmlDocument doc = new XmlDocument();
                            doc.LoadXml(responseBody);
                            var con = doc.LastChild;
                            jsonString = JsonConvert.SerializeXmlNode(con);
                            return jsonString;
                        }

                        responseBody = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
                    }
                    else
                    {
                        responseBody = null;
                    }

                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }

            return responseBody;
        }

        /// <summary>
        /// Custom Post Method
        /// </summary>
        /// <param name="url"></param>
        /// <param name="headers"></param>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<string> PostwithBody(string url, Dictionary<string, string> headers = null, object req = null)
        {
            var jsonString = string.Empty;
            var responseBody = string.Empty;
            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri(url),
                    Method = HttpMethod.Post,
                };
                jsonString = JsonConvert.SerializeObject(req);
                //request.Content = new ByteArrayContent(Encoding.UTF8.GetBytes(req));
                request.Content = new StringContent(jsonString);
                request.Content.Headers.Clear();
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                try
                {
                    if (headers != null)
                    {
                        foreach (var item in headers)
                        {
                            request.Headers.Add(item.Key, item.Value);
                        }
                    }

                    var result = client.SendAsync(request).Result;
                    //result.EnsureSuccessStatusCode();

                    responseBody = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }

            return responseBody;
        }
        public T PostJSON<T>(string path, object payload = null,
            int timeout = REST_REQUEST_TIMEOUT,
            object headers = null, object cookies = null)
        {
            try
            {
                if (defaultHeader != null) headers = defaultHeader;

                var result = new Url(path)
                    // .WithTimeout(timeout)
                    .AllowAnyHttpStatus()
                    .WithCookies(cookies ?? new { })
                                    .WithHeaders(headers ?? new { })
                                    .PostJsonAsync(payload ?? new object()).ReceiveJson<T>().Result;
                return result;
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.InternalServerError)
                    throw ex;

                var response = ex.GetResponseJsonAsync<T>().Result;
                if (Logger != null) Logger.LogError(ex, "Flurl handled exception");
                return response;
            }
            catch (TaskCanceledException)
            {
                return default(T);
            }
            catch (IOException)
            {
                return default(T);
            }
        }

        public string PostJSONForString(string path, object payload = null, object headers = null,
                                                  object cookies = null)
        {
            try
            {
                if (defaultHeader != null) headers = defaultHeader;

                var result = new Url(path)
                    .AllowAnyHttpStatus()
                    .WithTimeout(REST_REQUEST_TIMEOUT)
                    .WithCookies(cookies ?? new { })
                                   .WithHeaders(headers ?? new { })
                    .PostJsonAsync(payload ?? new object()).ReceiveString().Result;
                return result;
            }
            catch (TaskCanceledException)
            {
                return string.Empty;
            }
            catch (IOException)
            {
                return string.Empty;
            }
        }
        public async Task PostJSONAsync(string path, object payload = null, object headers = null,
                                                  object cookies = null)
        {
            try
            {
                if (defaultHeader != null) headers = defaultHeader;

                await new Url(path).WithCookies(cookies ?? new { }).WithTimeout(REST_REQUEST_TIMEOUT)
                                  .WithHeaders(headers ?? new { })
                                   .PostJsonAsync(payload ?? new object());
            }
            catch (TaskCanceledException)
            {
            }
            catch (IOException)
            {
            }
        }


        public async Task<String> UploadByteArrayAsync(string path, byte[] imageBytes, byte[] secondaryImageBytes, string token, ICollection<KeyValuePair<String, String>> payload = null)
        {
            try
            {
                using (Stream primaryFileStream = new MemoryStream(imageBytes))
                {
                    using (Stream secondaryFileStream = secondaryImageBytes == null ? new MemoryStream() : new MemoryStream(secondaryImageBytes))
                        return await new Url(path).WithTimeout(REST_REQUEST_TIMEOUT).PostMultipartAsync((mp) =>
                        {
                            mp.AddFile("File", primaryFileStream, "my_uploaded_image.jpg");
                            if (secondaryImageBytes != null)
                            {
                                mp.AddFile("BackFile", secondaryFileStream, "my_secondary_uploaded_image.jpg");
                            }
                            if (payload != null)
                            {
                                foreach (var item in payload)
                                {
                                    mp.AddString(item.Key, item.Value);
                                }
                            }
                        }).ReceiveJson<String>();
                }
            }
            catch (TaskCanceledException)
            {
                return string.Empty;
            }
            catch (IOException)
            {
                return string.Empty;
            }
        }
        public T PostUrlEncodedAsync<T>(string path, object payload = null, object headers = null,
                                                  object cookies = null)
        {
            try
            {
                if (defaultHeader != null) headers = defaultHeader;

                return new Url(path).WithCookies(cookies ?? new { }).WithTimeout(REST_REQUEST_TIMEOUT)
                                   .WithHeaders(headers ?? new { })
                                          .PostUrlEncodedAsync(payload ?? new object()).ReceiveJson<T>().Result;
            }
            catch (TaskCanceledException)
            {
                return default(T);
            }
            catch (IOException)
            {
                return default(T);
            }
        }
        public async Task PostUrlEncodedAsync(string path, object payload = null, object headers = null,
                                                  object cookies = null)
        {
            try
            {
                if (defaultHeader != null) headers = defaultHeader;

                await new Url(path).WithCookies(cookies ?? new { }).WithTimeout(REST_REQUEST_TIMEOUT)
                                  .WithHeaders(headers ?? new { })
                                   .PostUrlEncodedAsync(payload ?? new object());
            }
            catch (TaskCanceledException)
            {

            }
            catch (IOException)
            {

            }
        }
        public T PutJSONAsync<T>(string path, object payload = null, object headers = null, object cookies = null)
        {
            try
            {
                if (defaultHeader != null) headers = defaultHeader;

                return new Url(path).WithCookies(cookies ?? new { }).WithTimeout(REST_REQUEST_TIMEOUT)
                                   .WithHeaders(headers ?? new { })
                                          .PutJsonAsync(payload ?? new object()).ReceiveJson<T>().Result;
            }
            catch (TaskCanceledException)
            {
                return default(T);
            }
        }

        public async Task PutJSONAsync(string path, object payload = null, object headers = null,
                                                  object cookies = null)
        {
            try
            {
                if (defaultHeader != null) headers = defaultHeader;

                await new Url(path).WithCookies(cookies ?? new { }).WithTimeout(REST_REQUEST_TIMEOUT)
                                  .WithHeaders(headers ?? new { })
                                   .PutJsonAsync(payload ?? new object());
            }
            catch (TaskCanceledException)
            {

            }
            catch (IOException)
            {

            }
        }
        public T DeleteAsync<T>(string path,
                               object queryParams = null, object headers = null,
                              object cookies = null)
        {
            try
            {
                headers = defaultHeader;

                return new Url(path)
                         .SetQueryParams(queryParams ?? new { })
                    .WithCookies(cookies ?? new { }).WithTimeout(REST_REQUEST_TIMEOUT)
                                   .WithHeaders(headers ?? new { })
                    .DeleteAsync().ReceiveJson<T>().Result;
            }
            catch (TaskCanceledException)
            {
                return default(T);
            }
            catch (IOException)
            {
                return default(T);
            }
        }
        public async Task DeleteAsync(string path,
                               object queryParams = null, object headers = null,
                              object cookies = null)
        {
            try
            {
                if (defaultHeader != null) headers = defaultHeader;

                await new Url(path)
                   .SetQueryParams(queryParams ?? new { }).WithTimeout(REST_REQUEST_TIMEOUT)
                   .WithCookies(cookies ?? new { })
                                  .WithHeaders(headers ?? new { })
                                         .DeleteAsync();
            }
            catch (TaskCanceledException)
            {

            }
            catch (IOException)
            {

            }
        }
        public async Task<byte[]> GetBytesAsync(string path,
                               object queryParams = null, object headers = null,
                              object cookies = null)
        {
            try
            {
                if (defaultHeader != null) headers = defaultHeader;

                return await new Url(path)
                   .SetQueryParams(queryParams ?? new { }).WithTimeout(REST_REQUEST_TIMEOUT)
                   .WithCookies(cookies ?? new { })
                    .WithHeaders(headers ?? new { })
                    .GetBytesAsync();
            }
            catch (TaskCanceledException)
            {
                return default(byte[]);
            }
            catch (IOException)
            {
                return default(byte[]);
            }
        }

    }
}
