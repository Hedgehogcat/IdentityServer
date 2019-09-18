using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IdentityMvc2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using System.Net.Http;
using System.Net.Http.Headers;
using IdentityModel.Client;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Globalization;

namespace IdentityMvc2.Controllers
{
    public class HomeController : Controller
    {
       // public IHttpClientFactory HttpClientFactory { get; }

        public HomeController()
        {
            //HttpClientFactory = httpClientFactory;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }
        [Authorize]
        public IActionResult About()
        {
            return View();
        }
        [Authorize]
        public async Task<IActionResult> GetIdentity()
        {
            await RefreshTokensAsync();
            var token = await HttpContext.GetTokenAsync("access_token");
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var content = await client.GetStringAsync("http://localhost:5001/api/identity");
                // var json = JArray.Parse(content).ToString();
                return Ok(new { value = content });
            }
        }

        [Authorize]
        public async Task RefreshTokensAsync()
        {
            //var authorizationServerInfo = await DiscoveryClient.GetAsync("http://localhost:5000/");
            var access_token = await HttpContext.GetTokenAsync("access_token");
            var client1 = new HttpClient();
            var disco = await client1.GetDiscoveryDocumentAsync("https://localhost:5000/");
            var tokenEndpoint = disco.TokenEndpoint;

           // var client = new TokenClient(tokenEndpoint, "mvc_code", "secret");

            var refreshToken = await HttpContext.GetTokenAsync("refresh_token");

            //var response = await client.RequestRefreshTokenAsync(refreshToken);

            var response = await client1.RequestRefreshTokenAsync(new RefreshTokenRequest
            {
                GrantType= "refresh_token",
                Address = tokenEndpoint,
                ClientId = "mvc_code",
                ClientSecret = "secret",
                RefreshToken = refreshToken
            });
            var identityToken = await HttpContext.GetTokenAsync("identity_token");
            var expiresAt = DateTime.UtcNow + TimeSpan.FromSeconds(response.ExpiresIn);
            var tokens = new[]
            {
                new AuthenticationToken
                {
                    Name = OpenIdConnectParameterNames.IdToken,
                    Value = identityToken
                },
                new AuthenticationToken
                {
                    Name = OpenIdConnectParameterNames.AccessToken,
                    Value = response.AccessToken
                },
                new AuthenticationToken
                {
                    Name = OpenIdConnectParameterNames.RefreshToken,
                    Value = response.RefreshToken
                },
                new AuthenticationToken
                {
                    Name = "expires_at",
                    Value = expiresAt.ToString("o", CultureInfo.InvariantCulture)
                }
            };
            var authenticationInfo = await HttpContext.AuthenticateAsync("Cookies");
            authenticationInfo.Properties.StoreTokens(tokens);
            await HttpContext.SignInAsync("Cookies", authenticationInfo.Principal, authenticationInfo.Properties);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public async Task Logout()
        {
            await HttpContext.SignOutAsync("Cookies");
            await HttpContext.SignOutAsync("oidc");
        }
    }
}
