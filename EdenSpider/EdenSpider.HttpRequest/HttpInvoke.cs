using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace EdenSpider.HttpRequest
{
    public class HttpInvoke
    {
        /// <summary>
        /// HttpGet
        /// </summary>
        /// <param name="url"></param>
        /// <param name="charset"></param>
        /// <param name="header"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public string HttpGet(string url,Encoding charset,Dictionary<string, string> header,Dictionary<string, string> param)
        {
            string html = string.Empty;
            try
            {
                var paramStr = new StringBuilder();


                if (param != null)
                {
                    if (param.Count > 0)
                    {
                        paramStr.Append("?");
                        int i = 0;
                        foreach (var p in param)
                        {
                            if (i > 0)
                                paramStr.Append("&");
                            paramStr.AppendFormat("{0}={1}", p.Key, p.Value);
                            i += 1;
                        }
                    }
                }

                string reqUrl = url + paramStr.ToString();

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(reqUrl);

                if (header != null)
                {
                    foreach (var h in header)
                    {
                        request.Headers.Add(h.Key, h.Value);
                    }
                }


                HttpWebResponse _response = (HttpWebResponse)request.GetResponse();
                using (Stream _stream = _response.GetResponseStream())
                {
                    using (StreamReader _reader = new StreamReader(_stream, charset))
                    {
                        html = _reader.ReadToEnd();
                    }
                }
            }
            catch
            {

            }
            return html;
        }

        /// <summary>
        /// HttpPost
        /// </summary>
        /// <param name="url"></param>
        /// <param name="body"></param>
        /// <param name="contentType"></param>
        /// <param name="headers"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public string HttpPost(string url, string body, string contentType, Dictionary<string, string> headers, Dictionary<string, string> param)
        {
            try
            {
                var paramStr = new StringBuilder();

                if (param != null)
                {
                    if (param.Count > 0)
                    {
                        paramStr.Append("?");
                        int i = 0;
                        foreach (var p in param)
                        {
                            if (i > 0)
                                paramStr.Append("&");
                            paramStr.AppendFormat("{0}={1}", p.Key, p.Value);
                            i += 1;
                        }
                    }
                }

                string reqUrl = url + paramStr.ToString();

                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(reqUrl);

                if (headers != null)
                {
                    foreach (var h in headers)
                    {
                        httpWebRequest.Headers.Add(h.Key, h.Value);
                    }
                }

                httpWebRequest.ContentType = contentType;
                httpWebRequest.Method = "POST";
                httpWebRequest.Timeout = 9000;

                byte[] btBodys = Encoding.UTF8.GetBytes(body);
                httpWebRequest.ContentLength = btBodys.Length;
                httpWebRequest.GetRequestStream().Write(btBodys, 0, btBodys.Length);

                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream());
                string responseContent = streamReader.ReadToEnd();

                httpWebResponse.Close();
                streamReader.Close();
                httpWebRequest.Abort();
                httpWebResponse.Close();

                return responseContent;
            }
            catch
            {
                return "";
            }
        }
    }
}
