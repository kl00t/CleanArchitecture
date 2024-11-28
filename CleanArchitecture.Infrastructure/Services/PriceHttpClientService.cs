using CleanArchitecture.Core.Models;
using System.Net.Http.Json;
using System.Xml.Linq;

namespace CleanArchitecture.Infrastructure.Services;

public class MyHttpClientService(HttpClient httpClient) : IPriceHttpClientService
{
    public async Task<PriceData> GetPriceData()
    {
        return await httpClient.GetFromJsonAsync<PriceData>("somedata");
    }
}