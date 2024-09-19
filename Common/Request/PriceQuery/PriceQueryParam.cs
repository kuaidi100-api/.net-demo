using Newtonsoft.Json;

/// <summary>
/// 价格查询请求参数
/// </summary>
namespace Common.Request.PriceQuery
{
    public class PriceQueryParam
    {
        /// <summary>
        ///  寄件地
        /// </summary>
        /// <value></value>
        public string sendAddr;
        /// <summary>
        ///  收件地
        /// </summary>
        /// <value></value>
        public string recAddr;
        /// <summary>
        ///  快递公司编码
        /// </summary>
        /// <value></value>
        public string kuaidicom;
        /// <summary>
        ///  重量
        /// </summary>
        /// <value></value>
        public double weight;

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
        }
    }
}