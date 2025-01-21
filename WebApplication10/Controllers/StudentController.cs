using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication10.Models;


namespace WebApplication10.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        StudentDAL obj = new StudentDAL();

        //public ViewResult DisplayStudents(int Sid)
        //{
        //    return View(obj.GetStudents().Single());
        //}
        public ViewResult DisplayStudents()
        {
            return View(obj.GetStudents());
        }
        public ViewResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public RedirectToRouteResult AddStudent(student student, HttpPostedFileBase selectedFile)
        {
            if (selectedFile != null)
            {
                string PhysicalPath = Server.MapPath("~/Uploads/");
                if (!Directory.Exists(PhysicalPath))
                {
                    Directory.CreateDirectory(PhysicalPath);
                }
                selectedFile.SaveAs(PhysicalPath + selectedFile.FileName);
                student.Photo = selectedFile.FileName;
                
            }
            obj.InsertStudent(student);
            return RedirectToAction("DisplayStudents");
        }
        public ViewResult EditStudent(int Sid)
        {
            student student = obj.GetStudents(Sid).First();
            
            return View();
        }
        public RedirectToRouteResult UpdateStudent(student student, HttpPostedFileBase selectedFile)
        {
            //if (selectedFile != null)
            //{
            //    string PhysicalPath = Server.MapPath("~/Uploads/");
            //    if (!Directory.Exists(PhysicalPath))
            //    {
            //        Directory.CreateDirectory(PhysicalPath);
            //    }
            //    selectedFile.SaveAs(PhysicalPath + selectedFile.FileName);
            //    student.Photo = selectedFile.FileName;
            //}
            //else
            //{
            //    student.Photo = TempData["Photo"].ToString();
            //}
            obj.UpdateStudent(student);
            return RedirectToAction("DisplayStudents");
        }
        public RedirectToRouteResult DeleteStudent(int Sid)
        {
            obj.DeleteStudent(Sid);
            return RedirectToAction("DisplayStudents");
        }
    }
}