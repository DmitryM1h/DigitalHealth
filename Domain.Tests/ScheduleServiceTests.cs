//using Auth;
//using Domain.Entities;
//using Domain.Repository;
//using Domain.Services;
//using Domain.ValueObjects;
//using Moq;

//namespace Domain.Tests
//{
//    public class ScheduleServiceTests
//    {

//        private readonly Mock<IAppointmentDataSource> _mockAppointmentDataSource;
//        private readonly Mock<IScheduleDataSource> _mockScheduleDataSource;
//        private readonly Mock<ICalendarBlockDataSource> _mockCalendarBlockDataSource;


//        public static WorkSchedule StandardSchedule => WorkSchedule.Create(
//            id: Guid.Parse("00000000-0000-0000-0000-000000000001"),
//            monday: WorkingHours.Create(
//                startDate: new TimeOnly(9, 0),
//                endDate: new TimeOnly(18, 0)
//            ),
//            tuesday: WorkingHours.Create(
//                startDate: new TimeOnly(9, 0),
//                endDate: new TimeOnly(18, 0)
//            ),
//            wednesday: WorkingHours.Create(
//                startDate: new TimeOnly(9, 0),
//                endDate: new TimeOnly(18, 0)
//            ),
//            thursday: WorkingHours.Create(
//                startDate: new TimeOnly(9, 0),
//                endDate: new TimeOnly(18, 0)
//            ),
//            friday: WorkingHours.Create(
//                startDate: new TimeOnly(9, 0),
//                endDate: new TimeOnly(18, 0)

//            ),
//            saturday: WorkingHours.Create(null, null), // Выходной
//            sunday: WorkingHours.Create(null, null)  // Выходной
//        );
//        public ScheduleServiceTests()
//        {
//            _mockAppointmentDataSource = new Mock<IAppointmentDataSource>();
//            _mockScheduleDataSource = new Mock<IScheduleDataSource>();
//            _mockCalendarBlockDataSource = new Mock<ICalendarBlockDataSource>();

//        }


//        [Theory]
//        [MemberData(nameof(CreatePeriods))]
//        public async Task GetUserSchedule_WithValidParameters_ReturnsScheduleAsync(List<Appointment> appointments, int slotsCountResult)
//        {
//            // Prepare 

//            var user = new User { Id = Guid.NewGuid(), NormalizedUserName = "test" };

//            var period = Period.Create(new DateTime(2024, 2, 4), new DateTime(2024, 4, 10));

//            _mockAppointmentDataSource
//                .Setup(x => x.GetAppointmentsForPeriodAsync(user.Id, period))
//                .ReturnsAsync(appointments);

//            _mockScheduleDataSource
//                .Setup(x => x.GetDoctorsWorkingSchedule(user.Id))
//                .ReturnsAsync(StandardSchedule);

//            var scheduleService = new ScheduleService(_mockAppointmentDataSource.Object,
//              _mockScheduleDataSource.Object,
//              _mockCalendarBlockDataSource.Object);

//            // Act

//            var result = await scheduleService.GetDoctorScheduleAsync(user.Id, period);

//            // Assert

//            Assert.True(result.Slots.Count() == slotsCountResult);
//        }

//        public static List<object[]> CreatePeriods()
//        {
//            var startDate = new DateTime(2024, 2, 4); // Начало периода
//            var endDate = new DateTime(2024, 4, 10);  // Конец периода

//            // Создаем встречи в рабочие дни с 10:00 до 15:00
//            return new List<object[]> {
//        new object[]{
//            new List<Appointment> {  
//                // Понедельник 5 февраля 2024 (это понедельник)             // слот с 9 до 10, слот с 12 до конца дня
//                new Appointment(Period.Create(
//                    new DateTime(2024, 2, 5, 10, 0, 0),    // 5 фев 10:00
//                    new DateTime(2024, 2, 5, 11, 0, 0)     // 5 фев 11:00
//                )),
//                new Appointment(Period.Create(
//                    new DateTime(2024, 2, 5, 11, 0, 0),    // 5 фев 11:00
//                    new DateTime(2024, 2, 5, 12, 0, 0)     // 5 фев 12:00
//                )),
                
//                // Вторник 6 февраля 2024                                     // слот с 9 до 13, слот с 15 до конца дня
//                new Appointment(Period.Create(
//                    new DateTime(2024, 2, 6, 13, 0, 0),    // 6 фев 13:00
//                    new DateTime(2024, 2, 6, 14, 0, 0)     // 6 фев 14:00
//                )),
//                new Appointment(Period.Create(
//                    new DateTime(2024, 2, 6, 14, 0, 0),    // 6 фев 14:00
//                    new DateTime(2024, 2, 6, 15, 0, 0)     // 6 фев 15:00
//                )),
                
//                // Среда 7 февраля 2024                                     // слот с 9 до 10:30, слот с 11:30 до конца дня
//                new Appointment(Period.Create(
//                    new DateTime(2024, 2, 7, 10, 30, 0),   // 7 фев 10:30
//                    new DateTime(2024, 2, 7, 11, 30, 0)    // 7 фев 11:30
//                ))
//            }, 6 // ожидаемый результат - 6 слотов
//        },
//         new object[]{
//            new List<Appointment> {  
//                // Понедельник 5 февраля 2024 (это понедельник)             // слот с 9 до 10, слот с 11 до 12 ,слот с 15 до конца дня
//                new Appointment(Period.Create(
//                    new DateTime(2024, 2, 5, 10, 0, 0),    // 5 фев 10:00
//                    new DateTime(2024, 2, 5, 11, 0, 0)     // 5 фев 11:00
//                )),
//                new Appointment(Period.Create(
//                    new DateTime(2024, 2, 5, 12, 0, 0),    // 5 фев 12:00
//                    new DateTime(2024, 2, 5, 15, 0, 0)     // 5 фев 15:00
//                )),
                
//                // Вторник 6 февраля 2024                                     // слот с 9 до 13, слот с 15 до конца дня
//                new Appointment(Period.Create(
//                    new DateTime(2024, 2, 6, 13, 0, 0),    // 6 фев 13:00
//                    new DateTime(2024, 2, 6, 14, 0, 0)     // 6 фев 14:00
//                )),
//                new Appointment(Period.Create(
//                    new DateTime(2024, 2, 6, 14, 0, 0),    // 6 фев 14:00
//                    new DateTime(2024, 2, 6, 15, 0, 0)     // 6 фев 15:00
//                )),
                
//                // Среда 7 февраля 2024                                     // слот с 9 до 10:30, слот с 11:30 до 15:30, слот с 16:30 до конца дня
//                new Appointment(Period.Create(
//                    new DateTime(2024, 2, 7, 10, 30, 0),   // 7 фев 10:30
//                    new DateTime(2024, 2, 7, 11, 30, 0)    // 7 фев 11:30
//                )),
//                 new Appointment(Period.Create(
//                    new DateTime(2024, 2, 7, 15, 30, 0),   // 7 фев 15:30
//                    new DateTime(2024, 2, 7, 16, 30, 0)    // 7 фев 16:30
//                ))
//            }, 8 // ожидаемый результат - 8 слотов
//         }
//    }; 

//        }
//    }
//}