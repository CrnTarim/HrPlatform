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
    public class HrAuthoConfig : IEntityTypeConfiguration<HrAutho>
    {
        public void Configure(EntityTypeBuilder<HrAutho> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.ToTable("HrAutho");

            builder.HasOne(a => a.CompanyInformation)
               .WithMany(c => c.HrAuthos)
               .HasForeignKey(a => a.CompanyId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
