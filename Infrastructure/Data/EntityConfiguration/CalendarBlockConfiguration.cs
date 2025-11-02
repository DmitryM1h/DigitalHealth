using Domain.Entities;
using Domain.Entities.DomainEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.EntityConfiguration
{

    internal class CalendarBlockConfiguration : IEntityTypeConfiguration<CalendarBlock>
    {
        public void Configure(EntityTypeBuilder<CalendarBlock> builder)
        {
            builder.OwnsOne(t => t.period);

            builder.HasKey(t => t.Id);

            builder.HasOne(t => t.Doctor)
                .WithOne()
                .HasForeignKey<CalendarBlock>(t => t.DoctorId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
