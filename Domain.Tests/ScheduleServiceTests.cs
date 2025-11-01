using Auth;
using Domain.Entities;
using Domain.Repository;
using Domain.Services;
using Domain.ValueObjects;
using Moq;

namespace Domain.Tests
{
    public class ScheduleServiceTests
    {

        private readonly Mock<IAppointmentDataSource> _mockDataSource;
        private readonly ScheduleService _scheduleService;

        public ScheduleServiceTests()
        {
            _mockDataSource = new Mock<IAppointmentDataSource>();
            _scheduleService = new ScheduleService(_mockDataSource.Object);
        }


        [Theory]
        [MemberData(nameof(CreatePeriods))]
        public void GetUserSchedule_WithValidParameters_ReturnsSchedule(List<Appointment> appointments)
        {
            var user = new User { Id = Guid.NewGuid(), NormalizedUserName = "test" };

            var period = Period.Create(DateTime.Now, DateTime.Now.AddDays(7));

            _mockDataSource
                .Setup(x => x.GetAppointmentsAsync(user.Id))
                .ReturnsAsync(appointments);

            //TODO Дописать.....

        }

        public static IEnumerable<object[]> CreatePeriods()
        {
            return new List<object[]> { 
                    
                new object[]{new Appointment(Period.Create(DateTime.Now.AddDays(1), DateTime.Now.AddDays(1).AddHours(1))) },

             };
        }
    }
}