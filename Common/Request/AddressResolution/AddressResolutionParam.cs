using Newtonsoft.Json;

namespace Common.Request.AddressResolution
{
    public class AddressResolutionParam
    {
        /// <summary>
        ///  需要解析的内容，例如：张三广东省深圳市南山区粤海街道科技南十二路金蝶软件园13088888888
        /// </summary>
        /// <value></value>
        public string content;

        /// <summary>
        ///  图片base64编码
        /// </summary>
        /// <value></value>
        public string image;

        /// <summary>
        ///  图片url
        /// </summary>
        /// <value></value>
        public string imageUrl;

        /// <summary>
        ///  pdf文件url
        /// </summary>
        /// <value></value>
        public string pdfUrl;

        /// <summary>
        ///  html文件url
        /// </summary>
        /// <value></value>
        public string htmlUrl;

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
        }
    }
}