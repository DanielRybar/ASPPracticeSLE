using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StudentsWithIdentity.Pages
{
    [Authorize(Policy = "IsAdministrator")]
    public class AdminOnlyModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
