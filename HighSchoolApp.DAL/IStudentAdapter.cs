
namespace HighSchoolApp.DAL
{
    public interface IStudentAdapter
    {
        bool DeleteStudent(int studentId);
        IEnumerable<Student> GetAllStudents();
        Student GetStudentById(int studentId);
        bool InsertStudent(Student student);
        bool UpdateStudent(Student student);
    }
}