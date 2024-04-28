using Newtonsoft.Json;

/// <summary>
/// 快递预估时效查询接口请求参数
/// </summary>
namespace Common.Request.Label
{
    public class BackOrderParam
    {
        /// <summary>
        ///  快递公司编码
        /// </summary>
        /// <value></value>
        public string kuaidicom;
        /// <summary>
        ///  快递单号
        /// </summary>
        /// <value></value>
        public string kuaidinum;
        /// <summary>
        ///  快递100附件类型，默认1。1：回单
        /// </summary>
        /// <value></value>
        public int imgType;
        /// <summary>
        ///  电子面单客户账户或月结账号
        /// </summary>
        /// <value></value>
        public string partnerId;
        /// <summary>
        ///  电子面单密码
        /// </summary>
        /// <value></value>
        public string partnerKey;
        /// <summary>
        ///  寄件人手机号
        /// </summary>
        /// <value></value>
        public string phone;

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
        }
    }
}