using BAL;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace practise_from.Controllers
{
    public class Employee_CtrlController : Controller
    {
        Employee_BAL BAL = new Employee_BAL();

        // GET: Employee_Ctrl

       [HttpGet]
       public ActionResult EmployList()
        {
            return View(BAL.EmployList());
        }
       
     
        public JsonResult State(int id)
        {
            return Json(BAL.State(id), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult CreateEmp()
        {
            ViewBag.countrydrop = BAL.GetCountry();
            ViewBag.Statedrop = new List<Employee_Model>();
            return View();
        }

        [HttpPost]
        public ActionResult CreateEmp(Employee_Model EM)
        {
            if (ModelState.IsValid)
            {

                ViewBag.countrydrop = BAL.GetCountry();
                ViewBag.Statedrop = new List<Employee_Model>();

                BAL.CreateEmp(EM);

                return RedirectToAction("EmployList");
            }

            return View(EM);
        }





    }
}