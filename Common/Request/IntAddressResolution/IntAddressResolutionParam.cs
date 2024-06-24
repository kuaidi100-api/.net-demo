using Newtonsoft.Json;

namespace Common.Request.AddressResolution
{
    public class IntAddressResolutionParam
    {
        /// <summary>
        ///  国家
        /// </summary>
        /// <value></value>
        public string country;

        /// <summary>
        ///  地址
        /// </summary>
        /// <value></value>
        public string address;

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
        }
    }
}