using AutoMapper;
using BigFolk.Api.Models.Domain;
using BigFolk.Api.Models.DTO.Skill;
using BigFolk.Api.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BigFolk.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly ISkillRepository _skillRepository;
        private readonly IMapper _mapper;

        public SkillController(ISkillRepository skillRepository, IMapper mapper)
        {
            _skillRepository = skillRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var skillDomain = await _skillRepository.GetAllAsync();
            if(skillDomain == null) return NotFound();

            return Ok(_mapper.Map<List<SkillDto>>(skillDomain));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var skillDomain = await _skillRepository.GetByIdAsync(id);
            if(skillDomain == null) return NotFound();

            return Ok(_mapper.Map<SkillDto>(skillDomain));
        }

        [HttpPost]
        public async Task<IActionResult> Craete([FromBody] AddSkillRequestDto addSkillRequest)
        {
            var skillDomain = _mapper.Map<Skill>(addSkillRequest);

            skillDomain = await _skillRepository.CraeteAsync(skillDomain);
            if(skillDomain == null) return NotFound();

            var skillDto = _mapper.Map<SkillDto>(skillDomain);

            return CreatedAtAction(nameof(GetById), new { id = skillDto.Id }, skillDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateSkillRequestDto skillRequestDto)
        {
            var skillDomain = _mapper.Map<Skill>(skillRequestDto);

            skillDomain = await _skillRepository.UpdateAsync(id, skillDomain);
            if(skillDomain == null) return NotFound();

            return Ok(_mapper.Map<SkillDto>(skillDomain));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var skillDomain = await _skillRepository.DeleteAsync(id);
            if(skillDomain == null) return NotFound();

            return Ok(_mapper.Map<SkillDto>(skillDomain));
        }
    }
}
