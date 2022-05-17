using Newtonsoft.Json;

namespace  Common.Request.Electronic.ocr
{
    public class OcrParam
    {
     /// <summary>
     /// 图像数据，base64编码，要求base64编码后大小不超过4M,支持jpg/jpeg/png/bmp格式
     /// </summary>
     /// <value></value>
    public string image {get; set;}
    /// <summary>
    /// 是否兼容图像倾斜，true：是；false：否，默认不检测，即：false
    /// </summary>
    /// <value></value>
    public bool enableTilt {get; set;}

     public override string ToString()
        {
            return JsonConvert.SerializeObject(this,Formatting.Indented,new JsonSerializerSettings(){NullValueHandling = NullValueHandling.Ignore});
        }
    }
}