using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Walk_and_Trails_of_SA_API.Data;
using Walk_and_Trails_of_SA_API.Models.DTO;

namespace Walk_and_Trails_of_SA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly DatabaseContext databaseContext;
        public RegionsController(DatabaseContext databaseContext)
        {
           this.databaseContext = databaseContext;
        }

        [HttpGet]
        public IActionResult GetAll() 
        { 
            //Get Data from database-Domain models
            var regionsDomain  = databaseContext.Regions.ToList();

            //Map Domain models to DTOs
            var regionDto = new List<RegionDto>();
            foreach (var regionDomain in regionsDomain)
            {
                regionDto.Add(new RegionDto()
                {
                    Id =regionDomain.Id,
                    Name = regionDomain.Name,
                    Code = regionDomain.Code,
                    RegionImageUrl = regionDomain.RegionImageUrl
                });
            }

            //Return  DTos.
            return StatusCode(StatusCodes.Status200OK, regionDto);
        }

        [HttpGet]
        [Route("{id:Guid}")]

        public IActionResult GetById([FromRoute] Guid id)
        {
            //var regionsDomain = databaseContext.Regions.Find(id);
            //GET Region Domain model from daatabase
            
            var regionDomain = databaseContext.Regions.FirstOrDefault(x => x.Id == id);

            if (regionDomain == null)
            {
                return NotFound();
            }

            //Conert Region domain  to region DTO

            regionDto.Add(new RegionDto()
            {
                Id = regionDomain.Id,
                Name = regionDomain.Name,
                Code = regionDomain.Code,
                RegionImageUrl = regionDomain.RegionImageUrl
            });


            //return DTO back to client
            return StatusCode(StatusCodes.Status200OK, regionDto);

        }
    }
}
