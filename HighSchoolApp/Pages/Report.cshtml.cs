using HighSchoolApp.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HighSchoolApp.Pages
{
    public class ReportModel : PageModel
    {
        public IExamAdapter _examAdapter;
        public ReportModel(IExamAdapter examAdapter)
        {
            _examAdapter = examAdapter;
        }
        public IEnumerable<DAL.Exam> Exams { get; set; }
        public Dictionary<string, int> GradeCount { get; set; }
        public void OnGet()
        {
            Exams = _examAdapter.GetAllExams();
            GradeCount = GetGradeCount();
        }

        private string GetLetterGrades(int score)
        {
         if (score >= 90)
            {
                return "A";
            }
            else if (score >= 80)
            {
                return "B";
            }
            else if (score >= 70)
            {
                return "C";
            }
            else if (score >= 60)
            {
                return "D";
            }
            else
            {
                return "F";
            }
        }

        public Dictionary<string, int> GetGradeCount() 
        {
            Dictionary<string, int> gradeCount = new Dictionary<string, int>();
            gradeCount["A"] = 0;
            gradeCount["B"] = 0;
            gradeCount["C"] = 0;
            gradeCount["D"] = 0;
            gradeCount["F"] = 0;

            foreach (DAL.Exam exam in Exams)
            {
                if (GetLetterGrades(exam.Score) == "A")
                {
                    gradeCount["A"]++;
                }
                else if (GetLetterGrades(exam.Score) == "B")
                {
                    gradeCount["B"]++;
                }
                else if (GetLetterGrades(exam.Score) == "C")
                {
                    gradeCount["C"]++;
                }
                else if (GetLetterGrades(exam.Score) == "D")
                {
                    gradeCount["D"]++;
                }
                else
                {
                    gradeCount["F"]++;
                }
            }
            return gradeCount;
        }
    }
}
