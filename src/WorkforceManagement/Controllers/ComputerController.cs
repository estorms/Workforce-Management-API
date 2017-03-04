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
    public class ComputerController : Controller
    {

        private WorkforceDbContext context;

        public ComputerController(WorkforceDbContext ctx)
        {
            context = ctx;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {

            var Computers = context.Computer;

            if (Computers == null)
            {
                return NotFound();
            }

            return Ok(Computers);
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var Computer = context.Computer.Where(e => e.ComputerId == id);

            if (Computer == null)
            {
                return NotFound();
            }
            return Ok(Computer);
        }

        // POST api/values
        public IActionResult Post([FromBody] Computer Computer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.Computer.Add(Computer);
            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ComputerExists(Computer.ComputerId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetComputer", new { id = Computer.ComputerId }, Computer);
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
                Computer Computer = context.Computer.Single(u => u.ComputerId == id);
                if (Computer == null)
                {
                    return NotFound();
                }

                context.Computer.Remove(Computer);
                context.SaveChanges();

                return Ok();
            }
            catch (System.InvalidOperationException)
            {
                return NotFound();
            }
        }

        private bool ComputerExists(int id)
        {
            return context.Computer.Count(e => e.ComputerId == id) > 0;
        }
    }
}
