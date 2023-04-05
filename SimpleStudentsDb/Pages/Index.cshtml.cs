using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SimpleStudentsDb.Data;
using SimpleStudentsDb.Models;

namespace SimpleStudentsDb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly SimpleStudentsDb.Data.AppDbContext _context;

        public IndexModel(SimpleStudentsDb.Data.AppDbContext context) // injektáž kontextu
        {
            _context = context;
        }

        public IList<Student> Student { get;set; } = default!; // kolekce studentů

        public async Task OnGetAsync()
        {
            if (_context.Students != null)
            {
                Student = await _context.Students
                .Include(s => s.Classroom).ToListAsync(); // načtení studentů z db
            }
        }
    }
}
