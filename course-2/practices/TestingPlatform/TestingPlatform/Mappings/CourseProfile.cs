using AutoMapper;
using TestingPlatform.API.Responses.Course;
using TestingPlatform.Application.Dtos;

namespace TestingPlatform.API.Mappings
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<CourseDto, CourseResponse>();
        }
    }
}
