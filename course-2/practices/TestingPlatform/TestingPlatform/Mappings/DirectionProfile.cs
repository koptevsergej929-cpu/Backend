using AutoMapper;
using TestingPlatform.API.Responses.Direction;
using TestingPlatform.Application.Dtos;

namespace TestingPlatform.API.Mappings
{
    public class DirectionProfile : Profile
    {
        public DirectionProfile()
        {
            CreateMap<DirectionDto, DirectionResponse>();
        }
    }
}
