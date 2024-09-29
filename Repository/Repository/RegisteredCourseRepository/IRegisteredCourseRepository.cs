using Entities;

namespace Repository.Repository.RegisteredCourseRepository
{
    public interface IRegisteredCourseRepository
    {
        public Task<RegisteredCourse> AddAsync(RegisteredCourse registeredCourse);

        public Task<RegisteredCourse?> UpdateAsync(int id, RegisteredCourse registeredCourse);

        public Task<RegisteredCourse?> RemoveAsync(int id);

        public Task<List<CoursesResult>> FindAsync(int id);

        public Task<IEnumerable<RegisteredCourse>> GetAllAsync();
    }
}
