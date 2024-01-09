using AutoMapper;
using Walk_and_Trails_of_SA_API.Models.Domain;
using Walk_and_Trails_of_SA_API.Models.DTO;

namespace Walk_and_Trails_of_SA_API.Mappings
{
    public class AutomapperProfile :Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Region, RegionDto>().ReverseMap();
            CreateMap<AddRegionRequestDto, RegionDto>().ReverseMap();
            CreateMap<UpdateRegionRequestDto, RegionDto>().ReverseMap();
            CreateMap<AddWalkRequestDto, Walk>().ReverseMap();
            CreateMap<Walk,  WalkDto>().ReverseMap();

        }
    }
}
