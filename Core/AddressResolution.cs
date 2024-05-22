using Common.Request;
using Common.Request.AddressResolution;
using Utils;
using Common;
/// <summary>
/// 地址解析
/// </summary>
public static class AddressResolution{
    /// <summary>
    /// 地址解析
    /// </summary>
    /// <param name="param"></param>
    /// <returns></returns>
     public static string addressResolution(AddressResolutionReq<AddressResolutionParam> param){
        
        var request = ObjectToDictionaryUtils.ObjectToMap(param);
        
        if(request == null){
            return null;
        }
        var result = HttpUtils.doPostForm(ApiInfoConstant.ADDRESS_RESOLUTION_URL,request);
        return result;
    }
}