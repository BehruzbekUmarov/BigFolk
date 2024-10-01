using AutoMapper;
using BigFolk.Api.Models.Domain;
using BigFolk.Api.Models.DTO.Company;
using BigFolk.Api.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BigFolk.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "Reader, Writer")]
        public async Task<IActionResult> GetAll()
        {
            var companyDomain = await _companyRepository.GetAllAsync();
            if (companyDomain == null) return NotFound();

            return Ok(_mapper.Map<List<CompanyDto>>(companyDomain));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Reader, Writer")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var companyDomain = await _companyRepository.GetByIdAsync(id);
            if (companyDomain == null) return NotFound();

            return Ok(_mapper.Map<CompanyDto>(companyDomain));
        }

        [HttpPost]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] AddCompanyRequestDto requestDto)
        {
            var companyDomain = _mapper.Map<Company>(requestDto);

            companyDomain = await _companyRepository.CreateAsync(companyDomain);
            if (companyDomain == null) return NotFound();

            var companyDto = _mapper.Map<CompanyDto>(companyDomain);

            return CreatedAtAction(nameof(GetById), new { id = companyDto.Id }, companyDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateCompanyRequestDto requestDto)
        {
            var companyDomain = _mapper.Map<Company>(requestDto);

            companyDomain = await _companyRepository.UpdateAsync(id, companyDomain);
            if (companyDomain == null) return NotFound();

            return Ok(_mapper.Map<CompanyDto>(companyDomain));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var companyDomain = await _companyRepository.DeleteAsync(id);
            if (companyDomain == null) return NotFound();

            return Ok(_mapper.Map<CompanyDto>(companyDomain));
        }
    }
}
