// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;
using IdentityServer4;

namespace TCM.IdentityServer.Core
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> Ids =>
            new IdentityResource[]
            { 
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource(
                    "roles",
                    "Roles",
                    new List<string>() { "role" }
                    ),
                new IdentityResource(
                    "department",
                    "Department",
                    new List<string>() { "department" }
                    )
            };

        public static IEnumerable<ApiResource> Apis =>
            new ApiResource[]
            {
                new ApiResource(
                    "sampleapi",
                    "Sample API",
                    new List<string>() { "role" }
                    )
                {
                    ApiSecrets = { new Secret("password".Sha256()) }
                }
            };
        
        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    AccessTokenType = AccessTokenType.Reference,
                    AllowOfflineAccess = true,
                    UpdateAccessTokenClaimsOnRefresh = true,
                    ClientName = "Sample Client",
                    ClientId = "sampleclient",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    RedirectUris = new List<string>()
                    {
                        "https://localhost:44382/signin-oidc"
                    },
                    PostLogoutRedirectUris = new List<string>()
                    {
                        "https://localhost:44382/signout-callback-oidc"
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "roles",
                        "sampleapi"
                    },
                    ClientSecrets = {new Secret("password".Sha256()) }
                }
            };
        
    }
}