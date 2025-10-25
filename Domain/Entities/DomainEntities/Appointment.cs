using Core.Interfaces;
using Domain.ValueObjects;

namespace Domain.Entities
{

    public partial class Appointment : IEntity
    {
        public Guid Id { get; set; }

        public Period EventPeriod { get;set; }
        public Guid DoctorId { get; set; }
        public Guid PatientId { get; set; }


        #region navigation properties
        public Patient patient { get; set; }   
        public Doctor doctor { get; set; }
        #endregion


    }
}
