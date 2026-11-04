using Infrastructure.Constants;
using Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Contexts
{
    //We impplement the IEntityTypeConfiguration interface for each entity type we want to configure.
    //This allows us to define the configuration for each entity type in a separate class,
    //which can help keep our code organized and maintainable.
    public class ApplicationUserConfig : IEntityTypeConfiguration<ApplicationUser>
    {
        //We are naming our database and giving them a schema
        //Adding index and constraints to the database tables
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.ToTable("Users", SchemaNames.Identity);

            //builder.Property(u => u.FirstName)
            //    .HasMaxLength(100);

            //builder.Property(u => u.LastName)
            //    .HasMaxLength(100);

            //builder.Property(u => u.RefreshToken)
            //    .HasMaxLength(500);

            //builder.Property(u => u.RefreshTokenExpiryTime)
            //    .HasColumnType("datetime2");

            //builder.Property(u => u.IsActive)
            //    .IsRequired();


        }
    }

    public class ApplicationRoleClaimConfig : IEntityTypeConfiguration<ApplicationRoleClaim>
    {
        public void Configure(EntityTypeBuilder<ApplicationRoleClaim> builder)
        {
            builder.ToTable("RoleClaims", SchemaNames.Identity);
        }
    }

    public class ApplicationUserRoleConfig : IEntityTypeConfiguration<ApplicationRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationRole> builder)
        {
            builder.ToTable("UserRoles", SchemaNames.Identity);

            builder.Property(r => r.Description)
                .HasMaxLength(250);

        }
    }

    public class ApplicationUserLoginConfig : IEntityTypeConfiguration<IdentityUserLogin<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserLogin<string>> builder)
        {
            builder.ToTable("UserLogins", SchemaNames.Identity);
        }
    }

    public class ApplicationUserTokenConfig : IEntityTypeConfiguration<IdentityUserToken<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserToken<string>> builder)
        {
            builder.ToTable("UserTokens", SchemaNames.Identity);
        }
    }

    public class ApplicationUserClaimConfig : IEntityTypeConfiguration<IdentityUserClaim<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserClaim<string>> builder)
        {
            builder.ToTable("UserClaims", SchemaNames.Identity);
        }
    }


}