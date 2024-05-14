using NsiSdk.Dto;
using Refit;

namespace NsiSdk;

public interface IDemoApi
{
    [Post("/api/Post/CreatePost")]
    public Task<string> CreateProductAsync(PostRequestCreateDto request);
}