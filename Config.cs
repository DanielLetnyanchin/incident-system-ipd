using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace Marvin.IDP
{
    public static class Config
    {
        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "a64549d1-8879-4c1f-ac89-e123fe633ad6",
                    Username = "caitlin_cleric@erathia.com",
                    Password = "caitlin_cleric@erathia.com",
                    Claims = new List<Claim>
                    {
                        new Claim("email", "caitlin_cleric@erathia.com"),
                        new Claim("name", "Caitlin Cleric"),
                        new Claim("role", "Manager")
                    }
                },
                new TestUser
                {
                    SubjectId = "be939226-9038-4f43-950f-2e860b34d377",
                    Username = "solmyr_wizard@bracada.com",
                    Password = "solmyr_wizard@bracada.com",
                    Claims = new List<Claim>
                    {
                        new Claim("email", "solmyr_wizard@bracada.com"),
                        new Claim("name", "Solmyr Wizard"),
                        new Claim("role", "Manager")
                    }
                },
                new TestUser
                {
                    SubjectId = "fff78b47-c7b7-4983-bbf3-dee164e296ef",
                    Username = "sandro_necromancer@deyja.com",
                    Password = "sandro_necromancer@deyja.com",
                    Claims = new List<Claim>
                    {
                        new Claim("email", "sandro_necromancer@deyja.com"),
                        new Claim("name", "Sandro Necromancer"),
                        new Claim("role", "User")
                    }
                },
                new TestUser
                {
                    SubjectId = "4a590433-7b90-4894-84d2-2c73325bfb5f",
                    Username = "pasis_planeswalker@conflux.com",
                    Password = "pasis_planeswalker@conflux.com",
                    Claims = new List<Claim>
                    {
                        new Claim("email", "pasis_planeswalker@conflux.com"),
                        new Claim("name", "Pasis Planeswalker"),
                        new Claim("role", "User")
                    }
                }
            };
        }

        public static List<IdentityResource> GetIdentityResources()
        {

            return new List<IdentityResource>
            {
               new IdentityResources.OpenId(),
               new IdentityResources.Profile(),
               new IdentityResource("roles", "Your role(s)", new []{"role"})
            };
        }

        internal static IEnumerable<ApiResource> GetApiResources()
        {
            return new[] {
                new ApiResource("incidentmanagementapi", "Incident System API", new[] { "role", "name", "email" })
            };
        }

        public static List<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientName = "Incident Management",
                    ClientId="incidentmanagementclient",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    RequireConsent = false,
                    AllowAccessTokensViaBrowser = true,
                    RedirectUris =new List<string>
                    {
                        "https://localhost:4200/signin-oidc",
                        "https://localhost:4200/redirect-silentrenew"
                    },
                    AccessTokenLifetime = 180,
                    PostLogoutRedirectUris = new[]{
                        "https://localhost:4200/" },
                    AllowedScopes = new []
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "roles",
                        "incidentmanagementapi"
                    }
                }
            };
        }
    }
}
