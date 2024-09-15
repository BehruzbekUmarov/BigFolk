using AutoMapper;
using BigFolk.Api.Models.Domain;
using BigFolk.Api.Models.DTO.SmartHouse;
using BigFolk.Api.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BigFolk.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmartHouseController : ControllerBase
    {
        private readonly ISmartHouseRepository _smartHouseRepository;
        private readonly IMapper _mapper;

        public SmartHouseController(ISmartHouseRepository smartHouseRepository, IMapper mapper)
        {
            _smartHouseRepository = smartHouseRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var smartHouseDomain = await _smartHouseRepository.GetAllAsync();

            if (smartHouseDomain == null) return NotFound();
            
            return Ok(_mapper.Map<List<SmartHouseDto>>(smartHouseDomain));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var smartHouseDomain = await _smartHouseRepository.GetByIdAsync(id);
            if (smartHouseDomain == null) return NotFound();

            return Ok(_mapper.Map<SmartHouseDto>(smartHouseDomain));
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddSmartHouseRequestDto requestDto)
        {
            var smartHouseDomain = _mapper.Map<SmartHouse>(requestDto);

            smartHouseDomain = await _smartHouseRepository.CreateAsync(smartHouseDomain);

            var smartHouseDto = _mapper.Map<SmartHouseDto>(smartHouseDomain);

            return CreatedAtAction(nameof(GetById), new {id = smartHouseDto.Id}, smartHouseDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id,[FromBody] UpdateSmartHouseRequestDto requestDto)
        {
            var smartHouseDomain = _mapper.Map<SmartHouse>(requestDto);

            smartHouseDomain = await _smartHouseRepository.UpdateAsync(id, smartHouseDomain);
            if (smartHouseDomain == null) return NotFound();

            return Ok(_mapper.Map<SmartHouseDto>(smartHouseDomain));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var smartHouseDomain = await _smartHouseRepository.DeleteAsync(id);
            if (smartHouseDomain == null) return NotFound();

            return Ok(_mapper.Map<SmartHouseDto>(smartHouseDomain));
        }
    }
}
