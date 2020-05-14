// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityModel;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace TCM.IdentityServer.Core
{
    public class TestUsers
    {
        public static List<TestUser> Users = new List<TestUser>
        {
            new TestUser{
                SubjectId = "050f9248-492e-4325-924e-103953fc1452", 
                Username = "admin", 
                Password = "admin", 
                Claims = {
                    new Claim(JwtClaimTypes.GivenName, "admin")
                }
            }
        };
    }
}