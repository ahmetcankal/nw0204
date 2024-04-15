using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using p0204.Models;

namespace p0204.Controllers
{
  
  
    public class EmpController : Controller
    {
        NwContext db=new NwContext();
        
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

       [HttpPost]
        public IActionResult Create(Employee newemp)
        {
            if (ModelState.IsValid)
            {
            
             db.Employees.Add(newemp);
             db.SaveChanges();
             return RedirectToAction("List");
            }
            else
            {
                return View();
            }

            
        }

     

        public IActionResult List()
        {
            var emplist=db.Employees.ToList();

            return View(emplist);
        }
       
    public IActionResult Delete(int ? id)
        {
            var emp=db.Employees.FirstOrDefault(x=>x.EmployeeId==id);
            if (emp!=null)
            {
                db.Employees.Remove(emp);
                db.SaveChanges();
                
            }
        else
            {
                ViewBag.mesaj="Kayıt Bulunamadı";
            }

            

            return RedirectToAction("List");
        }

        public IActionResult Detail(int id)
        {
            var empdet=db.Employees.FirstOrDefault(x=>x.EmployeeId == id);

            return View(empdet);
        }


     public IActionResult Edit(int id)
        {
            var empupdate=db.Employees.FirstOrDefault(x=>x.EmployeeId == id);

            return View(empupdate);
        }

        [HttpPost]
     public IActionResult Edit(Employee emp)
        {
            //kaydı bul
            var _oldemp=db.Employees.FirstOrDefault(x=>x.EmployeeId == emp.EmployeeId);

        if (_oldemp!=null)
        {
            db.Entry(_oldemp).CurrentValues.SetValues(emp);
            db.SaveChanges();

        }

            return RedirectToAction("List");
        }
      




      
    }
}