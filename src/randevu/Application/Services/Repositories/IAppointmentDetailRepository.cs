using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories
{
    public interface IAppointmentDetailRepository : IAsyncRepository<AppointmentDetail>, IRepository<AppointmentDetail>
    {
    }
}
