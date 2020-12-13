using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ExamenMVC.Models;

namespace ExamenMVC.Controllers
{
    public class EmployeesController : ApiController
    {
        private _DbContext db = new _DbContext();

        // GET: api/Employees
        public IQueryable<Employee> GetEmployees()
        {
            return db.Employees;
        }

        // GET: api/Employees/5
        [ResponseType(typeof(Employee))]
        public IHttpActionResult GetEmployee(int id)
        {
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        
        [Route("api/UpdateEmployee")]
        [HttpPost]
        public string UpdateEmployee(Employee employee)
        {
            try
            {
                Employee c = (from e in db.Employees
                              where e.Id == employee.Id
                              select e).First();
                c.EmployeeName = employee.EmployeeName;
                c.Position = employee.Position;
                c.Departament = employee.Departament;
                c.Version = employee.Version;
                db.SaveChanges();

                return "ok";
            }
            catch (Exception ex)
            {
                return "bad";
            }
            
        }

        // POST: api/Employees
        [ResponseType(typeof(Employee))]
        public IHttpActionResult PostEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Employees.Add(employee);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = employee.Id }, employee);
        }


        [Route("api/DeleteEmployee")]
        [HttpPost]
        public string DeleteEmployee(Employee employee)
        {
            try
            {
                var c = (from e in db.Employees
                              where e.Id == employee.Id
                              select e).SingleOrDefault();
                db.Employees.Remove(c);
                db.SaveChanges();

                return "ok";
            }
            catch (Exception ex)
            {
                return "bad";
            }

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployeeExists(int id)
        {
            return db.Employees.Count(e => e.Id == id) > 0;
        }
    }
}