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
    public class DepartmentController : Controller
    {

        private WorkforceDbContext context;

        public DepartmentController(WorkforceDbContext ctx)
        {
            context = ctx;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {

            var Departments = context.Department;

            if (Departments == null)
            {
                return NotFound();
            }

            return Ok(Departments);
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var Department = context.Department.Where(e => e.DepartmentId == id);

            if (Department == null)
            {
                return NotFound();
            }
            return Ok(Department);
        }

        // POST api/values
        public IActionResult Post([FromBody] Department Department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.Department.Add(Department);
            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DepartmentExists(Department.DepartmentId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetDepartment", new { id = Department.DepartmentId }, Department);
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
                Department Department = context.Department.Single(u => u.DepartmentId == id);
                if (Department == null)
                {
                    return NotFound();
                }

                context.Department.Remove(Department);
                context.SaveChanges();

                return Ok();
            }
            catch (System.InvalidOperationException)
            {
                return NotFound();
            }
        }

        private bool DepartmentExists(int id)
        {
            return context.Department.Count(e => e.DepartmentId == id) > 0;
        }
    }
}
