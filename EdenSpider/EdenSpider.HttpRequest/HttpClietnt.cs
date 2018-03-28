using System;
using System.IO;
using System.Net;
using System.Text;

namespace EdenSpider.HttpRequest
{
    public class HttpClietnt
    {
        public string GetHtml(string url)
        {
            try
            {
                HttpWebRequest req;
                HttpWebResponse response;
                Stream stream;
                req = (HttpWebRequest)WebRequest.Create(url);
                req.ProtocolVersion = HttpVersion.Version11;
                req.Timeout = 3 * 1000;
                req.ReadWriteTimeout = 3000;
                req.Method = "GET";
                req.Proxy = null;
                req.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
                req.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/49.0.2623.75 Safari/537.36";//"Googlebot|Feedfetcher-Google|Baiduspider";
                using (response = (HttpWebResponse)req.GetResponse())
                {
                    using (stream = response.GetResponseStream())
                    {
                        int count = 0;
                        byte[] buf = new byte[1024];
                        string decodedString = null;
                        string decodedGBK = null;
                        StringBuilder sb = new StringBuilder();
                        StringBuilder sbGBK = new StringBuilder();
                        do
                        {
                            count = stream.Read(buf, 0, buf.Length);
                            if (count > 0)
                            {
                                decodedString = Encoding.UTF8.GetString(buf, 0, count);
                                sb.Append(decodedString);
                                decodedGBK = Encoding.Default.GetString(buf, 0, count);
                                sbGBK.Append(decodedGBK);
                            }
                        } while (count > 0);
                        if (sb.ToString().Contains("charset=utf-8") || sb.ToString().Contains("charset=\"utf-8\""))
                            return sb.ToString();
                        else
                            return sbGBK.ToString();
                    }
                }
            }
            catch (IOException ioex)
            {
                //if (ioex.Message.Contains("关闭"))
                //    new Interlinking().ModernReset();
                return GetHtml(url);
            }
            catch (Exception ex)
            {
                return null;//GetHtmlByHttp(url);
            }
        }
    }
}
