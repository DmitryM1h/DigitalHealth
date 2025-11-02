using Domain.Entities;
using Domain.Entities.DomainEntities;
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

        builder.HasOne(t => t.Doctor)
            .WithOne()
            .HasForeignKey<WorkSchedule>(t => t.Id)
            .IsRequired();

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



    private const string SeedSql = @"INSERT INTO ""Telemetry"".""WorkSchedules""(
    ""Id"", 
    ""Monday_StartDate"", ""Monday_EndDate"", 
    ""Tuesday_StartDate"", ""Tuesday_EndDate"", 
    ""Wednesday_StartDate"", ""Wednesday_EndDate"",
    ""Thursday_StartDate"", ""Thursday_EndDate"", 
    ""Friday_StartDate"", ""Friday_EndDate"", 
    ""Saturday_StartDate"", ""Saturday_EndDate"", 
    ""Sunday_StartDate"", ""Sunday_EndDate"")
VALUES 
    ('088141e1-9b60-4b6c-aadd-d30c3d3f7228', '08:00:00', '16:00:00', '08:00:00', '16:00:00', '08:00:00', '16:00:00', '08:00:00', '16:00:00', '08:00:00', '15:00:00', NULL, NULL, NULL, NULL),
    ('0c5e35b1-0f7f-4cbb-9c72-38cf25d6bcc6', '08:00:00', '16:00:00', '08:00:00', '16:00:00', '08:00:00', '16:00:00', '08:00:00', '16:00:00', '08:00:00', '15:00:00', '09:00:00', '13:00:00', NULL, NULL),
    ('25213e63-740f-456d-82bb-f82fb66ec12f', '08:00:00', '16:00:00', '08:00:00', '16:00:00', '08:00:00', '16:00:00', '08:00:00', '16:00:00', '08:00:00', '15:00:00', NULL, NULL, NULL, NULL),
    ('2b99f46e-8b88-45af-ab21-26194f8c63e2', '08:00:00', '16:00:00', '08:00:00', '16:00:00', '08:00:00', '16:00:00', '08:00:00', '16:00:00', '08:00:00', '15:00:00', '09:00:00', '13:00:00', NULL, NULL),
    ('4b58fe66-add6-4897-9a6a-8160ea619316', '08:00:00', '16:00:00', '08:00:00', '16:00:00', '08:00:00', '16:00:00', '08:00:00', '16:00:00', '08:00:00', '15:00:00', NULL, NULL, NULL, NULL),
    ('50b73685-bbe1-47f7-91e3-98dbb7076635', '08:00:00', '16:00:00', '08:00:00', '16:00:00', '08:00:00', '16:00:00', '08:00:00', '16:00:00', '08:00:00', '15:00:00', '09:00:00', '13:00:00', NULL, NULL),
    ('6651e510-8ff0-40b6-b0af-fad07f69c810', '08:00:00', '16:00:00', '08:00:00', '16:00:00', '08:00:00', '16:00:00', '08:00:00', '16:00:00', '08:00:00', '15:00:00', NULL, NULL, NULL, NULL),
    ('7045e112-c844-4073-a883-6e0eb00f50dc', '08:00:00', '16:00:00', '08:00:00', '16:00:00', '08:00:00', '16:00:00', '08:00:00', '16:00:00', '08:00:00', '15:00:00', '09:00:00', '13:00:00', NULL, NULL),
    ('797b5f68-3e68-49c6-8e5a-820916a48aec', '08:00:00', '16:00:00', '08:00:00', '16:00:00', '08:00:00', '16:00:00', '08:00:00', '16:00:00', '08:00:00', '15:00:00', NULL, NULL, NULL, NULL),
    ('8134fc2f-8d9c-45f0-82e9-17cbc63f86b0', '08:00:00', '16:00:00', '08:00:00', '16:00:00', '08:00:00', '16:00:00', '08:00:00', '16:00:00', '08:00:00', '15:00:00', '09:00:00', '13:00:00', NULL, NULL),
    ('86fef563-c765-43e2-8754-38f712a76b1b', '08:00:00', '16:00:00', '08:00:00', '16:00:00', '08:00:00', '16:00:00', '08:00:00', '16:00:00', '08:00:00', '15:00:00', NULL, NULL, NULL, NULL),
    ('ab6be7c4-f1cb-4754-9c7d-19a79b6e8db9', '08:00:00', '16:00:00', '08:00:00', '16:00:00', '08:00:00', '16:00:00', '08:00:00', '16:00:00', '08:00:00', '15:00:00', '09:00:00', '13:00:00', NULL, NULL),
    ('ad356d26-f8d6-4efa-91c7-a9aa61088c3f', '08:00:00', '16:00:00', '08:00:00', '16:00:00', '08:00:00', '16:00:00', '08:00:00', '16:00:00', '08:00:00', '15:00:00', NULL, NULL, NULL, NULL),
    ('b16bc7f1-2fa0-4c8f-9fb9-982bb8a42c44', '08:00:00', '16:00:00', '08:00:00', '16:00:00', '08:00:00', '16:00:00', '08:00:00', '16:00:00', '08:00:00', '15:00:00', '09:00:00', '13:00:00', NULL, NULL),
    ('b3be6738-70fc-40cb-9f75-a844227864a5', '08:00:00', '16:00:00', '08:00:00', '16:00:00', '08:00:00', '16:00:00', '08:00:00', '16:00:00', '08:00:00', '15:00:00', NULL, NULL, NULL, NULL),
    ('b3eb2074-1881-4884-bb04-db9c8e8de813', '08:00:00', '16:00:00', '08:00:00', '16:00:00', '08:00:00', '16:00:00', '08:00:00', '16:00:00', '08:00:00', '15:00:00', '09:00:00', '13:00:00', NULL, NULL),
    ('c4aba459-7443-4ab4-a58a-449d7aabdb05', '08:00:00', '16:00:00', '08:00:00', '16:00:00', '08:00:00', '16:00:00', '08:00:00', '16:00:00', '08:00:00', '15:00:00', NULL, NULL, NULL, NULL),
    ('dd9dfb04-6a2e-485e-941c-b01269150c82', '08:00:00', '16:00:00', '08:00:00', '16:00:00', '08:00:00', '16:00:00', '08:00:00', '16:00:00', '08:00:00', '15:00:00', '09:00:00', '13:00:00', NULL, NULL),
    ('e69831bb-21c5-4615-bcc8-8f2e67767d90', '08:00:00', '16:00:00', '08:00:00', '16:00:00', '08:00:00', '16:00:00', '08:00:00', '16:00:00', '08:00:00', '15:00:00', NULL, NULL, NULL, NULL),
    ('ebd2a20e-beae-4315-9764-b6f46e877544', '08:00:00', '16:00:00', '08:00:00', '16:00:00', '08:00:00', '16:00:00', '08:00:00', '16:00:00', '08:00:00', '15:00:00', '09:00:00', '13:00:00', NULL, NULL);";

}
