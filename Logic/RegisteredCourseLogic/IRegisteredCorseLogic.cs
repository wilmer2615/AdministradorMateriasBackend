using DataTransferObjects;

namespace Logic.RegisteredCourseLogic
{
    public interface IRegisteredCorseLogic
    {
        public Task<RegisteredCourseDto> AddAsync(RegisteredCourseDto registeredCourseDto);

        public Task<RegisteredCourseDto> UpdateAsync(int id, RegisteredCourseDto registeredCourseDto);

        public Task<RegisteredCourseDto> RemoveAsync(int studentId, int courseId);

        public Task<IEnumerable<RegisteredCourseDto>> GetAllAsync();

        public Task<List<CoursesResultDto>> FindAsync(int id);
    }
}
