using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Walk_and_Trails_of_SA_API.Data;
using Walk_and_Trails_of_SA_API.Models.Domain;
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
            // Get Region Domain model from the database
            var regionDomain = databaseContext.Regions.FirstOrDefault(x => x.Id == id);

            if (regionDomain == null)
            {
                return NotFound();
            }

            // Convert Region domain to a single RegionDto object
            var regionDto = new RegionDto()
            {
                Id = regionDomain.Id,
                Name = regionDomain.Name,
                Code = regionDomain.Code,
                RegionImageUrl = regionDomain.RegionImageUrl
            };

            // Return DTO back to the client
            return StatusCode(StatusCodes.Status200OK, regionDto);
        }

        //POST to create new Region
        [HttpPost]
        public IActionResult  Create ([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            //Convert DTO TO Domain Model
            var regionDomain = new Region
            {
                Code = addRegionRequestDto.Code,
                Name = addRegionRequestDto.Name,
                RegionImageUrl = addRegionRequestDto.RegionImageUrl
            };

            //Use Domain Model to create Region
            databaseContext.Regions.Add(regionDomain);
            databaseContext.SaveChanges();


            //return CreatedAtAction(nameof(GetById), new {id=regionDomain.Id}, regionDomain);

            //Map Domain model back to DTO

            var regionDto = new RegionDto
            {
                Id = regionDomain.Id,
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                RegionImageUrl = regionDomain.RegionImageUrl
            };

            return StatusCode(StatusCodes.Status201Created, regionDomain);

        }

        //Update Region
        [HttpPut]
        [Route("{id.Guid}")]
        public IActionResult Update ([FromRoute] Guid guid,[FromBody] UpdateRegionRequestDto updateRegionRequestDto )
        {
            //check if Region Exists
            var regionDomail = databaseContext.Regions.FirstOrDefault(x => x.Id == id);

            if (regionDomail == null)
            {
                return NotFound();
            }

            //Map DTO to Domain model

            regionDomail.Code = updateRegionRequestDto.Code;
            regionDomail.Name = updateRegionRequestDto.Name;
           regionDomail.RegionImageUrl = updateRegionRequestDto.RegionImageUrl;

            databaseContext.SaveChanges(regionDomail);

            //convert domain model to DTO
            var  regionDto = new RegionDto
            {
                Id=regionDomail.Id,
                Code=regionDomail.Code,
                Name=regionDomail.Name,
                RegionImageUrl=regionDomail.RegionImageUrl
            }


            return StatusCode(StatusCodes.Status200OK);
        }

    }
}
