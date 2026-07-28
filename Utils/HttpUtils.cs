using System;
using System.Net.Http;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Common.Request;
using System.Web;

namespace Utils
{
    class HttpUtils
    {
        public static string doPostForm(string url, Dictionary<string, string> param)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    using (var multipartFormDataContent = new FormUrlEncodedContent(param))
                    {
                        Console.WriteLine(JsonConvert.SerializeObject(param));
                        var result = client.PostAsync(url, multipartFormDataContent).Result.Content.ReadAsStringAsync().Result;
                        Console.WriteLine(result);
                        return result;
                    }
                }
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        public static string doGet(string url)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    Console.WriteLine(JsonConvert.SerializeObject(url));
                    var result = client.GetAsync(url).Result.Content.ReadAsStringAsync().Result;
                    Console.WriteLine(result);
                    return result;

                }
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

         public static string doPostMultipartFormData<T>(string url, String filePath,String filename)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    // 手工构建标准 multipart 请求体，精确控制 boundary 格式和 Content-Type
                    var boundary = "Boundary" + Guid.NewGuid().ToString("N");
                    var fileBytes = System.IO.File.ReadAllBytes(filePath);
                    var ext = System.IO.Path.GetExtension(filename)?.ToLower();
                    var mimeType = ext switch
                    {
                        ".pdf"  => "application/pdf",
                        ".png"  => "image/png",
                        ".jpg" or ".jpeg" => "image/jpeg",
                        ".gif"  => "image/gif",
                        ".bmp"  => "image/bmp",
                        _      => "application/octet-stream",
                    };

                    var headerBytes = System.Text.Encoding.UTF8.GetBytes(
                        "--" + boundary + "\r\n" +
                        "Content-Disposition: form-data; name=\"file\"; filename=\"" + filename + "\"\r\n" +
                        "Content-Type: " + mimeType + "\r\n\r\n");
                    var footerBytes = System.Text.Encoding.UTF8.GetBytes(
                        "\r\n--" + boundary + "--\r\n");

                    var bodyBytes = new byte[headerBytes.Length + fileBytes.Length + footerBytes.Length];
                    Buffer.BlockCopy(headerBytes, 0, bodyBytes, 0, headerBytes.Length);
                    Buffer.BlockCopy(fileBytes, 0, bodyBytes, headerBytes.Length, fileBytes.Length);
                    Buffer.BlockCopy(footerBytes, 0, bodyBytes, headerBytes.Length + fileBytes.Length, footerBytes.Length);

                    var content = new ByteArrayContent(bodyBytes);
                    content.Headers.Remove("Content-Type");
                    content.Headers.TryAddWithoutValidation("Content-Type",
                        "multipart/form-data; boundary=" + boundary);

                    var result = client.PostAsync(url, content).Result.Content.ReadAsStringAsync().Result;
                    Console.WriteLine(result);
                    return result;
                }
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        public static string buildUrl<T>(string url,  BaseReq<T> baseReq){
             return string.Format(url,baseReq.method,baseReq.t,baseReq.key,baseReq.sign, HttpUtility.UrlEncode(baseReq.param.ToString()));
        }

    }
}
