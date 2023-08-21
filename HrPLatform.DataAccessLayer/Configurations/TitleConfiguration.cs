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
    public class TitleConfiguration : IEntityTypeConfiguration<TitleInformation>
    {
        public void Configure(EntityTypeBuilder<TitleInformation> builder)
        {
            builder.HasKey(e => e.TitleId);

            builder.Property(e => e.SsnPersonal).IsRequired();
            builder.Property(e => e.Title).IsRequired();
            builder.Property(e => e.Department).IsRequired();
            builder.Property(e => e.StartDate).IsRequired();
            builder.Property(e => e.Payment).IsRequired();

           
            builder.HasOne(e => e.PersonalInformation)
                  .WithOne(e => e.TitleInformation)
                  .HasForeignKey<TitleInformation>(e => e.SsnPersonal)
                  .OnDelete(DeleteBehavior.Restrict); 
        }
    }
}
