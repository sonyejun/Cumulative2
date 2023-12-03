using Cumulative2.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web.Mvc;

namespace Cumulative2.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }

        //GET : /Teacher/List
        public ActionResult List(string SearchKey = null)
        {
            TeacherDataController controller = new TeacherDataController();
            IEnumerable<Teacher> Teachers = controller.ListTeachers(SearchKey);
            return View(Teachers);
        }

        //GET : /Teacher/Show/{id}
        public ActionResult Show(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher NewTeacher = controller.FindTeacher(id);

            return View(NewTeacher);
        }

        //GET : /Author/DeleteConfirm/{id}
        public ActionResult DeleteConfirm(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher NewTeacher = controller.FindTeacher(id);


            return View(NewTeacher);
        }


        //POST : /Teacher/Delete/{id}
        [HttpPost]
        public ActionResult Delete(int id)
        {
            //Debug.WriteLine(id);
            TeacherDataController controller = new TeacherDataController();
            controller.DeleteTeacher(id);

            return RedirectToAction("List");
        }

        //GET : /Author/New
        public ActionResult New()
        {
            return View();
        }

        //GET : /Author/Ajax_New
        public ActionResult Ajax_New()
        {
            return View();

        }

        //POST : /Teacher/Create
        [HttpPost]
        public ActionResult Create(string TeacherFname, string TeacherLname, string EmployeeNumber, decimal Salary)
        {

            //Redirect to "List" only when all input values are present; otherwise, redirect to "New."
            // Validation of input values
            if (TeacherFname == "" || TeacherLname == "" || EmployeeNumber == "" || Salary < 0) return new HttpStatusCodeResult(400, "Bad Request");

            //Identify that this method is running
            //Identify the inputs provided from the form
            //Debug.WriteLine("I have accessed the Create Method!");
            //Debug.WriteLine(TeacherFname);
            //Debug.WriteLine(TeacherLname);
            //Debug.WriteLine(EmployeeNumber);

            Teacher NewTeacher = new Teacher();
            NewTeacher.TeacherFname = TeacherFname;
            NewTeacher.TeacherLname = TeacherLname;
            NewTeacher.EmployeeNumber = EmployeeNumber;
            NewTeacher.Salary = Salary;

            TeacherDataController controller = new TeacherDataController();
            controller.AddTeacher(NewTeacher);

            return RedirectToAction("List");

        }
    }
}