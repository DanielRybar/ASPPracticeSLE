using ApiSimple.Data;
using ApiSimple.Models;
using ApiSimple.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiSimple.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassroomsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClassroomsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Classrooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Classroom>>> GetClassrooms()
        {
            if (_context.Classrooms == null)
            {
                return NotFound();
            }
            return await _context.Classrooms.ToListAsync();
        }

        // GET: api/Classrooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Classroom>> GetClassroom(int id)
        {
            if (_context.Classrooms == null)
            {
                return NotFound();
            }
            var classroom = await _context.Classrooms.FindAsync(id);

            if (classroom == null)
            {
                return NotFound();
            }

            return classroom;
        }

        // PUT: api/Classrooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClassroom(int id, Classroom classroom)
        {
            if (id != classroom.Id)
            {
                return BadRequest();
            }

            _context.Entry(classroom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassroomExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Classrooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Classroom>> PostClassroom([FromBody] ClassroomVM classroom)  // frombody přes vm
        {
            if (_context.Classrooms == null)
            {
                return Problem("Entity set 'AppDbContext.Classrooms'  is null.");
            }

            var newClassroom = new Classroom
            {
                Name = classroom.Name
            };

            _context.Classrooms.Add(newClassroom);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClassroom", new { id = newClassroom.Id }, newClassroom);
        }

        // DELETE: api/Classrooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClassroom(int id)
        {
            if (_context.Classrooms == null)
            {
                return NotFound();
            }
            var classroom = await _context.Classrooms.FindAsync(id);
            if (classroom == null)
            {
                return NotFound();
            }

            _context.Classrooms.Remove(classroom);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClassroomExists(int id)
        {
            return (_context.Classrooms?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        // own endpoints
        [HttpGet("{id}/students")]
        public async Task<ActionResult<Classroom>> GetClassroomStudents(int id)
        {
            var classroom = await _context.Classrooms.FindAsync(id);

            if (classroom == null)
            {
                return NotFound("Class does not exist");
            }

            _context.Entry(classroom).Collection(c => c.Students).Load();

            //return Ok(classroom);
            return Ok(classroom.Students);
        }

        //[HttpPost("{id}/students/{studentId}")]
        [HttpPost("{id}/students")]
        public async Task<ActionResult> AddStudentToClass(int id, [FromBody] IdVM student)
        {
            var classroom = await _context.Classrooms.FindAsync(id);

            if (classroom == null)
            {
                return NotFound("Class does not exist");
            }

            var st = await _context.Students.FindAsync(student.Id);

            if (st == null)
            {
                return NotFound("Student does not exist");
            }

            var stInClass =
                await _context.Students.Where(s => s.Id == student.Id && s.ClassroomId == id).SingleOrDefaultAsync();

            if (stInClass == null)
            {
                st.ClassroomId = id;
                await _context.SaveChangesAsync();
                return Ok(st);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpDelete("{id}/students/{studentId}")]
        public async Task<ActionResult> RemoveStudentFromClass(int id, [FromBody] int studentId)
        {
            var classroom = await _context.Classrooms.FindAsync(id);

            if (classroom == null)
            {
                return NotFound("Class does not exist");
            }

            var st = await _context.Students.FindAsync(studentId);

            if (st == null)
            {
                return NotFound("Student does not exist");
            }

            var stInClass =
                await _context.Students.Where(s => s.Id == studentId && s.ClassroomId == id).SingleOrDefaultAsync();

            if (stInClass == null)
            {
                return BadRequest();
            }
            else
            {
                st.ClassroomId = null;
                await _context.SaveChangesAsync();
                return Ok();
            }
        }

        [HttpDelete("{id}/students")]
        public async Task<ActionResult> ClearStudentsFromClass(int id)
        {
            var classroom = await _context.Classrooms.FindAsync(id);

            if (classroom == null)
            {
                return NotFound("Class does not exist");
            }

            _context.Entry(classroom).Collection(c => c.Students).Load();
            classroom.Students.Clear();
            await _context.SaveChangesAsync();
            return Ok();
        }

        /*
        // patch
        [HttpPatch("{id}")]
        public async Task<ActionResult> PatchClassroom(int id, [FromBody] JsonPatchDocument<Classroom> patch)
        {
            var classroom = await _context.Classrooms.FindAsync(id);

            if (classroom == null)
            {
                return NotFound("Class does not exist");
            }

            if (patch != null)
            {
                patch.ApplyTo(classroom);
                await _context.SaveChangesAsync();
                return Ok(classroom);
            }
            else
            {
                return BadRequest("Patch data are missing");
            }
        }

    /*
    [
        {
          "operationType": 1,
          "path": "type",
          "op": "replace",
          "from": "1",
          "value": "2"
        }
    ]
    */
    }
}