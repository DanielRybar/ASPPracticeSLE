using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace SessionDemo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IHttpContextAccessor _hca; // HttpContextAccessor zpřístupní HttpContext
        private ISession _session => _hca.HttpContext.Session;

        private const string SessionKey = "MY_SESS"; // identifikátor session proměnné
        public string ResultName { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Atribut je vyžadován.")]
        [MinLength(4, ErrorMessage = "Minimální délka jsou 4 znaky.")]
        public string Name { get; set; }

        public IndexModel(IHttpContextAccessor hca)
        {
            _hca = hca;
        }

        public void OnGet()
        {                
            ResultName = _session.GetString(SessionKey); // získáme hodnotu Session a uložíme ji do vlastnosti ResultName
        }

        public void OnPost()
        {
            _session.SetString(SessionKey, Name); // nastavíme hodnotu Session  
            ResultName = _session.GetString(SessionKey);
        }
    }
}