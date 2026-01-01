using DigitalHealth.Domain.Repository;
using Domain.Entities;
using Domain.Interfaces;
using Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public record struct GetDoctorsFreeSlotsCommand(Guid DoctorId, Period period) : IRequest<IEnumerable<Slot>>;

    //internal sealed class GetDoctorsFreeSlotsCommandHandler(IClinicDataSource _clinicDataSource) : IRequestHandler<GetDoctorsFreeSlotsCommand, IEnumerable<Slot>>
    //{
    //    public async Task<IEnumerable<Slot>> Handle(GetDoctorsFreeSlotsCommand request, CancellationToken cancellationToken)
    //    {
    //        //var schedule = await _scheduleService.GetDoctorFreeGapsAsync(request.DoctorId, request.period);

    //        // return schedule.Slots;
    //        return [];
    //    }
    //}
}
