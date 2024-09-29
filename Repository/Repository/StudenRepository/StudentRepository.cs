using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repository.StudenRepository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AplicationDbContext _context;

        public StudentRepository(AplicationDbContext context)
        {
            this._context = context;
        }
        public async Task<Student> AddAsync(Student student)
        {            
            await this._context.Set<Student>().AddAsync(student);            
            await this._context.SaveChangesAsync();

            await this._context.Set<CreditsStudent>().AddAsync(new CreditsStudent { Total = 9, StudentId = student.Id });
            await this._context.SaveChangesAsync();

            return student;           
        }

        public async Task<Student?> FindAsync(int id)
        {
            return await this._context.Set<Student>()
               .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await this._context.Set<Student>()
                .ToListAsync();
        }

        public async Task<IEnumerable<Student>> GetAllByCourseId(int courseId)
        {
            return await (from student in _context.Students
                          join registeredCourse in _context.RegisteredCourses
                          on student.Id equals registeredCourse.StudentId
                          where registeredCourse.CourseId == courseId
                          select student)
                 .ToListAsync();
        }
        
        public async Task<CreditsStudent?> GetCreditsByStudent(int studentId)
        {
            return await this._context.Set<CreditsStudent>()
              .FirstOrDefaultAsync(a => a.StudentId == studentId);
        }

        public async Task<Student?> RemoveAsync(int id)
        {
            var entity = await _context.Set<Student>().FirstOrDefaultAsync(x => x.Id == id);

            if (entity != null)
            {
                var result = this._context.Set<Student>().Remove(entity);
                await this._context.SaveChangesAsync();

                return result.Entity;
            }
            return null;
        }

        public async Task<Student?> UpdateAsync(int id, Student student)
        {
            try
            {
                var entity = _context.Set<Student>().FirstOrDefault(x => x.Id == id);

                if (entity != null)
                {
                    entity.Name = student.Name;
                    entity.Email = student.Email;
                    entity.Phone = student.Phone;
                    entity.Password = student.Password;


                    _context.Set<Student>().Update(entity);
                    await _context.SaveChangesAsync();

                    return entity;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return null;
        }

        public async Task<Student?> VerifyAccountAsync(string email, string password)
        {
            var entity = await _context.Set<Student>().FirstOrDefaultAsync(x => x.Email == email && x.Password == password);

            return entity;
        }
    }
}
