using HighSchoolApp.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HighSchoolApp.Pages.Student
{
    public class DeleteModel : PageModel
    {
        private IStudentAdapter _studentAdapter;
        public DeleteModel(IStudentAdapter studentAdapter)
        {
            _studentAdapter = studentAdapter;
        }
        public int Id { get; set; }
        public bool IsSuccess { get; set; }

        public void OnGet(int id = 0)
        {
            Id = id;

            if (id >0)
            {
                bool isDelete = _studentAdapter.DeleteStudent(Id);

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
