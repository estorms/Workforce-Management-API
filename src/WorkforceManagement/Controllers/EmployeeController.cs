using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorkforceManagement.Models;
using WorkforceManagement.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace WorkforceManagement.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    public class EmployeeController : Controller
    {

        private WorkforceDbContext context;

        public EmployeeController(WorkforceDbContext ctx)
        {
            context = ctx;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {

            var Employees = context.Employee;

            if (Employees == null)
            {
                return NotFound();
            }

            return Ok(Employees);
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var Employee = context.Employee.Where(e => e.EmployeeId == id);

            if (Employee == null)
            {
                return NotFound();
            }
            return Ok(Employee);
        }

        // POST api/values
        public IActionResult Post([FromBody] Employee Employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.Employee.Add(Employee);
            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (EmployeeExists(Employee.EmployeeId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetEmployee", new { id = Employee.EmployeeId }, Employee);
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Employee Employee)
        {
            Employee.EmployeeId = id;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (Employee == null)
            {
                return NotFound();
            }

            context.Employee.Update(Employee);
            context.SaveChanges();

            return Ok(Employee);

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Employee Employee = context.Employee.Single(u => u.EmployeeId == id);
                if (Employee == null)
                {
                    return NotFound();
                }

                context.Employee.Remove(Employee);
                context.SaveChanges();

                return Ok();
            }
            catch (System.InvalidOperationException)
            {
                return NotFound();
            }
        }

        private bool EmployeeExists(int id)
        {
            return context.Employee.Count(e => e.EmployeeId == id) > 0;
        }
    }
}
