using Common.Request.Electronic;
using Newtonsoft.Json;

/// <summary>
/// 订单拦截接口请求参数
/// </summary>
namespace Common.Request.Label
{
    public class InterceptOrderParam
    {
        /// <summary>
        /// 订单id        
        /// <summary>
        ////// <value></value>
        public string orderId;
        /// <summary>
        /// 快递公司编码        
        /// <summary>
        ////// <value></value>
        public string kuaidicom;
        /// <summary>
        /// 订单id        
        /// <summary>
        ////// <value></value>
        public string kuaidinum;
        /// <summary>
        /// 电子面单客户账户或月结账号，需贵司向当地快递公司网点申请（参考电子面单申请指南）； 是否必填该属性，请查看参数字典        
        /// <summary>
        ////// <value></value>
        public string partnerId;
        /// <summary>
        /// 电子面单密码，需贵司向当地快递公司网点申请； 是否必填该属性，请查看参数字典        
        /// <summary>
        ////// <value></value>
        public string partnerKey;
        /// <summary>
        /// 电子面单密钥，需贵司向当地快递公司网点申请； 是否必填该属性，请查看参数字典        
        /// <summary>
        ////// <value></value>
        public string partnerSecret;
        /// <summary>
        /// 电子面单账号，        
        /// <summary>
        ////// <value></value>
        public string partnerName;
        /// <summary>
        /// 电子面单承载编号，需贵司向当地快递公司网点申请； 是否必填该属性，请查看参数字典        
        /// <summary>
        ////// <value></value>
        public string code;
        /// <summary>
        /// 收件网点名称,由快递公司当地网点分配， 若使用淘宝授权填入（taobao），使用菜鸟授权填入（cainiao), 使用京东授权填入（jdalpha),使用拼多多授权填入(pinduoduoWx)。 是否必填该属性，请查看参数字典 （若通过第三方授权方式获取单号partnerId,partnerKey参数为必填,参数值可通过第三方授权接口获取)        
        /// <summary>
        ////// <value></value>
        public string net;
        /// <summary>
        /// 拦截原因        
        /// <summary>
        ////// <value></value>
        public string reason;
        /**
        * 拦截类型
        * RETURN_SEND_STATION  退回寄件网点
        * RETURN_SEND_ADDR  退回寄件地址
        * MODIFY_ADDR 修改地址
        */
        public string interceptType;
        /// <summary>
        /// 收件人地址        
        /// <summary>
        ////// <value></value>
        public ManInfo recManInfo;

        /// <summary>
        /// 发起方1 寄方 2收方3 第三方        
        /// <summary>
        ////// <value></value>
        public string orderRole;
        /**
        * 付款方式
        * SHIPPER 寄付
        * CONSIGNEE 到付
        * THIRDPARTY 第三方月结
        * MONTHLY 寄付月结
        */
        public string interceptPayType;
        /// <summary>
        /// 回调加密参数        
        /// <summary>
        ////// <value></value>
        public string salt;
        /// <summary>
        /// 拦截结果回调地址        
        /// <summary>
        ////// <value></value>
        public string callbackUrl;
        /// <summary>
        /// 中通服务商拦截模式需要传入appKey        
        /// <summary>
        ////// <value></value>
        public string appKey;
        /// <summary>
        /// 中通服务商拦截模式需要传入appSecret        
        /// <summary>
        ////// <value></value>
        public string appSecret;

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
        }
    }
}