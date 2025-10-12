using FirstApp.MAUIRepository.Login;
using FirstApp.MAUIRepository.Weather;

namespace FirstApp.Interface;

public interface IRepositoryMAUI
{
    WeatherRepositoryMAUI Weather { get; }
    LoginRepositoryMAUI Login { get; }
}
