using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SchoolMangementSystem
{
    class AddStudentData
    {
        SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-MNO1P1S\SQLEXPRESS01;Initial Catalog=SchoolManagementDB;Integrated Security=True;Connect Timeout=30");
        public int ID { set; get; }
        public string StudentID { set; get; }
        public string StudentName { set; get; }
        public string StudentGender { set; get; }
        public string StudentAddress { set; get; }
        public string StudentGrade { set; get; }
        public string StudentSection { set; get; }
        public string StudentImage { set; get; }
        public string Status { set; get; }
        public string DateInsert { set; get; }

        public List<AddStudentData> studentData()
        {
            List<AddStudentData> listData = new List<AddStudentData>();
            if (connect.State != ConnectionState.Open)
            {
                try
                {
                    connect.Open();

                    string sql = "SELECT * FROM students WHERE date_delete IS NULL";

                    using (SqlCommand cmd = new SqlCommand(sql, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            AddStudentData addSD = new AddStudentData();
                            addSD.ID = (int)reader["ID"];
                            addSD.StudentID = reader["StudentID"].ToString();
                            addSD.StudentName = reader["StudentName"].ToString();
                            addSD.StudentGender = reader["StudentGender"].ToString();
                            addSD.StudentAddress = reader["StudentAddress"].ToString();
                            addSD.StudentGrade = reader["StudentGrade"].ToString();
                            addSD.StudentSection = reader["StudentSection"].ToString();
                            addSD.StudentImage = reader["StudentImage"].ToString();
                            addSD.Status = reader["StudentStatus "].ToString();
                            addSD.DateInsert = reader["DateInsert "].ToString();

                            listData.Add(addSD);
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error connecting Database: " + ex);
                }
                finally
                {
                    connect.Close();
                }
            }
            return listData;

        }

        public List<AddStudentData> dashboardStudentData()
        {
            List<AddStudentData> listData = new List<AddStudentData>();

            if (connect.State != ConnectionState.Open)
            {
                try
                {
                    connect.Open();
                    DateTime today = DateTime.Today;
                    string sql = "SELECT * FROM Students WHERE DateInsert = @dateInsert AND DateDelete IS NULL";


                    using (SqlCommand cmd = new SqlCommand(sql, connect))
                    {
                        cmd.Parameters.AddWithValue("@dateInsert", today.ToString());
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            AddStudentData addSD = new AddStudentData();
                            addSD.ID = (int)reader["ID"];
                            addSD.StudentID = reader["StudentID"].ToString();
                            addSD.StudentName = reader["StudentName"].ToString();
                            addSD.StudentGender = reader["StudentGender"].ToString();
                            addSD.StudentAddress = reader["StudentAddress"].ToString();
                            addSD.StudentGrade = reader["StudentGrade"].ToString();
                            addSD.StudentSection = reader["StudentSection"].ToString();
                            addSD.StudentImage = reader["StudentImage"].ToString();
                            addSD.Status = reader["StudentStatus "].ToString();
                            addSD.DateInsert = reader["DateInsert "].ToString();

                            listData.Add(addSD);
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex);
                }
                finally
                {
                    connect.Close();
                }
            }
            return listData;
        }
    }
}




