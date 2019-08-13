using CRUD_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_MVC.Controllers
{
    public class HomeController : Controller
    {
        #region default
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        #endregion

        public ActionResult TestStudentTable()
        {
            KSContext ks = new KSContext();
            DbSet ts = ks.TestStudentTable;
            return View(ts);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            KSContext ks = new KSContext();
            TestStudent ts = ks.TestStudentTable.Single(d => d.ID == id);
            return View(ts);
        }
        [HttpPost]
        public ActionResult Edit(TestStudent ts)
        {
            if (ModelState.IsValid)
            {
                KSContext ks = new KSContext();
                ks.UpdateTestStudent(ts);
                return RedirectToAction("TestStudentTable");
            }
            return View(ts);
        }
        public ActionResult Details(int id)
        {
            KSContext ks = new KSContext();
            TestStudent ts = ks.TestStudentTable.Single(i=>i.ID==id);
            return View(ts);
        }
        public ActionResult Delete(int id)
        {
            KSContext ks = new KSContext();
            ks.DeleteTestStudent(id);
            return RedirectToAction("TestStudentTable");
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(TestStudent ts)
        {
            if (ModelState.IsValid)
            {
                KSContext ks = new KSContext();
                ks.InsertTestStudent(ts);
                return RedirectToAction("TestStudentTable");
            }
            return View(ts);            
        }
    }
}