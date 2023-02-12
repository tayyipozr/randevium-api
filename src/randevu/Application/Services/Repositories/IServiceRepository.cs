using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories
{
    public interface IServiceRepository : IAsyncRepository<Service>, IRepository<Service>
    {
    }
}
