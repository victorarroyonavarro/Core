using Core.Web.Models.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Web.Data
{
    public class ApplicationDbContext: IdentityDbContext<Usuario,Rol,string>
    {

        private readonly IConfiguration _conf;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration conf)
            : base(options)
        {
            _conf = conf;
        }

        public ApplicationDbContext(IConfiguration conf)
        {
            _conf = conf;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.HasDefaultSchema(_conf.GetValue<string>("schema"));

            /*Identity*/

            builder.Entity<Usuario>().ToTable("Usuarios");
            builder.Entity<Rol>().ToTable("Roles");
            builder.Entity<IdentityUserRole<string>>().ToTable("PerfilesUsuario");


            /* Configurar Modelos */






        }


    }
}
