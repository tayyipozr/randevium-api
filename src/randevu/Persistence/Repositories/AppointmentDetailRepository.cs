using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class AppointmentDetailRepository : EfRepositoryBase<AppointmentDetail, BaseDbContext>, IAppointmentDetailRepository
    {
        public AppointmentDetailRepository(BaseDbContext context) : base(context)
        {
        }
    }


}
