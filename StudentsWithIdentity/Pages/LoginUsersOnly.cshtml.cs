using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StudentsWithIdentity.Pages
{
    [Authorize]
    public class LoginUsersOnlyModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
