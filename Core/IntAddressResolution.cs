using Common.Request;
using Common.Request.AddressResolution;
using Utils;
using Common;
/// <summary>
/// 国际地址解析
/// </summary>
public static class IntAddressResolution{
    /// <summary>
    /// 国际地址解析
    /// </summary>
    /// <param name="param"></param>
    /// <returns></returns>
     public static string addressResolution(AddressResolutionReq<IntAddressResolutionParam> param){
        
        var request = ObjectToDictionaryUtils.ObjectToMap(param);
        
        if(request == null){
            return null;
        }
        var result = HttpUtils.doPostForm(ApiInfoConstant.INT_ADDRESS_RESOLUTION_URL,request);
        return result;
    }
}