﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApplication10.Models
{
    public class StudentDAL
    {
        SqlCommand cmd;
        SqlConnection con;
        public StudentDAL()
        {
            string ConStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
            con = new SqlConnection(ConStr);
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
        }
        public List<student> GetStudents(int? Sid, bool? Status)
        {
            List<student> students = new List<student>();
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "student_Select";
                if (Sid != null && Status != null)
                {
                    cmd.Parameters.AddWithValue("@Sid", Sid);
                    cmd.Parameters.AddWithValue("@Status", Status);
                }
                else if (Sid != null && Status == null)
                    cmd.Parameters.AddWithValue("@Sid", Sid);
                else if (Sid == null && Status != null)
                    cmd.Parameters.AddWithValue("@Status", Status);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    student student = new student
                    {
                        Sid = (int)dr["Sid"],
                        Name = (string)dr["Name"],
                        Class = (int)dr["Class"],
                        Fees = (decimal)dr["Fees"],
                        Photo = (string)dr["Photo"]
                    };
                    students.Add(student);
                }
            }
            catch (Exception ex)
            { throw ex; }
            finally
            { con.Close(); }
            return students;
        }
        public int InsertStudent(student student)
        {
            int Count = 0;
            try
            {
                cmd.CommandText = "Student_Insert";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Sid", student.Sid);
                cmd.Parameters.AddWithValue("@Name", student.Name);
                cmd.Parameters.AddWithValue("@Class", student.Class);
                cmd.Parameters.AddWithValue("@Fees", student.Fees);
                if (student.Photo != null && student.Photo.Length != 0)
                    cmd.Parameters.AddWithValue("@Photo", student.Photo);
                con.Open();
                Count = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            { throw ex; }
            finally
            { con.Close(); }
            return Count;
        }
        public int UpdateStudent(student student)
        {
            int Count = 0;
            try
            {
                cmd.CommandText = "Student_Update";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Sid", student.Sid);
                cmd.Parameters.AddWithValue("@Name", student.Name);
                cmd.Parameters.AddWithValue("@Class", student.Class);
                cmd.Parameters.AddWithValue("@Fees", student.Fees);
                if (student.Photo != null && student.Photo.Length != 0)
                    cmd.Parameters.AddWithValue("@Photo", student.Photo);
                con.Open();
                Count = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            { throw ex; }
            finally
            { con.Close(); }
            return Count;
        }
        public int DeleteStudent(int Sid)
        {
            int Count = 0;
            try
            {
                cmd.CommandText = "Student_Delete";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Sid", Sid);
                con.Open();
                Count = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            { throw ex; }
            finally
            { con.Close(); }
            return Count;
        }
    }
}