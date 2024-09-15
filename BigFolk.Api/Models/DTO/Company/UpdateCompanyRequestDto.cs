namespace BigFolk.Api.Models.DTO.Company
{
    public class UpdateCompanyRequestDto
    {
        public string Name { get; set; }
        public bool IsUnicorn { get; set; } = false;

        public Guid GeniusId { get; set; }
    }
}
