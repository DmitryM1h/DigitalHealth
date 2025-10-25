using Core.Entities;



namespace Domain.Entities;
public partial class Patient : User
{
    public IEnumerable<Doctor> doctors { get; set; } = [];
    public List<Appointment> Appointments { get; set; } = [];




}

