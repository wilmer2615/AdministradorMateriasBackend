using DataTransferObjects;

namespace Logic.StudentLogic
{
    public interface IStudentLogic
    {
        public Task<StudentDto> AddAsync(StudentDto studenDto);

        public Task<StudentDto> UpdateAsync(int id, StudentDto studentDto);

        public Task<StudentDto> RemoveAsync(int id);

        public Task<IEnumerable<StudentDto>> GetAllAsync();

        public Task<StudentDto> FindAsync(int id);
        
        public Task<CreditsStudentDto> GetCreditsByStudent(int studentId);

        public Task<StudentDto?> VerifyAccountAsync(AccountDto accountDto);

        public Task<IEnumerable<StudentDto>> GetAllByCourseId(int courseId);
    }
}
