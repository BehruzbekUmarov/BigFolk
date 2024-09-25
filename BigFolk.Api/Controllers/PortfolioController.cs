using AutoMapper;
using BigFolk.Api.Models.Domain;
using BigFolk.Api.Models.DTO.Portfolio;
using BigFolk.Api.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BigFolk.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        private readonly IPortfolioRepository _portfolioRepository;
        private readonly IMapper _mapper;

        public PortfolioController(IPortfolioRepository portfolioRepository, IMapper mapper)
        {
            _portfolioRepository = portfolioRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var portfolioDomain = await _portfolioRepository.GetAll();
            if(portfolioDomain == null) NotFound();

            return Ok(_mapper.Map<List<PortfolioDto>>(portfolioDomain));
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddPortfolioRequestDto addPortfolio)
        {
            var portfolioDomain = _mapper.Map<Portfolio>(addPortfolio);

            portfolioDomain = await _portfolioRepository.Craete(portfolioDomain);
            if(portfolioDomain == null) NotFound();

            return Ok(_mapper.Map<PortfolioDto>(portfolioDomain));
        }

        //[HttpDelete]
        //[Route("{id:Guid}")]
        //public async Task<IActionResult> Delete([FromRoute] Guid id)
        //{
        //    var portfolioDomain = await _portfolioRepository.Delete(id);
        //    if(portfolioDomain == null) NotFound();

        //    Ok(_mapper.Map<PortfolioDto>(portfolioDomain));
        //}
    }
}
