using Core.Interfaces;


namespace Domain.Entities.SupportEntities
{
    public class DoctorInfo : IEntity
    {

        public Guid Id { get; set; }

        public Guid DoctorId { get; set; }
        public Doctor Doctor { get; set; }


        public string ShortBio { get; set; }        
        public string Education { get; set; }         
        public string Qualifications { get; set; }  

        public string Awards { get; set; }        
        public string Publications { get; set; }  


        public string PhotoUrl { get; set; }

    }
}
