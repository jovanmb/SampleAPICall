using Newtonsoft.Json;
using SampleAPICall.Models;
using System;
using System.Net.Http;
using System.Runtime.Versioning;
using System.Threading.Tasks;

namespace SampleAPICall.Services;

public class RainfallMeasurementService
{
    private readonly HttpClient _httpClient;

    public RainfallMeasurementService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("RainfallAPI");
    }

    public async Task<Root> GetRainfallMeasurementStationsAsync()
    {
        var response = await _httpClient.GetAsync("id/stations?parameter=rainfall&_limit=50");

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var root = JsonConvert.DeserializeObject<Root>(content);

            return root!;
        }

        return new Root();
    }
}