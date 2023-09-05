using System.Text.Json.Serialization;

namespace Snap.Geetest.Transit.Client.Damagou;

public sealed class DamagouResponse
{
	[JsonPropertyName("msg")]
	public string Message { get; set; } = default!;

    [JsonPropertyName("data")]
    public string? Data { get; set; }

	/// <summary>
	/// 0 成功
	/// 1 错误
	/// </summary>
    [JsonPropertyName("status")]
	[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public int Status { get; set; }
}