using Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Contexts
{
    //Creating application DB and extending the IdentityDbContext class to use our custom ApplicationUser and ApplicationRole classes.
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser, ApplicationRole, string,IdentityUserClaim<string>, IdentityUserRole<string>, IdentityUserLogin<string>, ApplicationRoleClaim, IdentityUserToken<string>>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //Scan the assembly and find all the classes that implement IEntityTypeConfiguration and apply their configurations to the model builder.
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            

        }
    }
}
