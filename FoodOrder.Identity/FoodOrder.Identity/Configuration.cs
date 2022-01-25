using System.Collections.Generic;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;

namespace FoodOrder.Identity
{
    public class Configuration
    {
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>()
            {
                new ApiScope("FoodOrderWebAPI", "Web API")
            };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>()
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>()
            {
                new ApiResource("FoodOrderWebAPI", "Web API", new [] {JwtClaimTypes.Name})
                {
                    Scopes = {"FoodOrderWebAPI"}
                }
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>()
            {
                new Client
                {
                    ClientId = "food-order-web-api",
                    ClientName = "FoodOrderWebAPI",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireClientSecret = false,
                    RequirePkce = true,
                    RedirectUris =
                    {
                        "https://localhost:5001/authentication/login-callback"
                    },
                    AllowedCorsOrigins =
                    {
                        "https://localhost:5001"
                    },
                    PostLogoutRedirectUris =
                    {
                        "https://localhost:5001/authentication/logout-callback"
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "FoodOrderWebAPI"
                    },
                    AllowAccessTokensViaBrowser = true
                }
            };
    }
}