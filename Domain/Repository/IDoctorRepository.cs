using Domain.Entities;

namespace Domain.Repository
{
    public interface IDoctorRepository
    {
        public Task<Doctor?> GetDoctorById(Guid id);
        public Task<Doctor?> GetDoctorByIdWithLock(Guid id);


        public Task<IEnumerable<Doctor>> GetAllDoctors();

    }
}
