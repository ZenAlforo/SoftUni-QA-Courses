using Newtonsoft.Json;
using RestSharp;
using RestSharpDemo;

public class Program
{
    private static void Main(string[] args)
    {
        var client = new RestClient("https://api.github.com");
        var firstRequest = new RestRequest("/users/softuni/repos", Method.Get);

        var response1 = client.Execute(firstRequest, Method.Get);

        Console.WriteLine(response1.StatusCode);

        var repoObject = JsonConvert.DeserializeObject<List<Repo>>(response1.Content);

        //// Url segmentation for getting specific things
        //var secondRequest = new RestRequest("/repos/{user}/{repo}/issues/{id}");

        //secondRequest.AddUrlSegment("user", "testnakov");
        //secondRequest.AddUrlSegment("repo", "test-nakov-repo");
        //secondRequest.AddUrlSegment("id", "1");

        //var response2 = client.Execute(secondRequest, Method.Get);

        //Console.WriteLine(response2.Content);
    }
}