using Application.Features.AppointmentDetails.Dtos;
using Application.Features.Appointments.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.Appointments.Models
{
    public class AppointmentDetailModel : BasePageableModel
    {
        public List<AppointmentDetailDto>? Items { get; set; }
    }
}
