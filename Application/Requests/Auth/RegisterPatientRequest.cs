using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalHealth.Application.Requests.Auth
{
    public record RegisterPatientRequest(string UserName, string Email, string Password, string PhoneNumber);

}
