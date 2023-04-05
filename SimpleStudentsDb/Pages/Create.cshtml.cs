using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SimpleStudentsDb.Data;
using SimpleStudentsDb.Models;

namespace SimpleStudentsDb.Pages
{
    public class CreateModel : PageModel
    {
        private readonly SimpleStudentsDb.Data.AppDbContext _context;

        public CreateModel(SimpleStudentsDb.Data.AppDbContext context)
        {
            _context = context;
        }

        public SelectList ClassroomList { get; set; }

        public IActionResult OnGet()
        {
            ClassroomList = new SelectList(_context.Classrooms, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Student Student { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (/*!ModelState.IsValid ||*/ _context.Students == null || Student == null)
            {
                return Page();
            }

            _context.Students.Add(Student);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
