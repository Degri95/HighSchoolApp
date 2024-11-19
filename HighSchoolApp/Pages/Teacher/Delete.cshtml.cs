using HighSchoolApp.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HighSchoolApp.Pages.Teacher
{
    public class DeleteModel : PageModel
    {
        private ITeacherAdapter _teacherAdapter;
        public DeleteModel(ITeacherAdapter teacherAdapter)
        {
            _teacherAdapter = teacherAdapter;
        }
        public int Id { get; set; }
        public bool IsSuccess { get; set; }
        public void OnGet(int id = 0)
        {
            Id = id;
            if (Id > 0)
            {
                bool isDelete = _teacherAdapter.DeleteTeacher(Id);
                if (isDelete)
                {
                    IsSuccess = true;
                }
                else
                {
                    IsSuccess = false;
                }
            }
            else
            {
                IsSuccess = false;
            }
        }
    }
}
