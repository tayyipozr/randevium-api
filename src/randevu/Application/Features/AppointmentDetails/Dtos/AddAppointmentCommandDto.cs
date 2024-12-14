namespace Application.Features.AppointmentDetails.Dtos
{
    public class AddAppointmentCommandDto
    {
        public ICollection<AppointmentDetailDto> AppointmentDetailDtos { get; set; }

        public AddAppointmentCommandDto()
        {
            AppointmentDetailDtos = new HashSet<AppointmentDetailDto>();
        }
    }
}
