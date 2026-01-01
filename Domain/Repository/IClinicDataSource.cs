using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalHealth.Domain.Repository
{
    public interface IClinicDataSource
    {
        public Task<Clinic?> GetClinicAsync(Guid clinicId);
        public Task SaveChangesAsync();
    }
}
