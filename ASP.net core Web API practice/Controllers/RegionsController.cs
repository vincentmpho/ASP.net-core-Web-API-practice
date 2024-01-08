using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Walk_and_Trails_of_SA_API.Data;
using Walk_and_Trails_of_SA_API.Models.Domain;
using Walk_and_Trails_of_SA_API.Models.DTO;
using Walk_and_Trails_of_SA_API.Repositories;

namespace Walk_and_Trails_of_SA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly DatabaseContext databaseContext;
        private readonly IRegionRepository regionRepository; 

        public RegionsController(DatabaseContext databaseContext, IRegionRepository regionRepository)
        {
           this.databaseContext = databaseContext;
            this.regionRepository = regionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
            //Get Data from database-Domain models
            var regionsDomain = await regionRepository.GetAllAysnc();

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
        public async Task <IActionResult> GetById([FromRoute] Guid id)
        {
            // Get Region Domain model from the database
            var regionDomain =await  regionRepository.GetAysncById(id);

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
        public async Task <IActionResult>  Create ([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            //Convert DTO TO Domain Model
            var regionDomain = new Region
            {
                Code = addRegionRequestDto.Code,
                Name = addRegionRequestDto.Name,
                RegionImageUrl = addRegionRequestDto.RegionImageUrl
            };

            //Use Domain Model to create Region
           regionDomain= await regionRepository.CreateAsync(regionDomain);
            await databaseContext.SaveChangesAsync();


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

        // Update Region
        [HttpPut]
        [Route("{id}")]
        public async Task <IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {

            //Map to DTO to domain Model

            var regionDomain = new Region
            {
                Code = updateRegionRequestDto.Code,
                Name = updateRegionRequestDto.Name,
                RegionImageUrl = updateRegionRequestDto.RegionImageUrl
            };
            //check if Region Exists
            regionDomain =await regionRepository.UpdateAsync(id, regionDomain);

            if (regionDomain == null)
            {
                return NotFound();
            }
            //convert domain model to DTO
            var regionDto = new RegionDto
            {
                Id = regionDomain.Id,
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                RegionImageUrl = regionDomain.RegionImageUrl
            };


            return StatusCode(StatusCodes.Status200OK,regionDto);
        }

        // Delete Region
        [HttpDelete]
        [Route("{id}")]
        public async Task <IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomain = await regionRepository.DeleteAsync(id);

            if (regionDomain == null)
            {
                return NotFound();
            }

            //Return Deleted  Region back
            //Map  Domain Model to Dto

            var regionsDto = new RegionDto
            {
                Id = regionDomain.Id,
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                RegionImageUrl = regionDomain.RegionImageUrl
            };

            return StatusCode(StatusCodes.Status200OK, regionsDto);
        }

    }
}
