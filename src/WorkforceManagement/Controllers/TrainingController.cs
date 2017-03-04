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
    public class TrainingController : Controller
    {

        private WorkforceDbContext context;

        public TrainingController(WorkforceDbContext ctx)
        {
            context = ctx;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {

            var Trainings = context.Training;

            if (Trainings == null)
            {
                return NotFound();
            }

            return Ok(Trainings);
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var Training = context.Training.Where(e => e.TrainingId == id);

            if (Training == null)
            {
                return NotFound();
            }
            return Ok(Training);
        }

        // POST api/values
        public IActionResult Post([FromBody] Training Training)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.Training.Add(Training);
            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TrainingExists(Training.TrainingId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetTraining", new { id = Training.TrainingId }, Training);
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
                Training Training = context.Training.Single(u => u.TrainingId == id);
                if (Training == null)
                {
                    return NotFound();
                }

                context.Training.Remove(Training);
                context.SaveChanges();

                return Ok();
            }
            catch (System.InvalidOperationException)
            {
                return NotFound();
            }
        }

        private bool TrainingExists(int id)
        {
            return context.Training.Count(e => e.TrainingId == id) > 0;
        }
    }
}
