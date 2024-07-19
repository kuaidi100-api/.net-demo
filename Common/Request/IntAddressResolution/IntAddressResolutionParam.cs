using Newtonsoft.Json;

namespace Common.Request.AddressResolution
{
    public class IntAddressResolutionParam
    {
        /// <summary>
        ///  国家/地区二字码（不区分大小写），可参考 国家/地区二字码列表附录
        /// </summary>
        /// <value></value>
        public string code;

        /// <summary>
        ///  地址
        /// </summary>
        /// <value></value>
        public string address;

        /// <summary>
        ///  语言码（不区分大小写），可参考 支持的语言列表附录。该字段决定响应的解析结果以哪种语言进行展示
        /// </summary>
        /// <value></value>
        public string language;

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
        }
    }
}