using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Dapper;

namespace HighSchoolApp.DAL
{
    public class ExamAdapter : IExamAdapter
    {
        private string CONN_STRING = @"Data Source=C:\Sqlite\School.db;";

        public IEnumerable<Exam> GetAllExams()
        {
            string sql = @"SELECT * FROM Exam";

            using (SqliteConnection connection = new SqliteConnection(CONN_STRING))
            {
                return connection.Query<Exam>(sql);
            }
        }

        public Exam GetExamById(int examId)
        {
            string sql = @"SELECT * FROM Exam WHERE ExamId = @ExamId";

            using (SqliteConnection connection = new SqliteConnection(CONN_STRING))
            {
                return connection.QueryFirst<Exam>(sql, new { ExamId = examId });
            }
        }

        public IEnumerable<Exam> GetExamsByStudentId(int studentId)
        {
            string sql = @"SELECT * FROM Exam WHERE StudentId = @StudentId";

            using (SqliteConnection connection = new SqliteConnection(CONN_STRING))
            {
                return connection.Query<Exam>(sql, new { StudentId = studentId });
            }
        }

        public bool InsertExam(Exam exam)
        {
            string sql = @"INSERT INTO Exam (StudentId, Score) VALUES (@StudentId, @Score)";

            using (SqliteConnection connection = new SqliteConnection(CONN_STRING))
            {
                int rowsAffected = connection.Execute(sql, exam);
                if (rowsAffected > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool UpdateExam(Exam exam)
        {
            string sql = @"UPDATE Exam SET StudentId = @StudentId, Score = @Score WHERE ExamId = @ExamId";

            using (SqliteConnection connection = new SqliteConnection(CONN_STRING))
            {
                int rowsAffected = connection.Execute(sql, exam);
                if (rowsAffected > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool DeleteExam(int examId)
        {
            string sql = "DELETE FROM Exam WHERE ExamId = @ExamId";

            using (SqliteConnection connection = new SqliteConnection(CONN_STRING))
            {
                int rowsAffected = connection.Execute(sql, new { ExamId = examId });
                if (rowsAffected > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
