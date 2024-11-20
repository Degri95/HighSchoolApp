using HighSchoolApp.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HighSchoolApp.Pages.Exam
{
    public class DeleteModel : PageModel
    {
        private IExamAdapter _examAdapter;
        public DeleteModel(IExamAdapter examAdapter)
        {
            _examAdapter = examAdapter;
        }
        public int Id { get; set; }
        public bool IsSuccess { get; set; }
        public void OnGet(int id = 0)
        {
            Id = id;
            if (id > 0) 
            { 
                bool isDelete = _examAdapter.DeleteExam(id);
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
