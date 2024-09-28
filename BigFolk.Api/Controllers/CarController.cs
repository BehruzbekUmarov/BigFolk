using AutoMapper;
using BigFolk.Api.Models.Domain;
using BigFolk.Api.Models.DTO.Car;
using BigFolk.Api.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BigFolk.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public CarController(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var carDomain = await _carRepository.GetAllAsync();

            if (carDomain == null) return NotFound();

            //var carDto = new List<CarDto>();
            //foreach (var car in carDomain)
            //{
            //    carDto.Add(new CarDto
            //    {
            //        Id = car.Id,
            //        Name = car.Name,
            //        Type = car.Type,
            //        State = car.State,
            //        ImageUrl = car.ImageUrl,
            //        CreatedOn = car.CreatedOn,
            //        GeniusId = car.GeniusId,
            //    });
            //}

            return Ok(_mapper.Map<List<CarDto>>(carDomain));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var carDomain = await _carRepository.GetByIdAsync(id);

            if(carDomain == null) return NotFound();

            return Ok(_mapper.Map<CarDto>(carDomain));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddCarRequestDto requestDto)
        {
            var carDomain = _mapper.Map<Car>(requestDto);

            carDomain = await _carRepository.CreateAsync(carDomain);
            if(carDomain == null) return NotFound();

            var carDto = _mapper.Map<CarDto>(carDomain);

            return CreatedAtAction(nameof(GetById), new { id = carDto.Id }, carDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateCarRequestDto requestDto)
        {
            var carDomain = _mapper.Map<Car>(requestDto);

            carDomain = await _carRepository.UpdateAsync(id, carDomain);
            if(carDomain == null) return NotFound();

            return Ok(_mapper.Map<Car>(carDomain));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var carDomain = await _carRepository.DeleteAsync(id);
            if(carDomain == null) return NotFound();

            return Ok(_mapper.Map<CarDto>(carDomain));
        }
    }
}
