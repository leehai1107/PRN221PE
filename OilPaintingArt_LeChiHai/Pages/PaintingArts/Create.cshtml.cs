using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;

namespace OilPaintingArt_LeChiHai.Pages.PaintingArts
{
    public class CreateModel : PageModel
    {
        private readonly PaintingRepo _paintingsRepo = new PaintingRepo();
        private readonly SupplierRepo _supplierRepo = new SupplierRepo();

        public CreateModel()
        {
        }
        [BindProperty]
        public IList<SupplierCompany> SupplierCompanies { get; set; }

        public IActionResult OnGet()
        {
            SupplierCompanies = _supplierRepo.GetSuppliers();
            return Page();
        }

        [BindProperty]
        public OilPaintingArt OilPaintingArt { get; set; } = default!;
        [BindProperty]
        public string Message { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
            try
            {


                _paintingsRepo.AddPainting(OilPaintingArt);

                return RedirectToPage("/Index");

            }
            catch (Exception ex)
            {
                Message = ex.Message;
                OnGet();
                return Page();
            }


        }
    }
}
