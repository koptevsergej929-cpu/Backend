using AutoMapper;
using TestingPlatform.Application.Dtos;
using TestingPlatform.Models;

namespace TestingPlatform.Application.Mapping;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Group, GroupDto>().ReverseMap();
            CreateMap<Direction, DirectionDto>().ReverseMap();
            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<Project, ProjectDto>().ReverseMap();
        }
    }

