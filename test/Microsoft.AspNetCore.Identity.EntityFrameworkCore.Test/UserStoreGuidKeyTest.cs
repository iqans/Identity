// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Microsoft.AspNetCore.Identity.EntityFrameworkCore.Test
{
    public class GuidUser : IdentityUser<Guid>
    {
        public GuidUser()
        {
            Id = Guid.NewGuid();
            UserName = Id.ToString();
        }
    }

    public class GuidRole : IdentityRole<Guid>
    {
        public GuidRole()
        {
            Id = Guid.NewGuid();
            Name = Id.ToString();
        }
    }

    public class UserStoreGuidTest : SqlStoreTestBase<GuidUser, GuidRole, Guid>
    {
        public UserStoreGuidTest(ScratchDatabaseFixture fixture)
            : base(fixture)
        {
        }

        public class ApplicationUserStore : UserStore<GuidUser, GuidRole, TestDbContext, Guid>
        {
            public ApplicationUserStore(TestDbContext context) : base(context) { }
        }

        public class ApplicationRoleStore : RoleStore<GuidRole, TestDbContext, Guid>
        {
            public ApplicationRoleStore(TestDbContext context) : base(context) { }
        }

        protected override void AddUserStore(IServiceCollection services, object context = null)
        {
            services.AddSingleton<IUserStore<GuidUser>>(new ApplicationUserStore((TestDbContext)context));
        }

        protected override void AddRoleStore(IServiceCollection services, object context = null)
        {
            services.AddSingleton<IRoleStore<GuidRole>>(new ApplicationRoleStore((TestDbContext)context));
        }
    }
}