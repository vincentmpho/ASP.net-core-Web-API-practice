using AutoMapper;
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
        private readonly IMapper mapper;

        public RegionsController(DatabaseContext databaseContext, IRegionRepository regionRepository, IMapper mapper)
        {
           this.databaseContext = databaseContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
            //Get Data from database-Domain models
            var regionsDomain = await regionRepository.GetAllAysnc();

            //Map Domain Models to DTOs
           var regionDto= mapper.Map<List<RegionDto>>(regionsDomain);

            //Return  DTos.
            return StatusCode(StatusCodes.Status200OK, regionDto);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task <IActionResult> GetById([FromRoute] Guid id)
        {
            // Get Region Domain model from the database
            var regionDomain =await  regionRepository.GetAysncById(id);

            //checking if it's null
            if (regionDomain == null)
            {
                return NotFound();
            }

            //Map Domain Models to DTOs
            var regionDto = mapper.Map<RegionDto>(regionDomain);

            // Return DTO back to the client
            return StatusCode(StatusCodes.Status200OK, regionDto);
        }

        //POST to create new Region
        [HttpPost]
        public async Task <IActionResult>  Create ([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            if (ModelState.IsValid)
            {


                //Convert DTO TO Domain Model
                var regionDomain = mapper.Map<Region>(addRegionRequestDto);

                //Use Domain Model to create Region
                regionDomain = await regionRepository.CreateAsync(regionDomain);
                await databaseContext.SaveChangesAsync();

                //Map Domain model back to DTO

                var regionDto = mapper.Map<RegionDto>(regionDomain);

                return StatusCode(StatusCodes.Status201Created, regionDomain);
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }

        }

        // Update Region
        [HttpPut]
        [Route("{id}")]
        public async Task <IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            if (ModelState.IsValid)
            {
                //Map to DTO to domain Model
                var regionDomain = mapper.Map<Region>(updateRegionRequestDto);

                //check if Region Exists
                regionDomain = await regionRepository.UpdateAsync(id, regionDomain);

                if (regionDomain == null)
                {
                    return NotFound();
                }
                //convert domain model to DTO
                var regionDto = mapper.Map<RegionDto>(regionDomain);


                return StatusCode(StatusCodes.Status200OK, regionDto);
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }

            
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

            //Map  Domain Model to Dto

            var regionsDto = mapper.Map<RegionDto> (regionDomain);

            return StatusCode(StatusCodes.Status200OK, regionsDto);
        }

    }
}
