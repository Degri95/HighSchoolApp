using HighSchoolApp.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HighSchoolApp.Pages.Exam
{
    public class EditModel : PageModel
    {
        private IExamAdapter _examAdapter;
        private IStudentAdapter _studentAdapter;
        public EditModel(IExamAdapter examAdapter, IStudentAdapter studentAdapter)
        {
            _examAdapter = examAdapter;
            _studentAdapter = studentAdapter;
        }
        public int ExamId { get; set; }
        [Required]
        [BindProperty]
        [DisplayName("Student")]
        [Range(1, Double.MaxValue, ErrorMessage = "Please select a student")]
        public int StudentId { get; set; }
        [BindProperty]
        [Required]
        [DisplayName("Exam Score")]
        [Range(0, 100, ErrorMessage = "Please enter a score between 0 and 100")]
        public int Score { get; set; }
        public List<SelectListItem> StudentOptions { get; set; }
        public bool IsSuccess { get; set; }
        public void OnGet(int id = 0)
        {
            SetUpStudentList();
            if (id > 0 )
            { 
                DAL.Exam exam = _examAdapter.GetExamById(id);
                ExamId = exam.ExamId;
                StudentId = exam.StudentId;
                Score = exam.Score;
            }
        }

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                DAL.Exam exam = new DAL.Exam
                {
                    ExamId = ExamId,
                    StudentId = StudentId,
                    Score = Score
                };
                if (ExamId > 0)
                {
                    IsSuccess = _examAdapter.UpdateExam(exam);
                }
                else
                {
                    IsSuccess = _examAdapter.InsertExam(exam);
                }
            }
            else
            {
                SetUpStudentList();
                IsSuccess = false;
            }
        }

        public void SetUpStudentList()
        {
            StudentOptions = new List<SelectListItem>();
            IEnumerable<DAL.Student> students = _studentAdapter.GetAllStudents();
            foreach (DAL.Student student in students)
            {
                StudentOptions.Add(new SelectListItem
                {
                    Value = student.StudentId.ToString(),
                    Text = student.FirstName + " " + student.LastName
                });
            }
        }
    }
}
 