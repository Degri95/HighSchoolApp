
namespace HighSchoolApp.DAL
{
    public interface ITeacherAdapter
    {
        bool DeleteTeacher(int id);
        IEnumerable<Teacher> GetAllTeachers();
        Teacher GetTeacherById(int id);
        bool InsertTeacher(Teacher teacher);
        bool UpdateTeacher(Teacher teacher);
    }
}