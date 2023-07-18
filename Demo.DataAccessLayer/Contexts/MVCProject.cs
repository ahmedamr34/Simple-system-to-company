using Demo.DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccessLayer.Contexts
{
    public class MVCProject : IdentityDbContext<ApplicationUser>
    {

        public MVCProject(DbContextOptions<MVCProject> options):base(options)
        {

        }

        public DbSet<Department> departments { get; set; }
        public DbSet<Employee> employees { get; set; }

    }
}


