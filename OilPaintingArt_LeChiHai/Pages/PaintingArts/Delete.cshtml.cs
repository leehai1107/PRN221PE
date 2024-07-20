using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;

namespace OilPaintingArt_LeChiHai.Pages.PaintingArts
{
    public class DeleteModel : PageModel
    {
        private readonly PaintingRepo _paintingsRepo = new PaintingRepo();

        public DeleteModel()
        {
        }

        [BindProperty]
        public OilPaintingArt OilPaintingArt { get; set; } = default!;

        public IActionResult OnGet(int? id)
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                return RedirectToPage("/Index");
            }

            if (id == null)
            {
                return NotFound();
            }

            var oilpaintingart = _paintingsRepo.GetPaintingById(id.Value);

            if (oilpaintingart == null)
            {
                return NotFound();
            }
            else
            {
                OilPaintingArt = oilpaintingart;
            }
            return Page();
        }

        public IActionResult OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oilpaintingart = _paintingsRepo.GetPaintingById(id.Value);
            if (oilpaintingart != null)
            {
                _paintingsRepo.DeletePainting(oilpaintingart.OilPaintingArtId);
            }

            return RedirectToPage("/Index");
        }
    }
}
