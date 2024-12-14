namespace Application.Features.Services.Dtos
{
    public class ServiceDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Cost { get; set; }
        public int CompanyId { get; set; }
    }
}
