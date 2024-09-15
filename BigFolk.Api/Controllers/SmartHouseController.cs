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

        public SmartHouseController(ISmartHouseRepository smartHouseRepository)
        {
            _smartHouseRepository = smartHouseRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var smartHouseDomain = await _smartHouseRepository.GetAllAsync();

            if (smartHouseDomain == null) return NotFound();

            var smartHouseDto = new List<SmartHouseDto>();
            foreach(var smartHouse in smartHouseDomain)
            {
                smartHouseDto.Add(new SmartHouseDto
                {
                    Id = smartHouse.Id,
                    State = smartHouse.State,
                    Country = smartHouse.Country,
                    ImageUrl = smartHouse.ImageUrl,
                    Region = smartHouse.Region,
                    GeniusId = smartHouse.GeniusId,
                });
            }

            return Ok(smartHouseDto);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var smartHouseDomain = await _smartHouseRepository.GetByIdAsync(id);

            if (smartHouseDomain == null) return NotFound();
            
            var smartHouseDto = new SmartHouseDto
            {
                Id = smartHouseDomain.Id,
                State = smartHouseDomain.State,
                Country = smartHouseDomain.Country,
                ImageUrl = smartHouseDomain.ImageUrl,
                Region = smartHouseDomain.Region,
                GeniusId= smartHouseDomain.GeniusId,
            };

            return Ok(smartHouseDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddSmartHouseRequestDto requestDto)
        {
            var smartHouseDomain = new SmartHouse
            {
                State = requestDto.State,
                Country = requestDto.Country,
                ImageUrl = requestDto.ImageUrl,
                Region = requestDto.Region,
                GeniusId = requestDto.GeniusId
            };

            smartHouseDomain = await _smartHouseRepository.CreateAsync(smartHouseDomain);

            var smartHouseDto = new SmartHouseDto
            {
                Id = smartHouseDomain.Id,
                State = smartHouseDomain.State,
                Country = smartHouseDomain.Country,
                ImageUrl = smartHouseDomain.ImageUrl,
                Region = smartHouseDomain.Region,
                GeniusId = smartHouseDomain.GeniusId
            };

            return CreatedAtAction(nameof(GetById), new {id = smartHouseDto.Id}, smartHouseDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id,[FromBody] UpdateSmartHouseRequestDto requestDto)
        {
            var smartHouseDomain = new SmartHouse
            {
                State = requestDto.State,
                Country = requestDto.Country,
                ImageUrl = requestDto.ImageUrl,
                Region = requestDto.Region,
                GeniusId = requestDto.GeniusId
            };

            smartHouseDomain = await _smartHouseRepository.UpdateAsync(id, smartHouseDomain);
            if (smartHouseDomain == null) return NotFound();

            var smartHouseDto = new SmartHouseDto
            {
                Id = smartHouseDomain.Id,
                State = smartHouseDomain.State,
                Country = smartHouseDomain.Country,
                ImageUrl = smartHouseDomain.ImageUrl,
                Region = smartHouseDomain.Region,
                GeniusId = smartHouseDomain.GeniusId
            };

            return Ok(smartHouseDto);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var smartHouseDomain = await _smartHouseRepository.DeleteAsync(id);

            if (smartHouseDomain == null) return NotFound();

            var smartHouseDto = new SmartHouseDto
            {
                Id = smartHouseDomain.Id,
                State = smartHouseDomain.State,
                Country = smartHouseDomain.Country,
                ImageUrl = smartHouseDomain.ImageUrl,
                Region = smartHouseDomain.Region,
                GeniusId = smartHouseDomain.GeniusId
            };

            return Ok(smartHouseDto);
        }
    }
}
