using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Nsi.SDK;
using NsiSDK;
using NSISDK.Application.Client;
using NSISDK.Application.Models;
using Refit;


namespace NsiTestSdk.Controllers;

public class PostController() : ControllerBase
{
    [HttpPost("create")]
    public async Task<IActionResult> CreatePost(PostCreateRequestModel request)
    {
        var httpClient = new HttpClient
        {
            BaseAddress = new Uri("http://localhost:5030")
        };

        var api = RestService.For<INsiApi>(httpClient);
        var client = new NsiClient(api);

        var headers = new Dictionary<string, string>
        {
            { "X-Nsi-Username", "test@gmail.com" },
            { "X-Nsi-Password", "test1" }
        };

        var result = await client.CreateProductAsync(new PostCreateRequestModel(request.Name, request.Content),
            headers);

        return Ok(result);
    }
}