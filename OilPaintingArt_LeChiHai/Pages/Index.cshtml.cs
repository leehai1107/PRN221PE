using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;

namespace OilPaintingArt_LeChiHai.Pages
{
    public class IndexModel : PageModel
    {
        private readonly SystemAccountRepo _systemAccountRepo = new SystemAccountRepo();
        private readonly PaintingRepo _paintingRepo = new PaintingRepo();

        public IndexModel()
        {
        }

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }
        [BindProperty]
        public string Message { get; set; }
        [BindProperty]
        public bool IsLogin { get; set; }
        [BindProperty]
        public bool IsManager { get; set; }
        public IList<OilPaintingArt> OilPaintingArt { get; set; } = default!;


        public void OnGet()
        {
            OilPaintingArt = _paintingRepo.GetPaintings();

        }

        public IActionResult OnPost()
        {
            try
            {
                var user = _systemAccountRepo.GetSystemAccountByAccountEmail(Username);
                if (user == null)
                {
                    throw new Exception("You don't have permission to access this page");

                }
                else if (user.AccountPassword != Password)
                {
                    throw new Exception("You don't have permission to access this page");

                }
                else if (user.Role == 1)
                {
                    throw new Exception("You don't have permission to access this page");
                }
                else if (user.Role == 4)
                {
                    throw new Exception("You don't have permission to access this page");

                }

                if (user.Role == 3)
                {
                    IsManager = true;
                }

                HttpContext.Session.SetString("Username", Username);
                HttpContext.Session.SetString("Role", user.Role.ToString());

                OilPaintingArt = _paintingRepo.GetPaintings();
                return Page();

            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return Page();
            }

        }
    }
}
