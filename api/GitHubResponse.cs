using System.Text.Json.Serialization;

namespace Vhn.Function
{
  public class GitHubResponse
  {
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("avatar_url")]
    public string AvatarUrl { get; set; }
    [JsonPropertyName("html_url")]
    public string Url { get; set; }
    [JsonPropertyName("bio")]
    public string Bio { get; set; }
  }
}