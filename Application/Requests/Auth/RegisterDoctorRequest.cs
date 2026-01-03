using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalHealth.Application.Requests.Auth;


public record RegisterDoctorRequest(string UserName, string Email, string Password, string PhoneNumber, Guid ClinicId, string Specialty, int Capacity);


