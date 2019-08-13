using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CRUD_MVC.Models
{
    public class KSContext : DbContext
    {
        public DbSet<TestStudent> TestStudentTable { get; set; }

        public void UpdateTestStudent(TestStudent t)
        {
            string s = ConfigurationManager.ConnectionStrings["KSContext"].ConnectionString;
            using(SqlConnection con = new SqlConnection(s))
            {
                SqlCommand cmd = new SqlCommand("spTestStudentUpdate", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", t.ID);
                cmd.Parameters.AddWithValue("@name", t.Name);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteTestStudent(int id)
        {
            string s = ConfigurationManager.ConnectionStrings["KSContext"].ConnectionString;
            using(SqlConnection con = new SqlConnection(s))
            {
                SqlCommand cmd = new SqlCommand("spTestStudentDelete", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id",id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void InsertTestStudent(TestStudent t)
        {
            string s = ConfigurationManager.ConnectionStrings["KSContext"].ConnectionString;
            using (SqlConnection con = new SqlConnection(s))
            {
                SqlCommand cmd = new SqlCommand("spTestStudentInsert", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", t.Name);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}