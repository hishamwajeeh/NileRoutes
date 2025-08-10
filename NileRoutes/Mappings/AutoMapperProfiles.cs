using AutoMapper;
using NileRoutes.Models.Domain;
using NileRoutes.Models.Dtos.DifficultyDto;
using NileRoutes.Models.Dtos.RegionDto;
using NileRoutes.Models.Dtos.WalkDto;

namespace NileRoutes.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // Region Mappings
            CreateMap<Region, RegionDto>().ReverseMap(); // For GET responses
            CreateMap<AddRegionRequestDto, Region>();   // For POST requests (no ReverseMap needed)
            CreateMap<UpdateRegionRequestDto, Region>(); // For PUT requests (no ReverseMap needed)

            // Walk Mappings
            CreateMap<Walk, WalkDto>().ReverseMap();
            CreateMap<AddWalkRequestDto, Walk>().ReverseMap();
            CreateMap<UpdateWalkRequestDto, Walk>().ReverseMap();

            // Difficulty Mappings
            CreateMap<Difficulty, DifficultyDto>().ReverseMap();
        }
    }
}