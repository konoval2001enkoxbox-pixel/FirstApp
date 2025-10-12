using FirstApp.Entity.Base;
using FirstApp.MAUIRepository.Login.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace FirstApp.MAUIRepository.Login;


public class LoginRepositoryMAUI
{
    private readonly HttpClient _httpClient;
    public LoginRepositoryMAUI(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("MyApi");
    }

    public async Task<string?> LoginRequest(string login, string password)
    {
        var parameters = new FormUrlEncodedContent(
        [
                new KeyValuePair<string, string>("login", login),
                new KeyValuePair<string, string>("password", password),
            ]);

        var response = await _httpClient.PostAsync("Login/Login", parameters);

        if (!response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsStringAsync();
        }
        else
        {
            return await response.Content.ReadAsStringAsync();
            //var result = await response.Content.ReadFromJsonAsync<LoginResponce>();
            //return result.key;
        }
    }
}
