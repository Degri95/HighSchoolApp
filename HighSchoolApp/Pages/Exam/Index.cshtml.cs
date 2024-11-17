using HighSchoolApp.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HighSchoolApp.Pages.Exam
{
    public class IndexModel : PageModel
    {
        private IExamAdapter _examAdapter;

        public IndexModel(IExamAdapter examAdapter)
        {
            _examAdapter = examAdapter;
        }

        public IEnumerable<DAL.Exam> Exams { get; set; }
        public void OnGet(int id = 0)
        {
            if (id == 0)
            {
                Exams = _examAdapter.GetAllExams();
            }
            else
            {
                Exams = _examAdapter.GetExamsByStudentId(id);
            }
        }
    }
}
