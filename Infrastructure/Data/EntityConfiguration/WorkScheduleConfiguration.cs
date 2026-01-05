using Domain.Entities;
using Domain.ValueObjects;
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

        ConfigureWorkingHours(builder.ComplexProperty(t => t.Monday));
        ConfigureWorkingHours(builder.ComplexProperty(t => t.Tuesday));
        ConfigureWorkingHours(builder.ComplexProperty(t => t.Wednesday));
        ConfigureWorkingHours(builder.ComplexProperty(t => t.Thursday));
        ConfigureWorkingHours(builder.ComplexProperty(t => t.Friday));
        ConfigureWorkingHours(builder.ComplexProperty(t => t.Saturday));
        ConfigureWorkingHours(builder.ComplexProperty(t => t.Sunday));
    }
    private void ConfigureWorkingHours(ComplexPropertyBuilder<WorkingHours> builder)
    {
        builder.Property(w => w.StartDate).IsRequired(false);
        builder.Property(w => w.EndDate).IsRequired(false);
        builder.Ignore(w => w.Duration);
    }




}
