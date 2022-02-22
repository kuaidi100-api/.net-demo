<h1 align="center"><a href="https://github.com/kuaidi100-api/.net-demo" target="_blank">.net Project</a></h1>

## Introduce

.net-demo 是由[快递100](https://api.kuaidi100.com/home)官方提供的c# sdk，方便调试使用。

.net-demo 集成了实时查询、订阅推送、智能判断、云打印相关、电子面单相关、短信等接口。

## Features

- 提供了快递100接口请求参数实体类、返回实体类。
- 提供测试类调试。

## Getting started

.net-demo使用和测试可参考[test](https://github.com/kuaidi100-api/.net-demo/blob/master/Program.cs)。

```
# git clone https://github.com/kuaidi100-api/.net-demo.git
```


### Use Junit Test

```java
class Program
{

    //快递100的基础账号信息，可以在这里获取 (需要填写完整才能测试)
    //https://poll.kuaidi100.com/manager/page/myinfo/enterprise
    private static KuaiDi100Config config = new KuaiDi100Config()
    {
        key = "",
        customer = "",
        secret = "",
        userid = "",
        siid = "",
        tid = "",
    };
    static void Main(string[] args)
    {
        // testQueryTrack();
        // testSubscribe();
        // testQueryTrackWithMap();
        // testSubscribeWithMap();
        // testPrintImg();
        // testPrintHtml();
        // testPrintCloud();
        // testSendSms();
        // testAutoNum();
        // testBOrderQuery();
        // testBOrder();
        // testBOrderCancel();
        // testInternationalShipment();
        // testCloudPrintCustom();
        // testCloudAttachment();
        // testCloudDevStatus();
        // testCloudPrintCommand();
        // testCloudPrintOld();
        // testCloudPrintParcelsBill();
        // testThirdPlatformStoreAuth();
        // testThirdPlatformCommitTask();
        // testThirdPlatformUploadNum();
        // testSameCityStoreAuth();
        // testSameCityOrder();
        // testSameCityQuery();
        // testSameCityCancel();
        testThirdPlatformAuth();
        // testThirdPlatBranchInfo();
        // testLabelCancel();

    }

    /// <summary>
    /// 轨迹物流查询
    /// </summary>
    static void testQueryTrack()
    {
        var queryTrackParam = new QueryTrackParam()
        {
            com = "zhongtong",
            num = "7537****693697",
            phone = "15****98256"
        };

        QueryTrack.query(new QueryTrackReq()
        {
            customer = config.customer,
            sign = SignUtils.GetMD5(queryTrackParam.ToString() + config.key + config.customer),
            param = queryTrackParam
        });
    }

    /// <summary>
    /// 轨迹订阅
    /// </summary>
    static void testSubscribe()
    {
        var subscribeParameters = new SubscribeParameters()
        {
            phone = "159*****256",
            resultv2 = "1",
            callbackurl = "http://www.xxxx.com"
        };

        var subscribeParam = new SubscribeParam()
        {
            company = "zhongtong",
            number = "7537****693697",
            key = config.key,
            parameters = subscribeParameters
        };

        Subscribe.subscribe(new SubscribeReq()
        {
            schema = ApiInfoConstant.SUBSCRIBE_SCHEMA,
            param = subscribeParam,
        });
    }

    /// <summary>
    /// 地图轨迹物流查询
    /// </summary>
    static void testQueryTrackWithMap()
    {
        var queryTrackParam = new QueryTrackParam()
        {
            com = "zhongtong",
            num = "7537****693697",
            phone = "159****8256",
            from = "北京海淀区",
            to = "深圳南山区"
        };

        QueryTrackWithMap.query(new QueryTrackReq()
        {
            customer = config.customer,
            sign = SignUtils.GetMD5(queryTrackParam.ToString() + config.key + config.customer),
            param = queryTrackParam
        });
    }

    /// <summary>
    /// 地图轨迹订阅
    /// </summary>
    static void testSubscribeWithMap()
    {
        var subscribeParameters = new SubscribeParameters()
        {
            phone = "159****8256",
            resultv2 = "1",
            callbackurl = "http://www.xxxx.com"
        };

        var subscribeParam = new SubscribeParam()
        {
            company = "zhongtong",
            number = "7537****3697",
            key = config.key,
            parameters = subscribeParameters,
            from = "北京海淀区",
            to = "深圳南山区"
        };

        SubscribeWithMap.subscribe(new SubscribeReq()
        {
            schema = ApiInfoConstant.SUBSCRIBE_SCHEMA,
            param = subscribeParam,
        });
    }

    /// <summary>
    /// 电子面单图片接口
    /// </summary>
    static void testPrintImg()
    {
        var printImgParam = new PrintImgParam()
        {
            kuaidicom = "zhaijisong",
            sendManName = "张三",
            sendManMobile = "159****8256",
            sendManPrintAddr = "广东省深圳市南山区科技南十二路",
            recManName = "李四",
            recManMobile = "159****8256",
            recManPrintAddr = "北京市海淀区xxx路",
            type = "10",
            tempid = "180c7c8f646742ca871a92c976392b05",
            count = "1",
            width = "76",
            height = "130",
        };

        var timestamp = DateUtils.GetTimestamp();
        PrintImg.query(new PrintImgReq()
        {
            method = ApiInfoConstant.ELECTRONIC_ORDER_PIC_METHOD,
            key = config.key,
            t = timestamp,
            sign = SignUtils.GetMD5(printImgParam.ToString() + timestamp + config.key + config.secret),
            param = printImgParam,
        });
    }

    /// <summary>
    /// 电子面单html接口
    /// </summary>
    static void testPrintHtml()
    {
        var printHtmlParam = new PrintHtmlParam()
        {
            kuaidicom = "zhaijisong",
            sendMan = new ManInfo()
            {
                name = "张三",
                mobile = "159****8256",
                printAddr = "广东省深圳市南山区科技南十二路",
            },
            recMan = new ManInfo()
            {
                name = "李四",
                mobile = "159****8256",
                printAddr = "北京市海淀区xxx路",
            },
            count = "1",
            needTemplate = "1",   //如果需要返回电子面单，需要设置
        };

        var timestamp = DateUtils.GetTimestamp();
        PrintHtml.query(new PrintHtmlReq()
        {
            method = ApiInfoConstant.ELECTRONIC_ORDER_HTML_METHOD,
            key = config.key,
            t = timestamp,
            sign = SignUtils.GetMD5(printHtmlParam.ToString() + timestamp + config.key + config.secret),
            param = printHtmlParam,
        });
    }

    /// <summary>
    /// 电子面单打印接口
    /// </summary>
    static void testPrintCloud()
    {
        var printCloudParam = new PrintCloudParam()
        {
            kuaidicom = "zhaijisong",
            sendMan = new ManInfo()
            {
                name = "张三",
                mobile = "15****98256",
                printAddr = "广东省深圳市南山区科技南十二路",
            },
            recMan = new ManInfo()
            {
                name = "李四",
                mobile = "15****98256",
                printAddr = "北京市海淀区xxx路",
            },
            count = "1",
            siid = config.siid,
            tempid = "180c7c8f646742ca871a92c976392b05",
            width = "76",
            height = "130"
        };

        var timestamp = DateUtils.GetTimestamp();
        PrintCloud.query(new PrintCloudReq()
        {
            method = ApiInfoConstant.ELECTRONIC_ORDER_PRINT_METHOD,
            key = config.key,
            t = timestamp,
            sign = SignUtils.GetMD5(printCloudParam.ToString() + timestamp + config.key + config.secret),
            param = printCloudParam,
        });
    }

    /// <summary>
    /// 发送短信
    /// </summary>
    static void testSendSms()
    {
        var content = new Hashtable();
        content.Add("username", "测试用户");

        SendSms.query(new SendSmsReq()
        {
            content = JsonConvert.SerializeObject(content),
            phone = "xxx",
            seller = "测试",
            userid = config.userid,
            tid = config.tid,
            sign = SignUtils.GetMD5(config.key + config.userid)
        });
    }

    /// <summary>
    /// 智能识别
    /// </summary>
    static void testAutoNum()
    {
        AutoNum.query("773039762404825", config.key);
    }

    /// <summary>
    /// 商家寄件查询价格
    /// </summary>
    static void testBOrderQuery()
    {
        var timestamp = DateUtils.GetTimestamp();
        var baseParam = new BOrderOfficialQueryPriceParam()
        {
            sendManPrintAddr = "福田区华强北",
            kuaidiCom = "jtexpress",
            recManPrintAddr = "北京海淀区"
        };
        BaseReq<BOrderOfficialQueryPriceParam> baseReq = new BaseReq<BOrderOfficialQueryPriceParam>()
        {
            key = config.key,
            t = timestamp,
            sign = SignUtils.GetMD5(baseParam.ToString() + timestamp + config.key + config.secret),
            param = baseParam
        };
        BOrderOfficial.queryPrice(baseReq);
    }

    /// <summary>
    /// 商家寄件下单
    /// 注意保存一下返回值(taskId和orderId),用于获取验证码或者取消订单
    /// </summary>
    static void testBOrder()
    {
        var timestamp = DateUtils.GetTimestamp();
        var baseParam = new BOrderOfficialOrderParam()
        {
            kuaidicom = "jtexpress",
            recManName = "张三",
            recManMobile = "159953225555",
            recManPrintAddr = "深圳市南山区金蝶软件园",
            sendManName = "李四",
            sendManMobile = "15333333333",
            sendManPrintAddr = "深圳福田区华强北",
            cargo = "文件",
            weight = "1",
            remark = "测试单，待会取消",
            salt = "123",
            callBackUrl = "http://www.xxxx.com",
            serviceType = "标准快递"
        };
        BaseReq<BOrderOfficialOrderParam> baseReq = new BaseReq<BOrderOfficialOrderParam>()
        {
            key = config.key,
            t = timestamp,
            sign = SignUtils.GetMD5(baseParam.ToString() + timestamp + config.key + config.secret),
            param = baseParam
        };
        BOrderOfficial.order(baseReq);
    }

    /// <summary>
    /// 商家寄件取消寄件
    /// 入参为下单接口返回的taskId和orderId
    /// </summary>
    static void testBOrderCancel()
    {
        var timestamp = DateUtils.GetTimestamp();
        var baseParam = new BOrderOfficialCancelParam()
        {
            taskId = "9406BFCD6******1E0E00D23047FFB",
            orderId = "169**740",
            cancelMsg = "测试单"
        };
        BaseReq<BOrderOfficialCancelParam> baseReq = new BaseReq<BOrderOfficialCancelParam>()
        {
            key = config.key,
            t = timestamp,
            sign = SignUtils.GetMD5(baseParam.ToString() + timestamp + config.key + config.secret),
            param = baseParam
        };
        BOrderOfficial.cancel(baseReq);
    }

    /// <summary>
    /// 国际电子面单API
    /// </summary>
    static void testInternationalShipment()
    {
        var timestamp = DateUtils.GetTimestamp();
        List<PackageInfo> packageInfoList = new List<PackageInfo>();
        var packageInfo = new PackageInfo()
        {
            length = 10.00,
            width = 20.00,
            height = 10.00,
            weight = 50.00
        };
        packageInfoList.Add(packageInfo);
        List<ExportInfo> exportInfoList = new List<ExportInfo>();
        var exportInfo = new ExportInfo()
        {
            desc = "test",
            grossWeight = 50.00,
            quantity = 1,
            quantityUnitOfMeasurement = "PCS",
            manufacturingCountryCode = "CN",
            unitPrice = 100
        };
        exportInfoList.Add(exportInfo);
        var baseParam = new ShipmentReq()
        {
            partnerId = "",
            partnerKey = "",
            partnerSecret = "",
            code = "",
            kuaidicom = "fedex",
            cargo = "invoice",
            expType = "FedEx International First®",
            unitOfMeasurement = "SU",
            weight = 50.00,
            customsValue = 1000.00,
            sendMan = new InterManInfo()
            {
                name = "test",
                mobile = "1688888888",
                countryCode = "CN",
                city = "SHENZHEN",
                addr = "Hi-tech Park,Nanshang District",
                zipcode = "518057",
                email = "TEST@QQ.COM"
            },
            recMan = new InterManInfo()
            {
                name = "test",
                mobile = "1688888888",
                countryCode = "US",
                city = "NEW YORK",
                addr = " 70 Washington Square South",
                zipcode = "10012",
                stateOrProvinceCode = "NY",
                email = "TEST@QQ.COM"
            },
            packageInfos = packageInfoList,
            exportInfos = exportInfoList,
            customsClearance = new CustomsClearance()
            {
                purpose = "GIFT",
                isDocument = true,
            }
        };
        BaseReq<ShipmentReq> baseReq = new BaseReq<ShipmentReq>()
        {
            key = config.key,
            t = timestamp,
            sign = SignUtils.GetMD5(baseParam.ToString() + timestamp + config.key + config.secret),
            param = baseParam
        };
        InternationalShipment.getLabel(baseReq);
    }

    /// <summary>
    /// 自定义打印接口
    /// </summary>
    static void testCloudPrintCustom()
    {
        var timestamp = DateUtils.GetTimestamp();
        var baseParam = new CustomParam()
        {
            tempid = "180c7c8f646742ca871a92c976392b05",
            callBackUrl = "http://www.xxxx.com",
            siid = config.siid,
        };
        BaseReq<CustomParam> baseReq = new BaseReq<CustomParam>()
        {
            key = config.key,
            t = timestamp,
            sign = SignUtils.GetMD5(baseParam.ToString() + timestamp + config.key + config.secret),
            param = baseParam
        };
        CloudPrint.custom(baseReq);
    }

    /// <summary>
    /// 云打印附件
    /// </summary>
    static void testCloudAttachment()
    {
        string filePath = "C:\\Users\\Administrator.-20171106WFEKLN\\Desktop\\2.png";
        string filename = "2.png";
        var timestamp = DateUtils.GetTimestamp();
        var baseParam = new AttachmentParam()
        {
            callBackUrl = "http://www.xxxx.com",
            siid = config.siid,
        };
        BaseReq<AttachmentParam> baseReq = new BaseReq<AttachmentParam>()
        {
            key = config.key,
            t = timestamp,
            sign = SignUtils.GetMD5(baseParam.ToString() + timestamp + config.key + config.secret),
            param = baseParam
        };
        CloudPrint.attachment(baseReq, filePath, filename);
    }

    /// <summary>
    /// 复打
    /// </summary>
    static void testCloudPrintOld()
    {

        var timestamp = DateUtils.GetTimestamp();
        var baseParam = new PrintOldParam()
        {
            taskId = "0E0D2AC5D******463DAF1DA5F9"
        };
        BaseReq<PrintOldParam> baseReq = new BaseReq<PrintOldParam>()
        {
            key = config.key,
            t = timestamp,
            sign = SignUtils.GetMD5(baseParam.ToString() + timestamp + config.key + config.secret),
            param = baseParam
        };
        CloudPrint.printOld(baseReq);
    }

    /// <summary>
    /// 指令打印接口
    /// </summary>
    static void testCloudPrintCommand()
    {

        var timestamp = DateUtils.GetTimestamp();
        var baseParam = new CommandParam()
        {
            content = "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",
            siid = config.siid
        };
        BaseReq<CommandParam> baseReq = new BaseReq<CommandParam>()
        {
            key = config.key,
            t = timestamp,
            sign = SignUtils.GetMD5(baseParam.ToString() + timestamp + config.key + config.secret),
            param = baseParam
        };
        CloudPrint.commandPrint(baseReq);
    }

    /// <summary>
    /// 发货单接口
    /// </summary>
    static void testCloudPrintParcelsBill()
    {

        var timestamp = DateUtils.GetTimestamp();
        //OrderGoods 表格对象，可以自行自定义即可，这里仅供参考
        var baseParam = new ParcelsBillsParam<OrderGoods>()
        {
            tempid = "164509714515858026",
            siid = config.siid
        };
        BaseReq<ParcelsBillsParam<OrderGoods>> baseReq = new BaseReq<ParcelsBillsParam<OrderGoods>>()
        {
            key = config.key,
            t = timestamp,
            sign = SignUtils.GetMD5(baseParam.ToString() + timestamp + config.key + config.secret),
            param = baseParam
        };
        CloudPrint.billParcels(baseReq);
    }

    /// <summary>
    /// 硬件状态接口
    /// </summary>
    static void testCloudDevStatus()
    {

        var timestamp = DateUtils.GetTimestamp();
        var baseParam = new DevStatusParam()
        {
            siid = config.siid
        };
        BaseReq<DevStatusParam> baseReq = new BaseReq<DevStatusParam>()
        {
            key = config.key,
            t = timestamp,
            sign = SignUtils.GetMD5(baseParam.ToString() + timestamp + config.key + config.secret),
            param = baseParam
        };
        CloudPrint.devStatus(baseReq);
    }

    /// <summary>
    /// 获取店铺授权超链接接口
    /// </summary>
    static void testThirdPlatformStoreAuth()
    {

        var baseParam = new StoreAuthParam()
        {
            shopType = "TAOBAO",
            callbackUrl = "http://www.xxxx.com",
            salt = "123"
        };
        BaseReq<StoreAuthParam> baseReq = new BaseReq<StoreAuthParam>()
        {
            key = config.key,
            sign = SignUtils.GetMD5(baseParam.ToString() + config.key + config.secret),
            param = baseParam
        };
        ThirdPlatformOrder.auth(baseReq);
    }

    /// <summary>
    /// 提交订单获取任务接口
    /// </summary>
    static void testThirdPlatformCommitTask()
    {

        var baseParam = new CommitTaskParam()
        {
            shopType = "TAOBAO",
            shopId = "41****377",
            orderStatus = "UNSHIP",
            updateAtMin = "2022-02-17 16:00:00",
            updateAtMax = "2022-02-17 16:30:00",
            callbackUrl = "http://www.xxxx.com",
            salt = "123"
        };
        BaseReq<CommitTaskParam> baseReq = new BaseReq<CommitTaskParam>()
        {
            key = config.key,
            sign = SignUtils.GetMD5(baseParam.ToString() + config.key + config.secret),
            param = baseParam
        };
        ThirdPlatformOrder.commitTask(baseReq);
    }

    /// <summary>
    /// 订单获取结果推送接口
    /// </summary>
    static void testThirdPlatformUploadNum()
    {

        var baseParam = new UploadNumParam()
        {
            shopType = "TAOBAO",
            shopId = "41****77",
            orderNum = "240*****8072",
            kuaidiCom = "yunda",
            kuaidiNum = "1ds23456"
        };
        BaseReq<UploadNumParam> baseReq = new BaseReq<UploadNumParam>()
        {
            key = config.key,
            sign = SignUtils.GetMD5(baseParam.ToString() + config.key + config.secret),
            param = baseParam
        };
        ThirdPlatformOrder.uploadNum(baseReq);
    }

    /// <summary>
    /// 同城配送账号授权接口
    /// </summary>
    static void testSameCityStoreAuth()
    {

        var timestamp = DateUtils.GetTimestamp();
        var baseParam = new SameCityAuthParam()
        {
            com = "shansong",
            storeId = "123456",
            callbackUrl = "http://www.xxxx.com"
        };
        BaseReq<SameCityAuthParam> baseReq = new BaseReq<SameCityAuthParam>()
        {
            key = config.key,
            t = timestamp,
            sign = SignUtils.GetMD5(baseParam.ToString() + timestamp + config.key + config.secret),
            param = baseParam
        };
        SameCity.auth(baseReq);
    }

    /// <summary>
    /// 同城配送下单
    /// </summary>
    static void testSameCityOrder()
    {

        var timestamp = DateUtils.GetTimestamp();
        var baseParam = new SameCityOrderParam()
        {
            partnerId = "199****601",
            partnerKey = "806cdf87*******dfb000326375d",
            com = "kfw",
            storeId = "123456",
            recManName = "张三",
            recManMobile = "1599*****912",
            recManPrintAddr = "深圳市南山区金蝶软件园",
            sendManName = "李四",
            sendManMobile = "153******3333",
            sendManPrintAddr = "深圳福田区华强北",
            price = 100,
            orderSourceType = "饿了么",
            weight = 1,
            remark = "测试单，待会取消",
            serviceType = "火锅",
            salt = "123",
            callbackUrl = "http://www.xxxx.com",
            orderSourceNo = "1233",
            orderType = 0

        };
        BaseReq<SameCityOrderParam> baseReq = new BaseReq<SameCityOrderParam>()
        {
            key = config.key,
            t = timestamp,
            sign = SignUtils.GetMD5(baseParam.ToString() + timestamp + config.key + config.secret),
            param = baseParam
        };
        SameCity.order(baseReq);
    }

    /// <summary>
    /// 同城配送查询订单
    /// </summary>
    static void testSameCityQuery()
    {

        var timestamp = DateUtils.GetTimestamp();
        var baseParam = new SameCityQueryParam()
        {
            taskId = "EE815B30*****2FEE0EBFEC3",
            orderId = "10003****SWiZ",
        };
        BaseReq<SameCityQueryParam> baseReq = new BaseReq<SameCityQueryParam>()
        {
            key = config.key,
            t = timestamp,
            sign = SignUtils.GetMD5(baseParam.ToString() + timestamp + config.key + config.secret),
            param = baseParam
        };
        SameCity.query(baseReq);
    }


    /// <summary>
    /// 同城配送取消下单接口
    /// </summary>
    static void testSameCityCancel()
    {

        var timestamp = DateUtils.GetTimestamp();
        var baseParam = new SameCityCancelParam()
        {
            taskId = "EE815B30B5*****B8D522FEE0EBFEC3",
            orderId = "1000****WiZ",
            cancelMsg = "地址信息填错啦，重新下单"
        };
        BaseReq<SameCityCancelParam> baseReq = new BaseReq<SameCityCancelParam>()
        {
            key = config.key,
            t = timestamp,
            sign = SignUtils.GetMD5(baseParam.ToString() + timestamp + config.key + config.secret),
            param = baseParam
        };
        SameCity.cancel(baseReq);
    }

    /// <summary>
    /// 第三方电商平台账号授权
    /// </summary>
    static void testThirdPlatformAuth()
    {

        var timestamp = DateUtils.GetTimestamp();
        var baseParam = new PlatformAuthParam()
        {
            net = "taobao",
            callbackUrl = "http://www.xxx.com"
        };
        BaseReq<PlatformAuthParam> baseReq = new BaseReq<PlatformAuthParam>()
        {
            key = config.key,
            t = timestamp,
            sign = SignUtils.GetMD5(baseParam.ToString() + timestamp + config.key + config.secret),
            param = baseParam
        };
        ThirdPlatformOrder.platformAuth(baseReq);
    }

    /// <summary>
    /// 第三方平台面单余额接口
    /// </summary>
    static void testThirdPlatBranchInfo()
    {

        var timestamp = DateUtils.GetTimestamp();
        var baseParam = new BranchInfoParam()
        {
            partnerId = "343****2875",
            partnerKey = "6201d13dee73*********557aa3431402875",
            net = "taobao"
        };
        BaseReq<BranchInfoParam> baseReq = new BaseReq<BranchInfoParam>()
        {
            key = config.key,
            t = timestamp,
            sign = SignUtils.GetMD5(baseParam.ToString() + timestamp + config.key + config.secret),
            param = baseParam
        };
        ThirdPlatformOrder.branchInfo(baseReq);

    }

    /// <summary>
    /// 电子面单取消接口
    /// </summary>
    static void testLabelCancel()
    {

        var timestamp = DateUtils.GetTimestamp();
        var baseParam = new CancelPrint()
        {
            partnerId = "",
            partnerKey = "",
            net = "",
            kuaidicom = "shunfeng",
            kuaidinum = "SF136*****3507",
            orderId = "016455*****25zosNIq",
            reason = "地址错误"
        };
        BaseReq<CancelPrint> baseReq = new BaseReq<CancelPrint>()
        {
            key = config.key,
            t = timestamp,
            sign = SignUtils.GetMD5(baseParam.ToString() + timestamp + config.key + config.secret),
            param = baseParam
        };
        PrintCloud.cancel(baseReq);

    }
}
```
