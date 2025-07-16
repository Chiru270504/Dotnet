using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using mvcwebtask.Models;

namespace mvcwebtask.Controllers
{
    public class EmployController : ApiController
    {
        repo emp = new repo();
        // GET: api/emp
        [HttpGet]
        public IEnumerable<employe> Get()
        {
            return emp.GetAllEmploye();
        }

        [HttpPost]
        public IHttpActionResult Post(employe employee)
        {
            emp.Addemploye(employee);
            return Ok("Employee Added Successfully");
        }

        [HttpPut]
        public IHttpActionResult Put(employe employee)
        {
            emp.Editemploye(employee);
            return Ok("Employee Updated Successfully");
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            emp.Deleteemploye(id);
            return Ok("Employee Deleted Successfully");
        }
    }

}
