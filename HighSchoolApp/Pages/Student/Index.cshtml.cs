using HighSchoolApp.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HighSchoolApp.Pages.Student
{
    public class IndexModel : PageModel
    {
        private IStudentAdapter _studentAdapter;

        public IndexModel(IStudentAdapter studentAdapter)
        {
            _studentAdapter = studentAdapter;
        }

        public IEnumerable<DAL.Student> Students { get; set; }
        public void OnGet()
        {
            Students = _studentAdapter.GetAllStudents();
        }
    }
}
