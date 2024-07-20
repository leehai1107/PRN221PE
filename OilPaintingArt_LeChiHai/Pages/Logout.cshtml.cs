using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OilPaintingArt_LeChiHai.Pages
{
    public class LogoutModel : PageModel
    {
        public void OnGet()
        {
            HttpContext.Session.Clear();
            HttpContext.Response.Redirect("/");
        }
    }
}
