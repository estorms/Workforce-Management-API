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
    public class EmployeeTrainingController : Controller
    {

        private WorkforceDbContext context;

        public EmployeeTrainingController(WorkforceDbContext ctx)
        {
            context = ctx;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {

            var EmployeeTrainings = context.EmployeeTraining;

            if (EmployeeTrainings == null)
            {
                return NotFound();
            }

            return Ok(EmployeeTrainings);
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var EmployeeTraining = context.EmployeeTraining.Where(e => e.EmployeeTrainingId == id);

            if (EmployeeTraining == null)
            {
                return NotFound();
            }
            return Ok(EmployeeTraining);
        }

        // POST api/values
        public IActionResult Post([FromBody] EmployeeTraining EmployeeTraining)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.EmployeeTraining.Add(EmployeeTraining);
            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (EmployeeTrainingExists(EmployeeTraining.EmployeeTrainingId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetEmployeeTraining", new { id = EmployeeTraining.EmployeeTrainingId }, EmployeeTraining);
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
                EmployeeTraining EmployeeTraining = context.EmployeeTraining.Single(u => u.EmployeeTrainingId == id);
                if (EmployeeTraining == null)
                {
                    return NotFound();
                }

                context.EmployeeTraining.Remove(EmployeeTraining);
                context.SaveChanges();

                return Ok();
            }
            catch (System.InvalidOperationException)
            {
                return NotFound();
            }
        }

        private bool EmployeeTrainingExists(int id)
        {
            return context.EmployeeTraining.Count(e => e.EmployeeTrainingId == id) > 0;
        }
    }
}
