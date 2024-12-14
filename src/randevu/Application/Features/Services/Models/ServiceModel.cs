using Application.Features.Services.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.Services.Models
{
    public class ServiceModel: BasePageableModel
    {
        public IList<ServiceListDto>? Items { get; set; }
    }
}
