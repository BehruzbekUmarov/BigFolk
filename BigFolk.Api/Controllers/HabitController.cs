using AutoMapper;
using BigFolk.Api.Models.Domain;
using BigFolk.Api.Models.DTO.Habit;
using BigFolk.Api.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BigFolk.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabitController : ControllerBase
    {
        private readonly IHabitRepository _habitRepository;
        private readonly IMapper _mapper;

        public HabitController(IHabitRepository habitRepository, IMapper mapper)
        {
            _habitRepository = habitRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var habitDomain = await _habitRepository.GetAllAsync();
            if (habitDomain == null) return NotFound();

            return Ok(_mapper.Map<List<HabitDto>>(habitDomain));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var habitDomaim = await _habitRepository.GetByIdAsync(id);
            if(habitDomaim == null) return NotFound();

            return Ok(_mapper.Map<HabitDto>(habitDomaim));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddHabitRequestDto requestDto)
        {
            var habitDomain = _mapper.Map<Habit>(requestDto);

            habitDomain = await _habitRepository.CreateAsync(habitDomain);
            if (habitDomain == null) return NotFound();

            var habitDto = _mapper.Map<HabitDto>(habitDomain);

            return CreatedAtAction(nameof(GetById), new {id = habitDto.Id}, requestDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id,[FromBody] UpdateHabitRequestDto requestDto)
        {
            var habidDomain = _mapper.Map<Habit>(requestDto);

            habidDomain = await _habitRepository.UpdateAsync(id, habidDomain);
            if(habidDomain == null) return NotFound();

            var habitDto = _mapper.Map<HabitDto>(habidDomain);

            return Ok(habitDto);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id) 
        {
            var habitDomain = await _habitRepository.DeleteAsync(id);
            if(habitDomain == null) return NotFound();

            var habitDto = _mapper.Map<HabitDto>(habitDomain);

            return Ok(habitDto);
        }
    }
}
