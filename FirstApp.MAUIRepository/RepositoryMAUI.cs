using FirstApp.Interface;
using FirstApp.MAUIRepository.Login;
using FirstApp.MAUIRepository.Weather;

namespace FirstApp.MAUIRepository;

public class RepositoryMAUI : IRepositoryMAUI
{
    private readonly IHttpClientFactory _httpClientFactory;

    private WeatherRepositoryMAUI? _Weather;
    private LoginRepositoryMAUI? _Login;
    public RepositoryMAUI(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public WeatherRepositoryMAUI Weather => _Weather ??= new WeatherRepositoryMAUI(_httpClientFactory);
    public LoginRepositoryMAUI Login => _Login ??= new LoginRepositoryMAUI(_httpClientFactory);
}
