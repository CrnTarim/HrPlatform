using HrPlatform.Entities.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrPLatform.DataAccessLayer.Configurations
{
    internal class PersonalConfiguration : IEntityTypeConfiguration<PersonalInformation>
    {
        public void Configure(EntityTypeBuilder<PersonalInformation> builder)
        {
            builder.ToTable("PersonalInformations");
            builder.HasKey(e => e.SSN);

            builder.Property(e => e.FirstName).IsRequired();
            builder.Property(e => e.LastName).IsRequired();
            builder.Property(e => e.Address).IsRequired();
            builder.Property(e => e.Phone).IsRequired();
            builder.Property(e => e.Email).IsRequired();



            
            
        }
    }
}
