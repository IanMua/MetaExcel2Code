using Newtonsoft.Json;

namespace MetaExcel2CodeForFeiShu.Resp;

public class TenantAccessTokenResp
{
    public required int code { init; get; }
    public required int expire { init; get; }
    public required string msg { init; get; }
    
    [JsonProperty("tenant_access_token")]
    public required string tenantAccessToken { init; get; }

    public TenantAccessTokenResp(int code, int expire, string msg, string tenantAccessToken)
    {
        this.code = code;
        this.expire = expire;
        this.msg = msg;
        this.tenantAccessToken = tenantAccessToken;
    }
}