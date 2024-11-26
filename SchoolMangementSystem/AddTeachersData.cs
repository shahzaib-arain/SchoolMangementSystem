using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SchoolMangementSystem
{
    class AddTeachersData
    {
        SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-MNO1P1S\SQLEXPRESS01;Initial Catalog=SchoolManagementDB;Integrated Security=True;Connect Timeout=30");
        public int ID { set; get; }
        public string TeacherID { set; get; }
        public string TeacherName { set; get; }
        public string TeacherGender { set; get; }
        public string TeacherAddress { set; get; }
        public string TeacherImage { set; get; }
        public string Status { set; get; }
        public string DateInsert { set; get; }

        public List<AddTeachersData> teacherData()
        {
            List<AddTeachersData> listData = new List<AddTeachersData>();
            if (connect.State != ConnectionState.Open)
            {
                try
                {
                    connect.Open();

                    string sql = "SELECT * FROM Teachers WHERE DateDelete IS NULL";


                    using (SqlCommand cmd = new SqlCommand(sql, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            AddTeachersData addTD = new AddTeachersData();
                            addTD.ID = (int)reader["ID"];
                            addTD.TeacherID = reader["TeacherID"].ToString();
                            addTD.TeacherName = reader["TeacherName"].ToString();
                            addTD.TeacherGender = reader["TeacherGender"].ToString();
                            addTD.TeacherAddress = reader["TeacherAddress"].ToString();
                            addTD.TeacherImage = reader["TeacherImage"].ToString();
                            addTD.Status = reader[" TeacherStatus"].ToString();
                            addTD.DateInsert = reader["DateInsert "].ToString();

                            listData.Add(addTD);
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
    }
}