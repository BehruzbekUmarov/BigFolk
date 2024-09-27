using AutoMapper;
using BigFolk.Api.Models.Domain;
using BigFolk.Api.Models.DTO.HouseSystem;
using BigFolk.Api.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BigFolk.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseSystemController : ControllerBase
    {
        private readonly IHouseSystemRepository _systemRepository;
        private readonly IMapper _mapper;

        public HouseSystemController(IHouseSystemRepository systemRepository, IMapper mapper)
        {
            _systemRepository = systemRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var houseSystemDomain = await _systemRepository.GetAllAsync();
            if(houseSystemDomain == null) return NotFound();

            return Ok(_mapper.Map<List<HouseSystemDto>>(houseSystemDomain));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var houseSystemDomain = await _systemRepository.GetByIdAsync(id);
            if(houseSystemDomain == null) return NotFound();

            return Ok(_mapper.Map<HouseSystemDto>(houseSystemDomain));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddHouseSystemRequestDto systemRequestDto)
        {
            var systemDomain = _mapper.Map<HouseSystem>(systemRequestDto);
            
            systemDomain = await _systemRepository.CreateAsync(systemDomain);

            if(systemDomain == null) return NotFound();

            var systemDto = _mapper.Map<HouseSystemDto>(systemDomain);

            return CreatedAtAction(nameof(GetById), new { id = systemDto.Id }, systemDto);
        }

        [HttpPut]
        [Route("{id:GUid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateHouseSystemRequestDto systemRequestDto)
        {
            var systemDomain = _mapper.Map<HouseSystem>(systemRequestDto);

            systemDomain = await _systemRepository.UpdateAsync(id, systemDomain);
            if(systemDomain == null) return NotFound();

            return Ok(_mapper.Map<HouseSystemDto>(systemDomain));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var systemDomain = await _systemRepository.DeleteAsync(id);
            if(systemDomain == null) return NotFound();

            return Ok(_mapper.Map<HouseSystemDto>(systemDomain));
        }
    }
}
