using HighSchoolApp.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HighSchoolApp.Pages.Teacher
{
    public class IndexModel : PageModel
    {
        private ITeacherAdapter _teacherAdapter;
        public IndexModel(ITeacherAdapter teacherAdapter)
        {
            _teacherAdapter = teacherAdapter;
        }
        public IEnumerable<DAL.Teacher> Teachers { get; set; }

        public void OnGet()
        {
            Teachers = _teacherAdapter.GetAllTeachers();
        }
    }
}
