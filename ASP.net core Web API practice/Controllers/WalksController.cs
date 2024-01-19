using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Walk_and_Trails_of_SA_API.CustomActionFilters;
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
            try
            {
                var walkDomainModel = await WalkRepository.GetALLAsync();

                //map Domain Model to Dto
                mapper.Map<List<WalkDto>>(walkDomainModel);

                return StatusCode(StatusCodes.Status200OK, walkDomainModel);
            }
            catch (Exception ex)
            {
                //log this exception
                throw;
            }
        }

        //GET Walks
        //GET: Api/walks

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            //use repo
            var walkDomainModel = await WalkRepository.GetByIdAsync(id);

            //check

            if (walkDomainModel == null)
            {
                return NotFound();
            }

            //mapp Domain to Dto
            mapper.Map<WalkDto>(walkDomainModel);

            return StatusCode(StatusCodes.Status200OK, walkDomainModel);

        }

        //CRREATE Walk
        //POST: /api/walks
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
                //Map  DTO to Domain Model
                var walkDomainModel = mapper.Map<Walk>(addWalkRequestDto);

                await WalkRepository.CreateAsync(walkDomainModel);


                //Map Domain model to Dto
                mapper.Map<WalkDto>(walkDomainModel);


                return StatusCode(StatusCodes.Status200OK, walkDomainModel);
        }

        //UPDATE Walk By ID
        //PUT: api/Walk

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]

        public async Task<IActionResult>Update([FromRoute]Guid id, UpdateWalkRequestDto updateWalkRequestDto)
        {
                //Map DTO to Domain Model
                var walkDomainModel = mapper.Map<Walk>(updateWalkRequestDto);

                //use Repo
                walkDomainModel = await WalkRepository.UpdateByIdAsync(id, walkDomainModel);

                //check

                if (walkDomainModel == null)
                {
                    return NotFound();
                }

                mapper.Map<WalkDto>(walkDomainModel);

                return StatusCode(StatusCodes.Status200OK, walkDomainModel);
        }

        //DELETE a walk By ID
        //Delete: /api/walk

        [HttpDelete]
        [Route("{id:Guid}")]

        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var DeletedWalkDomainModel =await WalkRepository.DeleteAsync(id);

            //check

            if(DeletedWalkDomainModel == null)
            {
                return NotFound();
            }

            //Map Domain Model TO DTO

            mapper.Map<WalkDto>(DeletedWalkDomainModel) ;

            return StatusCode(StatusCodes.Status200OK,DeletedWalkDomainModel);
        }
    }
}
