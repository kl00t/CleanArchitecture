using CleanArchitecture.Core.Models;

namespace CleanArchitecture.Infrastructure.Services;

public interface IPriceHttpClientService
{
    Task<PriceData> GetPriceData();
}