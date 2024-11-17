
namespace HighSchoolApp.DAL
{
    public interface IExamAdapter
    {
        bool DeleteExam(int examId);
        IEnumerable<Exam> GetAllExams();
        IEnumerable<Exam> GetExamsByStudentId(int studentId);
        Exam GetExamById(int examId);
        bool InsertExam(Exam exam);
        bool UpdateExam(Exam exam);
    }
}