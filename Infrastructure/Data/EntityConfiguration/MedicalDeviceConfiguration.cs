using DigitalHealth.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace DigitalHealth.Infrastructure.Data.EntityConfiguration
{
    internal class MedicalDeviceConfiguration : IEntityTypeConfiguration<MedicalDevice>
    {
        public void Configure(EntityTypeBuilder<MedicalDevice> builder)
        {
            builder.ToTable("MedicalDevice");
            builder.HasKey(x => x.Id);

            builder
                .Property(t => t.JsonContract)
                .HasColumnType("jsonb");
                
                

        }
    }
}
