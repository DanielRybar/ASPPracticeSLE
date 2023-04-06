using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace SessionDemo.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly IHttpContextAccessor _hca; // HttpContextAccessor zpřístupní HttpContext
        private ISession _session => _hca.HttpContext.Session;

        private const string SessionKey = "MY_SESS"; // identifikátor session proměnné
        public string Result { get; set; }

        public PrivacyModel(IHttpContextAccessor hca)
        {
            _hca = hca;
        }

        public void OnGet()
        {
            Result = _session.GetString(SessionKey);
        }
    }
}