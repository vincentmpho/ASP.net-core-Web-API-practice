using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Walk_and_Trails_of_SA_API.Models.Domain;
using Walk_and_Trails_of_SA_API.Models.DTO;
using Walk_and_Trails_of_SA_API.Repositories;

namespace Walk_and_Trails_of_SA_API.Controllers
{
    // /api/walks
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;

        public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
            this.mapper = mapper;
            WalkRepository = walkRepository;
        }

        public IWalkRepository WalkRepository { get; }


        //GET Walks
        //GET: Api/Wals

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
             var walkDomainModel =await WalkRepository.GetALLAsync();

            //map Domain Model to Dto
            mapper.Map<List<WalkDto>>(walkDomainModel);

            return StatusCode(StatusCodes.Status200OK, walkDomainModel);
        }






        //CRREATE Walk
        //POST: /api/walks
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            //Map  DTO to Domain Model
            var walkDomainModel =mapper.Map<Walk>(addWalkRequestDto);

            await WalkRepository.CreateAsync(walkDomainModel);


            //Map Domain model to Dto
            mapper.Map<WalkDto>(walkDomainModel);


            return StatusCode(StatusCodes.Status200OK, walkDomainModel);
        }
    }
}
