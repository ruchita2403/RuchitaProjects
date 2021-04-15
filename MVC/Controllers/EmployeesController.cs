using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        public ActionResult Index()
        {
            IEnumerable<MVCEmployeeModel> emplist;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Employees").Result;
            emplist = response.Content.ReadAsAsync<IEnumerable<MVCEmployeeModel>>().Result;
            return View(emplist);
        }
        public ActionResult AddorEdit(int id =0) 
        {
            if (id==0)
            return View(new MVCEmployeeModel());
        else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Employees/"+id.ToString()).Result;
                return View(response.Content.ReadAsAsync<MVCEmployeeModel>().Result);
            }
        }
        [HttpPost]
        public ActionResult AddorEdit(MVCEmployeeModel emp)
        {
            if (emp.EmployeeID == 0)//for creation
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Employees", emp).Result;
                TempData["SuccessMessage"] = "Saved successfully";
            }
            else// for updation
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Employees/"+emp.EmployeeID, emp).Result;
                TempData["SuccessMessage"] = "Updated successfully";
            }
            return RedirectToAction("Index");
        }
        
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Employees/"+id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted successfully";
            return RedirectToAction("Index");
        }
    }
}