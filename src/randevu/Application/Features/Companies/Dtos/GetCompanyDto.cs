﻿namespace Application.Features.Companies.Dtos
{
    public class GetCompanyDto
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? Phone { get; set; }
        public string? Description { get; set; }
    }
}