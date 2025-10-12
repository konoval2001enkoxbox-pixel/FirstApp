using FirstApp.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace FirstApp.MAUIRepository.Weather;


public class WeatherRepositoryMAUI
{
    private readonly HttpClient _httpClient;
    public WeatherRepositoryMAUI(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("MyApi");
    }
    public async Task<List<WeatherForecast>> OnInitializedAsync()
    {
        // Simulate asynchronous loading to demonstrate a loading indicator
        await Task.Delay(500);

        var startDate = DateOnly.FromDateTime(DateTime.Now);
        var summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };
        return Enumerable.Range(1, Random.Shared.Next(2, summaries.Length)).Select(index => new WeatherForecast
        {
            Date = startDate.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = summaries[Random.Shared.Next(summaries.Length)]
        }).ToList();
    }
    public async Task<List<WeatherForecast>?> SendQuery(string token)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await _httpClient.GetAsync("Weather/GetList");

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception( $"{response.StatusCode} {await response.Content.ReadAsStringAsync()}");
        }
        else
        {
            return await response.Content.ReadFromJsonAsync<List<WeatherForecast>>();
            //var result = await response.Content.ReadFromJsonAsync<LoginResponce>();
            //return result.key;
        }
    }
}
