using AutoMapper;
using TestingPlatform.API.Responses.Project;
using TestingPlatform.Application.Dtos;

namespace TestingPlatform.API.Mappings
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<ProjectDto, ProjectResponse>();
        }
    }
}
