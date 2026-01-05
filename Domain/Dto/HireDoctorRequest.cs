


namespace DigitalHealth.Domain.Dto
{
    public record HireDoctorRequest(Guid DoctorId, string FullName, string specialty, int capacity);

}
