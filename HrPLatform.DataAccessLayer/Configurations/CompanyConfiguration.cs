using HrPlatform.Entities.Company;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrPLatform.DataAccessLayer.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<CompanyInformation>
    {
        public void Configure(EntityTypeBuilder<CompanyInformation> builder)
        {
            builder.ToTable("CompanyInformations");

            builder.HasKey(x => x.CompanyId);
            builder.Property(e => e.CompanyName).IsRequired();
            builder.Property(e => e.CompanyDescription).IsRequired();
            builder.Property(e => e.CompanyPhone).IsRequired();
            builder.Property(e => e.CompanyEmail).IsRequired();
            builder.Property(e => e.CompanyWebsite).IsRequired();
            builder.Property(e => e.CompanyAddress).IsRequired();

            builder.Property(e => e.CardHoldersName).IsRequired();
            builder.Property(e => e.CardNumber).IsRequired();          
            builder.Property(e => e.SecurityCode).IsRequired();
            
        }
    }
}
