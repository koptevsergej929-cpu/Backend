using TestingPlatform.API.Responses.Course;
using TestingPlatform.API.Responses.Direction;
using TestingPlatform.API.Responses.Project;

namespace TestingPlatform.API.Responses.Group
{
    public class GroupResponse : BaseResponse
    {
        public DirectionResponse Direction { get; set; }
        public CourseResponse Course { get; set; }
        public ProjectResponse Project { get; set; }
    }
}
