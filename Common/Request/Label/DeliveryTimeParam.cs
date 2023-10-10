using Newtonsoft.Json;

/// <summary>
/// 快递预估时效查询接口请求参数
/// </summary>
namespace Common.Request.Label
{
    public class DeliveryTimeParam
    {
        /// <summary>
        ///  快递公司编码
        /// </summary>
        /// <value></value>
        public string kuaidicom;
        /// <summary>
        ///  出发地（地址需包含3级及以上），例如：广东深圳南山区
        /// </summary>
        /// <value></value>
        public string from;
        /// <summary>
        ///  目的地（地址需包含3级及以上），例如：北京海淀区
        /// </summary>
        /// <value></value>
        public string to;
        /// <summary>
        ///  下单时间，格式要求yyyy-MM-dd HH:mm:ss, 例如：2023-08-08 08:08:08
        /// </summary>
        /// <value></value>
        public string orderTime;
        /// <summary>
        ///  产品类型
        /// </summary>
        /// <value></value>
        public string expType;

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
        }
    }
}