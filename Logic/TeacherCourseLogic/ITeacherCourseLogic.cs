using DataTransferObjects;

namespace Logic.TeacherCourseLogic
{
    public interface ITeacherCourseLogic
    {
        public Task<IEnumerable<CoursesResultDto>> GetCourseByTeacher(int studentId);
    }
}
