using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

public class CustomAuthStateProvider : AuthenticationStateProvider
{

    private readonly IJSRuntime _jsRuntime;

    public CustomAuthStateProvider(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        string token;
        try
        {
            token = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "Token");
        }
        catch
        {
            token = null;
        }

        if (string.IsNullOrEmpty(token))
        {
            // Si no hay token, retornar un estado de autenticación vacío
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }
        // Leer los claims del token JWT
        var handler = new JwtSecurityTokenHandler();


        var jwtToken = handler.ReadJwtToken(token);

        var claims = jwtToken.Claims.ToList();

        // Crear una identidad con los claims
        var identity = new ClaimsIdentity(claims, "jwt");

        // Crear un ClaimsPrincipal con la identidad
        var user = new ClaimsPrincipal(identity);
        var state = new AuthenticationState(user);
        NotifyAuthenticationStateChanged(Task.FromResult(state));

        return state;

    }
}
