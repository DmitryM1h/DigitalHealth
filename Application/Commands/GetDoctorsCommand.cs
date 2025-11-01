using Domain.Entities;
using Domain.Repository;
using MediatR;

namespace Application.Commands
{
    public record struct GetDoctorsCommand() : IRequest<IEnumerable<Doctor>>;


    internal sealed class GetDoctorsCommandHandler(IDoctorDataSource _doctorDataSource) : IRequestHandler<GetDoctorsCommand, IEnumerable<Doctor>>
    {
        public async Task<IEnumerable<Doctor>> Handle(GetDoctorsCommand request, CancellationToken cancellationToken)
        {
            return await _doctorDataSource.GetAllDoctors();
        }
    }
}
