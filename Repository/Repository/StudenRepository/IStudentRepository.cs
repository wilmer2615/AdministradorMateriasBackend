using Entities;

namespace Repository.Repository.StudenRepository
{
    public interface IStudentRepository
    {
        public Task<Student> AddAsync(Student student);

        public Task<Student?> UpdateAsync(int id, Student student);

        public Task<Student?> RemoveAsync(int id);

        public Task<Student?> FindAsync(int id);
        
        public Task<CreditsStudent?> GetCreditsByStudent(int studentId);

        public Task<IEnumerable<Student>> GetAllByCourseId(int courseId);

        public Task<IEnumerable<Student>> GetAllAsync();

        public Task<Student?> VerifyAccountAsync(string email, string password);
    }
}
