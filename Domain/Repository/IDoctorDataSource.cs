using Domain.Entities;

namespace Domain.Repository
{
    public interface IDoctorDataSource
    {
        public Task<Doctor?> GetDoctorById(Guid id);

        public Task<IEnumerable<Doctor>> GetAllDoctors();

    }
}
