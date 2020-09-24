using System;
using System.Net.Http;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Utils
{
    class HttpUtils
    {
        public static string doPostForm(string url ,Dictionary<string,string> param )
        { try
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
            catch(Exception e){
                return e.ToString();
            }
        }

        public static string doGet(string url )
        { try
            {
                using (var client = new HttpClient())
                {
                    Console.WriteLine(JsonConvert.SerializeObject(url));
                    var result = client.GetAsync(url).Result.Content.ReadAsStringAsync().Result;
                    Console.WriteLine(result);
                    return result;
                    
                }
            }
            catch(Exception e){
                return e.ToString();
            }
        }
    }
}
