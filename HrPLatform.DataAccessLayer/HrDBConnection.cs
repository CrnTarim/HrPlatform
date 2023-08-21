using HrPlatform.Entities.Company;
using HrPlatform.Entities.Employees;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HrPLatform.DataAccessLayer
{
    public class HrDBConnection:DbContext
    {
        public HrDBConnection(DbContextOptions<HrDBConnection> opitons) : base(opitons)
        {

        }

        public DbSet<PersonalInformation> PersonalInformations { get; set; }
        public DbSet<CompanyInformation> CompanyInformations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }

    }
}
