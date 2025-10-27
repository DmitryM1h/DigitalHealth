using Domain.Entities;
using Domain.Entities.DomainEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.EntityConfiguration;

public class WorkScheduleConfiguration : IEntityTypeConfiguration<WorkSchedule>
{
    public void Configure(EntityTypeBuilder<WorkSchedule> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id)
            .ValueGeneratedOnAdd();

        //builder.HasOne(t => t.Doctor)
        //   .WithOne(t => t.WorkSchedule)
        //   .HasForeignKey<WorkSchedule>(t => t.DoctorId)
        //   .OnDelete(DeleteBehavior.Cascade);
   
    builder.ComplexProperty(t => t.Monday);
        builder.ComplexProperty(t => t.Tuesday);
        builder.ComplexProperty(t => t.Thursday);
        builder.ComplexProperty(t => t.Wednesday);
        builder.ComplexProperty(t => t.Friday);
        builder.ComplexProperty(t => t.Saturday);
        builder.ComplexProperty(t => t.Sunday);

    }
}
