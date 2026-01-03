using Domain.Entities;

namespace Domain.Repository
{
    public interface IPatientRepository
    {
        public Task AddPatientAsync(Patient patient);
        public Task SaveChangesAsync();

    }
}
