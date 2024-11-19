using HighSchoolApp.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HighSchoolApp.Pages.Teacher
{
    public class EditModel : PageModel
    {
        private ITeacherAdapter _TeacherAdapter;
        public EditModel(ITeacherAdapter TeacherAdapter)
        {
            _TeacherAdapter = TeacherAdapter;
        }
        [BindProperty]
        public int TeacherId { get; set; }
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

        public void OnGet(int id = 0)
        {
            if (id > 0)
            {
                DAL.Teacher teacher = _TeacherAdapter.GetTeacherById(id);
                if (teacher != null)
                {
                    TeacherId = teacher.TeacherId;
                    FirstName = teacher.FirstName;
                    LastName = teacher.LastName;
                }
            }
        }

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                DAL.Teacher teacher = new DAL.Teacher();
                teacher.TeacherId = TeacherId;
                teacher.FirstName = FirstName;
                teacher.LastName = LastName;
                if (TeacherId > 0)
                {
                    bool isUpdate = _TeacherAdapter.UpdateTeacher(teacher);
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
                    bool isInsert = _TeacherAdapter.InsertTeacher(teacher);
                    if (isInsert)
                    {
                        IsSuccess = true;
                    }
                    else
                    {
                        IsSuccess = false;
                    }
                }
            }
        }
    }
}
