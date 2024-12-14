using Application.Features.Appointments.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.Appointments.Models
{
    public class AppointmentModel : BasePageableModel
    {
        public List<AppointmentDto>? Items { get; set; }
    }
}
