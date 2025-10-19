using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

public enum SwipeDirection
{
    None,
    LeftToRight,
    RightToLeft,
    TopToBottom,
    BottomToTop
}