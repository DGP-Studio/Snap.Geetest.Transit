using System.Text.Json.Serialization;

namespace Snap.Geetest.Transit.Controllers;

public sealed class VerificationResponse
{
    [JsonPropertyName("code")]
    public int Code { get; set; }

    [JsonPropertyName("data")]
    public VerificationResult Data { get; set; } = default!;
}