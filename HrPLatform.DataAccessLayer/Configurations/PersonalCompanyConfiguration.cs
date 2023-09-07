using HrPlatform.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrPLatform.DataAccessLayer.Configurations
{
    public class PersonalCompanyConfiguration : IEntityTypeConfiguration<PersonalCompany>
    {
        public void Configure(EntityTypeBuilder<PersonalCompany> builder)
        {
            builder.ToTable("PersonalCompany");
            builder.HasKey(ky => new { ky.SSN, ky.CompanyId });

            builder.HasOne(a => a.PersonalInformation)
               .WithMany(c => c.CompanyInformations)
               .HasForeignKey(a => a.SSN);

            builder.HasOne(a => a.CompanyInformation)
             .WithMany(c => c.PersonalInformations)
             .HasForeignKey(a => a.CompanyId); 


        }
    }
}
