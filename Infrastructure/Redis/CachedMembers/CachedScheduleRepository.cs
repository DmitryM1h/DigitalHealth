using Domain.ValueObjects;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DigitalHealth.Infrastructure.Redis.CachedMembers
{
    public class CachedScheduleRepository
    {
        private readonly IDistributedCache _distributedCache;

        public CachedScheduleRepository(IDistributedCache _cache)
        {
            _distributedCache = _cache;
        }

        public async Task<Schedule?> GetDoctorsGaps(Guid DoctorId, DateOnly date, CancellationToken cancellationToken = default)
        {
            string key = $"Schedule-{DoctorId}-{date.ToString()}";

            var cachedSchedule = await _distributedCache.GetStringAsync(key, cancellationToken);

            if (cachedSchedule.IsNullOrEmpty())
                return null;

            return JsonSerializer.Deserialize<Schedule>(cachedSchedule!);
        }

        public async Task SetDoctorGapsAsync(Guid DoctorId, SlotsForDay slotsForDay)
        {
            var day = slotsForDay.date.ToString();
            string key = $"Schedule-{DoctorId}-{day}";

            var value = JsonSerializer.Serialize(slotsForDay.Slots)!;

            await _distributedCache.SetStringAsync(key, value);
        }
    }
}
