using Common.Request;
using Common.Request.PriceQuery;
using Utils;
using Common;
/// <summary>
/// 价格查询
/// </summary>
public static class PriceQuery{
    /// <summary>
    /// 价格查询
    /// </summary>
    /// <param name="param"></param>
    /// <returns></returns>
     public static string query(BaseReq<PriceQueryParam> param){
        
        var request = ObjectToDictionaryUtils.ObjectToMap(param);
        
        if(request == null){
            return null;
        }
        var result = HttpUtils.doPostForm(ApiInfoConstant.NEW_TEMPLATE_URL,request);
        return result;
    }
}