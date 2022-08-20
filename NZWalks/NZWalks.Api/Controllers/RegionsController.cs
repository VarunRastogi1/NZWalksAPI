using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.Api.Repositories;

namespace NZWalks.Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class RegionsController : Controller
    {
        private  IRegionRepository regionRepository;
        private IMapper mapper;
        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
            this.regionRepository = regionRepository;
            Mapper = mapper;
        }
        
        [HttpGet]
        public IActionResult GetAllRegions()
        {
            var regions= regionRepository.GetAll();

            // return DTO regions
            //Mapping Domain Region with DTO Region without automapper

            //var regionsDTO = new List<Models.DTO.Region>();
            //regions.ToList().ForEach(region =>
            //{
            //    var regionDTO = new Models.DTO.Region()
            //    {
            //        Id = region.Id,
            //        Code = region.Code,
            //        Name = region.Name,
            //        Area = region.Area,
            //        Lat = region.Lat,
            //        Long = region.Long,
            //        Population = region.Population,
            //    };
            //    regionsDTO.Add(regionDTO);
            //});


            var regionsDTO= mapper.Map<List<Models.DTO.Region>>(regions);

            return  Ok(regionsDTO);
        }

    }
}
