using AutoMapper;
using BigFolk.Api.Data;
using BigFolk.Api.Models.Domain;
using BigFolk.Api.Models.DTO.Genius;
using BigFolk.Api.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BigFolk.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeniusController : ControllerBase
    {
        private readonly IGeniusRepository _geniusRepository;
        private readonly IMapper _mapper;
        public GeniusController(IGeniusRepository geniusRepository, IMapper mapper)
        {
            _geniusRepository = geniusRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var geniusDomain = await _geniusRepository.GetAllAsync();
            if(geniusDomain ==  null) return NotFound();

            //var geniusDto = new List<GeniusDto>();
            //foreach (var genius in geniusDomain)
            //{
            //    geniusDto.Add(new GeniusDto()
            //    {
            //        Id = genius.Id,
            //        Name = genius.Name,
            //        ImageUrl = genius.ImageUrl,
            //        Cars = genius.Cars,
            //        Companies = genius.Companies,
            //        SmartHouses = genius.SmartHouses,
            //        Habits = genius.Habits,
            //        Portfolios = genius.Portfolios
            //    });
            //}

            return Ok(_mapper.Map<List<GeniusDto>>(geniusDomain));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var geniusDomain = await _geniusRepository.GetByIdAsync(id);

            if(geniusDomain == null) return NotFound();

            return Ok(_mapper.Map<GeniusDto>(geniusDomain));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddGeniusRequestDto requestDto)
        {
            var geniusDomain = _mapper.Map<Genius>(requestDto);

            geniusDomain = await _geniusRepository.CreateAsync(geniusDomain);

            var geniusDto = _mapper.Map<GeniusDto>(geniusDomain);

            return CreatedAtAction(nameof(GetById), new { id = geniusDto.Id }, geniusDto);   
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, UpdateGeniusRequestDto requestDto)
        {
            var geniusDomainModel = _mapper.Map<Genius>(requestDto);

            geniusDomainModel = await _geniusRepository.UpdateAsync(id, geniusDomainModel);
            if (geniusDomainModel == null) return NotFound();

            return Ok(_mapper.Map<GeniusDto>(geniusDomainModel));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var geniusDomain = await _geniusRepository.DeleteAsync(id);  
            if(geniusDomain == null) return NotFound();

            return Ok(_mapper.Map<GeniusDto>(geniusDomain););
        }
    }
}
