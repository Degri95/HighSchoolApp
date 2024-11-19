using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighSchoolApp.DAL
{
    public class TeacherAdapter : ITeacherAdapter
    {
        private string CONN_STRING = @"Data Source=C:\Sqlite\School.db;";

        public IEnumerable<Teacher> GetAllTeachers()
        {
            string sql = @"SELECT * FROM Teacher";

            using (SqliteConnection connection = new SqliteConnection(CONN_STRING))
            {
                return connection.Query<Teacher>(sql);
            }
        }

        public Teacher GetTeacherById(int teacherId)
        {
            string sql = @"SELECT * FROM Teacher WHERE TeacherId = @TeacherId";

            using (SqliteConnection connection = new SqliteConnection(CONN_STRING))
            {
                return connection.QueryFirst<Teacher>(sql, new { TeacherId = teacherId });
            }
        }

        public bool InsertTeacher(Teacher teacher)
        {
            string sql = @"INSERT INTO Teacher (FirstName, LastName) VALUES (@FirstName, @LastName)";

            using (SqliteConnection connection = new SqliteConnection(CONN_STRING))
            {
                int rowsAfftected = connection.Execute(sql, teacher);
                if (rowsAfftected > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool UpdateTeacher(Teacher teacher)
        {
            string sql = @"UPDATE Teacher SET FirstName = @FirstName, LastName = @LastName WHERE TeacherId = @TeacherId";

            using (SqliteConnection connection = new SqliteConnection(CONN_STRING))
            {
                int rowsAffected = connection.Execute(sql, teacher);
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

        public bool DeleteTeacher(int teacherId)
        {
            string sql = @"DELETE FROM Teacher WHERE TeacherId = @TeacherId";

            using (SqliteConnection connection = new SqliteConnection(CONN_STRING))
            {
                int rowsAffected = connection.Execute(sql, new { TeacherId = teacherId });
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
