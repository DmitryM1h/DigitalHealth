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
      
        builder.OwnsOne(t => t.Monday);
        builder.OwnsOne(t => t.Tuesday);
        builder.OwnsOne(t => t.Thursday);
        builder.OwnsOne(t => t.Wednesday);
        builder.OwnsOne(t => t.Friday);
        builder.OwnsOne(t => t.Saturday);
        builder.OwnsOne(t => t.Sunday);

       //TODO OwnsOne заменить на ComplexProperty
       //один инстанс ComplexProperty изменит сразу несколько сущностей бд, если они в коде используют его
    }
}
