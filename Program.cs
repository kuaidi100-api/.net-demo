﻿
using System;
using Common;
using Common.Request;
using Common.Request.Subscribe;
using Utils;
using Newtonsoft.Json;
using Common.Request.Electronic.Image;
using Common.Request.Electronic.Html;
using Common.Request.Electronic;
using Common.Request.Electronic.Print;
using Common.Request.Sms;
using Common.Request.Border;
using System.Collections;

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
        //testSubscribe();
        // testPrintImg();
        // testPrintHtml();
        // testPrintCloud();
        // testSendSms();
        // testAutoNum();
        // testBOrderQuery();
        // testBOrder();
        // testBOrderGetCode();
        // testBOrderCancel();
    }

    /// <summary>
    /// 查询物流轨迹
    /// </summary>
    static void testQueryTrack()
    {
        var queryTrackParam = new QueryTrackParam(){
            com = "zhongtong",
            num = "75374767693697",
            phone = "15999998256"
        };
        
        QueryTrack.query(new QueryTrackReq()
        {
            customer = config.customer,
            sign = SignUtils.GetMD5(queryTrackParam.ToString() + config.key + config.customer),
            param =  queryTrackParam
        });
    }

    /// <summary>
    /// 订阅
    /// </summary>
    static void testSubscribe()
    {
        var subscribeParameters = new SubscribeParameters(){
            phone = "15999998256",
            resultv2 = "1",
            callbackurl = "http://www.xxxx.com"
        };

        var subscribeParam = new SubscribeParam(){
            company = "zhongtong",
            number = "75374767693697",
            key = config.key,
            parameters = subscribeParameters
        };
        
        Subscribe.query(new SubscribeReq()
        {
            schema = ApiInfoConstant.SUBSCRIBE_SCHEMA,
            param =  subscribeParam,
        });
    }

    /// <summary>
    /// 电子面单图片接口
    /// </summary>
    static void testPrintImg()
    {
        var printImgParam = new PrintImgParam(){
            kuaidicom = "zhaijisong",
            sendManName = "张三",
            sendManMobile = "15999998256",
            sendManPrintAddr = "广东省深圳市南山区科技南十二路",
            recManName = "李四",
            recManMobile = "15999998256",
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
        var printHtmlParam = new PrintHtmlParam(){
            kuaidicom = "zhaijisong",
            sendMan = new ManInfo()
            {
                name = "张三",
                mobile = "15999998256",
                printAddr = "广东省深圳市南山区科技南十二路",
            },
            recMan = new ManInfo()
            {
                name = "李四",
                mobile = "15999998256",
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
        var printCloudParam = new PrintCloudParam(){
            kuaidicom = "zhaijisong",
            sendMan = new ManInfo()
            {
                name = "张三",
                mobile = "15999998256",
                printAddr = "广东省深圳市南山区科技南十二路",
            },
            recMan = new ManInfo()
            {
                name = "李四",
                mobile = "15999998256",
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
        content.Add("username","测试用户");

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
        AutoNum.query("773039762404825",config.key);
    }

    /// <summary>
    /// 商家寄件查询运力
    /// </summary>
    static void testBOrderQuery()
    {
        var timestamp = DateUtils.GetTimestamp();
        var baseParam = new BOrderQueryParam(){
            sendAddr = "福田区华强北"
        };
        BaseReq<BOrderQueryParam> baseReq = new BaseReq<BOrderQueryParam>()
        {
            key = config.key,
            t = timestamp,
            sign = SignUtils.GetMD5(baseParam.ToString() + timestamp + config.key + config.secret),
            param = baseParam
        };
        Border.transportCapacity(baseReq);
    }

    /// <summary>
    /// 商家寄件下单
    /// 注意保存一下返回值(taskId和orderId),用于获取验证码或者取消订单
    /// </summary>
    static void testBOrder()
    {
        var timestamp = DateUtils.GetTimestamp();
        var baseParam = new BOrderParam(){
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
            callBackUrl = "http://www.baidu.com",
            serviceType = "标准快递"
        };
        BaseReq<BOrderParam> baseReq = new BaseReq<BOrderParam>()
        {
            key = config.key,
            t = timestamp,
            sign = SignUtils.GetMD5(baseParam.ToString() + timestamp + config.key + config.secret),
            param = baseParam
        };
        Border.order(baseReq);
    }

    /// <summary>
    /// 商家寄件获取验证码
    /// 入参为下单接口返回的taskId和orderId
    /// </summary>
    static void testBOrderGetCode()
    {
        var timestamp = DateUtils.GetTimestamp();
        var baseParam = new BOrderGetCodeParam(){
            taskId = "15BABC55F7666****6ECEEDD70F0CB6E",
            orderId = "100012****78934"
        };
        BaseReq<BOrderGetCodeParam> baseReq = new BaseReq<BOrderGetCodeParam>()
        {
            key = config.key,
            t = timestamp,
            sign = SignUtils.GetMD5(baseParam.ToString() + timestamp + config.key + config.secret),
            param = baseParam
        };
        Border.getCode(baseReq);
    }

    /// <summary>
    /// 商家寄件取消寄件
    /// 入参为下单接口返回的taskId和orderId
    /// </summary>
    static void testBOrderCancel()
    {
        var timestamp = DateUtils.GetTimestamp();
        var baseParam = new BOrderCancelParam(){
            taskId = "15BABC55F7666****6ECEEDD70F0CB6E",
            orderId = "100012****78934",
            cancelMsg = "测试单"
        };
        BaseReq<BOrderCancelParam> baseReq = new BaseReq<BOrderCancelParam>()
        {
            key = config.key,
            t = timestamp,
            sign = SignUtils.GetMD5(baseParam.ToString() + timestamp + config.key + config.secret),
            param = baseParam
        };
        Border.cancel(baseReq);
    }
}