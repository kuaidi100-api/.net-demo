
using System.Collections;
using Newtonsoft.Json;
using System.Collections.Generic;
using Utils;
using Common;
using Common.Request.Subscribe;

public class Subscribe{


    public static string query(SubscribeReq subscribeReq){
        
        var request = ObjectToDictionaryUtils.ObjectToMap(subscribeReq);
        
        if(request == null){
            return null;
        }
        var result = HttpUtils.doPostForm(ApiInfoConstant.SUBSCRIBE_URL,request);
        return result;
    }
}   