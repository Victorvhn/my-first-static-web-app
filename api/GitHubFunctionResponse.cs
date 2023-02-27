namespace Vhn.Function
{
  public class GitHubFunctionResponse
  {
    public GitHubFunctionResponse(GitHubResponse gitHubResponse)
    {
      HasProfile = true;
      UserProfileData = gitHubResponse;
      Message = null;
    }

    public GitHubFunctionResponse(string message)
    {
      HasProfile = false;
      UserProfileData = null;
      Message = message;
    }

    public bool HasProfile { get; set; }
    public GitHubResponse UserProfileData { get; set; }
    public string Message { get; set; }
  }
}