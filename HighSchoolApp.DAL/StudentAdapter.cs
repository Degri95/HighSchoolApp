using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighSchoolApp.DAL
{
    public class StudentAdapter : IStudentAdapter
    {
        private string CONN_STRING = @"Data Source=C:\Sqlite\School.db;";

        public IEnumerable<Student> GetAllStudents()
        {
            string sql = "SELECT * FROM Student";

            using (SqliteConnection connection = new SqliteConnection(CONN_STRING))
            {
                return connection.Query<Student>(sql);
            }
        }

        public Student GetStudentById(int studentId)
        {
            string sql = @"SELECT * FROM Student WHERE StudentId = @StudentId";

            using (SqliteConnection connection = new SqliteConnection(CONN_STRING))
            {
                return connection.QueryFirst<Student>(sql, new { StudentId = studentId });
            }
        }

        public bool InsertStudent(Student student)
        {
            string sql = @"INSERT INTO Student (FirstName, LastName) VALUES (@FirstName, @LastName)";

            using (SqliteConnection connection = new SqliteConnection(CONN_STRING))
            {
                int rowsAffected = connection.Execute(sql, student);
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

        public bool UpdateStudent(Student student)
        {
            string sql = @"UPDATE student SET FirstName = @FirstName, LastName = @LastName WHERE StudentId = @StudentId";

            using (SqliteConnection connection = new SqliteConnection(CONN_STRING))
            {
                int rowsAffected = connection.Execute(sql, student);
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

        public bool DeleteStudent(int studentId)
        {
            string sql = @"DELETE FROM Student WHERE StudentId = @StudentId";

            using (SqliteConnection connection = new SqliteConnection(CONN_STRING))
            {
                int rowsAffected = connection.Execute(sql, new { StudentId = studentId });
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
