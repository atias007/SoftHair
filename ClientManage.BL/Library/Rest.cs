using Newtonsoft.Json;
using System;
using System.Collections.Specialized;
using System.Net;
using System.Runtime.Serialization;
using System.Text;

namespace ClientManage.BL.Library
{
    public enum HttpMethod
    {
        Get,
        Post,
        Put,
        Patch,
        Delete
    }

    public class RestProperties
    {
        public RestProperties()
        {
            Timeout = 10000;
            UseDefaultCredentials = true;
            Method = HttpMethod.Post;
            Headers = new NameValueCollection { { "Content-Type", "application/json; charset=utf-8" } };
            SecurityProtocol = SecurityProtocolType.Tls12;
        }

        public NameValueCollection Headers { get; private set; }

        public HttpMethod Method { get; set; }

        public int Timeout { get; set; }

        public Uri Url { get; set; }

        public SecurityProtocolType SecurityProtocol { get; set; }

        public bool UseDefaultCredentials { get; set; }

        public bool UseDefaultProxy { get; set; }

        public string GetWebClientMethod()
        {
            return Method.ToString().ToUpper();
        }
    }

    public static class Rest
    {
        public static TResponse Call<TRequest, TResponse>(TRequest request, RestProperties properties)
            where TResponse : class
            where TRequest : class
        {
            var jsonRequest = JsonConvert.SerializeObject(request);
            var jsonResponse = Call(jsonRequest, properties);
            try
            {
                var result = JsonConvert.DeserializeObject<TResponse>(jsonResponse);
                return result;
            }
            catch (Exception ex)
            {
                throw new RestException($"Error while deserialize JSON response to '{typeof(TResponse).Name}' type", ex, jsonResponse);
            }
        }

        public static TResponse Call<TResponse>(RestProperties properties)
            where TResponse : class
        {
            var jsonResponse = Call(null, properties);
            try
            {
                var result = JsonConvert.DeserializeObject<TResponse>(jsonResponse);
                return result;
            }
            catch (Exception ex)
            {
                throw new RestException($"Error while deserialize JSON response to '{typeof(TResponse).Name}' type", ex, jsonResponse);
            }
        }

        public static string Call(string request, RestProperties properties)
        {
            if (properties == null) { throw new NullReferenceException("properties is null"); }
            if (request == null && properties.Method != HttpMethod.Get) { throw new NullReferenceException($"request is null while method is {properties.Method}"); }

            try
            {
                // *** http://www.asp.net/web-api/overview/advanced/calling-a-web-api-from-a-net-client ***
                using (var client = new SoftHairWebClient())
                {
                    client.UseDefaultCredentials = properties.UseDefaultCredentials;

                    if (properties.UseDefaultProxy)
                    {
                        client.Proxy = new WebProxy("172.18.18.20", 8085);
                    }

                    client.Timeout = properties.Timeout;
                    client.Headers.Add(properties.Headers);

                    ServicePointManager.SecurityProtocol = properties.SecurityProtocol;

                    var bytesData = request == null ? null : Encoding.UTF8.GetBytes(request);
                    string jsonResponse;
                    if (properties.Method == HttpMethod.Get)
                    {
                        var bytesResponse = client.DownloadData(properties.Url);
                        jsonResponse = Encoding.UTF8.GetString(bytesResponse);
                    }
                    else
                    {
                        var method = properties.GetWebClientMethod();
                        var bytesResponse = client.UploadData(properties.Url, method, bytesData);
                        jsonResponse = Encoding.UTF8.GetString(bytesResponse);
                    }

                    return jsonResponse;
                }
            }
            catch (WebException webEx)
            {
                if (webEx.Status == WebExceptionStatus.Timeout)
                {
                    throw new Exception(string.Format("REST Service '{0}' has an timeout exception", properties.Url));
                }
                else
                {
                    throw new Exception(string.Format("REST Service '{1}' has an exception: {0} with status {2}", webEx.Message, properties.Url, webEx.Status));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("REST Service '{1}' has an exception: {0}", ex.Message, properties.Url));
            }
        }
    }

    [Serializable]
    public class RestException : Exception
    {
        public RestException()
            : base()
        {
        }

        public RestException(string message)
            : base(message)
        {
        }

        public RestException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public RestException(string message, Exception innerException, string jsonResponse)
            : base(message, innerException)
        {
            JsonResponse = jsonResponse;
        }

        protected RestException(SerializationInfo serializationInfo, StreamingContext streamingContext)
                                    : base(serializationInfo, streamingContext)
        {
        }

        public string JsonResponse { get; private set; }

        public override Exception GetBaseException()
        {
            return base.GetBaseException();
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }

    public class SoftHairWebClient : WebClient
    {
        public int Timeout { get; set; }

        protected override WebRequest GetWebRequest(Uri address)
        {
            var request = base.GetWebRequest(address);
            request.Timeout = Timeout;
            return request;
        }
    }
}