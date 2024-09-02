using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage;
using System.Security.Claims;
public class CustomAuthProvider(ILocalStorageService localStorage) : AuthenticationStateProvider
{

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var state = new AuthenticationState(new ClaimsPrincipal());

        string token = await localStorage.GetItemAsStringAsync("username");
        if (!string.IsNullOrEmpty(token))
        {
            var identity = new ClaimsIdentity(
            [
                new Claim(ClaimTypes.Name, token)
            ]);

            state = new AuthenticationState(new ClaimsPrincipal(identity));
        }

        NotifyAuthenticationStateChanged(Task.FromResult(state));

        return state;
    }
}