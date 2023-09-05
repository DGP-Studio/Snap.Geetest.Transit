using System.Text.Json.Serialization;

namespace Snap.Geetest.Transit.Controllers;

public sealed class VerificationResult
{
    [JsonPropertyName("gt")]
    public string Gt { get; set; } = default!;

    [JsonPropertyName("challenge")]
    public string Challenge { get; set; } = default!;

    [JsonPropertyName("validate")]
    public string Validate { get; set; } = default!;
}