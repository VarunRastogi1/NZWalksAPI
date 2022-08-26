using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.Api.Repositories;

namespace NZWalks.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalksController : Controller
    {
        private readonly IWalkRepository walkRepository;
        private readonly IMapper mapper;

        public WalksController(IWalkRepository walkRepository, IMapper mapper)
        {
            this.walkRepository = walkRepository;
            this.mapper = mapper;
        }  
        
        [HttpGet]
        public async Task<IActionResult> GetAllWalksAsync()
        {
            // Fetch data from database- domain walks
            var walksDomain= await walkRepository.GetAllAsync();


            //Convert domain walks to DTO walks
            var walkDTO = mapper.Map < List<Models.DTO.Walk>>(walksDomain);


            //Return response
            return Ok(walkDTO);
        }
    }
}
