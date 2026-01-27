using CleanArchitecture.Core.Models;
using System.Net.Http.Json;
using System.Xml.Linq;

namespace CleanArchitecture.Infrastructure.Services;

public class MyHttpClientService(HttpClient httpClient) : IPriceHttpClientService
{
    public async Task<PriceData> GetPriceData()
    {
        var result = await httpClient.GetFromJsonAsync<PriceData>("somedata");
        return result is null ? throw new InvalidOperationException("Failed to retrieve PriceData from the endpoint.") : result;
    }
}