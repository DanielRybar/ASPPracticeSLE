using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentsWithIdentity.Data;
using StudentsWithIdentity.Models;
using System.Security.Claims;

namespace StudentsWithIdentity.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private AppDbContext _context;

        public IndexModel(ILogger<IndexModel> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public List<Student> Students { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }

        public void OnGet()
        {
            Students = _context.Students.Include(c => c.Classroom).ToList();

            if (User.Identity!.IsAuthenticated)
            {
                var userId = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault()!.Value;
                if (userId != null)
                {
                    UserId = userId;
                    UserName = _context.Users.Where(x => x.Id == UserId).FirstOrDefault()!.UserName;
                }
            }
        }
    }
}