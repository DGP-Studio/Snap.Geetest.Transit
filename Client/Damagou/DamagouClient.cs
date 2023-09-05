using Snap.Geetest.Transit.Option;

namespace Snap.Geetest.Transit.Client.Damagou;

public sealed class DamagouClient
{
    private readonly HttpClient httpClient;
	private readonly AppOptions appOptions;

	public DamagouClient(HttpClient httpClient, AppOptions appOptions)
	{
		this.httpClient = httpClient;
		this.appOptions = appOptions;
	}

	public async ValueTask<DamagouResponse?> LoginAsync()
	{
		string username = appOptions.Damagou.Username;
		string password = appOptions.Damagou.Password;
		string url = $"http://www.damagou.top/apiv1/login.html?username={username}&password={password}&isJson=2";
        return await httpClient.GetFromJsonAsync<DamagouResponse>(url);
	}

    public async ValueTask<DamagouResponse?> VerifyAsync(string userKey, string gt, string challenge)
    {
		string headers = Uri.EscapeDataString("referer|https://webstatic.mihoyo.com/");
        string url = $"http://www.damagou.top/apiv1/jiyanRecognize.html?userkey={userKey}&headers={headers}&gt={gt}&challenge={challenge}&isJson=2";
        return await httpClient.GetFromJsonAsync<DamagouResponse>(url);
    }
}