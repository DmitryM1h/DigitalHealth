using CSharpFunctionalExtensions;
using DigitalHealth.Domain.Repository;
using Domain.Interfaces;
using Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalHealth.Application.Commands
{


    public record struct HireDoctorCommand(Guid DoctorId, Guid ClinicId, Period period) : IRequest<Result>;

    //internal sealed class HireDoctorCommandHandler(IClinicDataSource _clinicDataSource) : IRequestHandler<HireDoctorCommand, Result>
    //{
    //    public async Task<Result> Handle(HireDoctorCommand request, CancellationToken cancellationToken)
    //    {
    //        var clinic = await _clinicDataSource.GetClinicAsync(request.ClinicId);

    //        if (clinic is null)
    //            return Result.Failure("Invalid clinic");

    //        //clinic.HireDoctor()
    //        return Result.Success();
    //    }
    //}
}
