using HighSchoolApp.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HighSchoolApp.Pages.Student
{
    public class EditModel : PageModel
    {
        private IStudentAdapter _studentAdapter;

        [BindProperty]
        public int StudentId { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "First Name is required")]
        [DisplayName("First Name")]
        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Last Name is required")]
        [DisplayName("Last Name")]
        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }
        public bool IsSuccess { get; set; }


        public EditModel(IStudentAdapter studentAdapter)
        {
            _studentAdapter = studentAdapter;
        }
        public void OnGet(int id = 0)
        {
            if (id > 0)
            {
                var student = _studentAdapter.GetStudentById(id);
                if (student != null)
                {
                    StudentId = student.StudentId;
                    FirstName = student.FirstName;
                    LastName = student.LastName;
                }
            }
        }

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                DAL.Student student = new DAL.Student();
                student.StudentId = StudentId;
                student.FirstName = FirstName;
                student.LastName = LastName;
                if (StudentId > 0)
                {
                    bool isUpdate = _studentAdapter.UpdateStudent(student);
                    if (isUpdate)
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
                    bool isInsert = _studentAdapter.InsertStudent(student);
                    if (isInsert)
                    {
                        IsSuccess = true;
                    }
                    else
                    {
                        IsSuccess = false;
                    }
                }
                IsSuccess = true;
            }
            else
            {
                IsSuccess = false;
            }
        }
    }
}
