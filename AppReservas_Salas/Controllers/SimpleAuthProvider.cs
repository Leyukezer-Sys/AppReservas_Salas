//controllers/simpleauthprovider.cs
namespace AppReservas_Salas.Controllers
{
    using System.Security.Claims;
    using Microsoft.AspNetCore.Components.Authorization;

    public class SimpleAuthProvider : AuthenticationStateProvider
    {
        private ClaimsPrincipal _usuarioAtual = new ClaimsPrincipal(new ClaimsIdentity());

        public void Autenticar(string nomeUsuario, string tipoUsuario)
        {
            var claims = new[]
            {
            new Claim(ClaimTypes.Name, nomeUsuario),
            new Claim(ClaimTypes.Role, tipoUsuario)
        };

            var identidade = new ClaimsIdentity(claims, "SimpleAuth");
            _usuarioAtual = new ClaimsPrincipal(identidade);
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            return Task.FromResult(new AuthenticationState(_usuarioAtual));
        }

        public void Deslogar()
        {
            var anonimo = new ClaimsPrincipal(new ClaimsIdentity());
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(anonimo)));
        }

    }

}
