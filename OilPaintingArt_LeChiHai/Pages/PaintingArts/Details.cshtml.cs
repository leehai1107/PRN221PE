using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects;
using DataAccessLayer;

namespace OilPaintingArt_LeChiHai.Pages.PaintingArts
{
    public class DetailsModel : PageModel
    {
        private readonly DataAccessLayer.OilPaintingArt2024DbContext _context;

        public DetailsModel(DataAccessLayer.OilPaintingArt2024DbContext context)
        {
            _context = context;
        }

        public OilPaintingArt OilPaintingArt { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oilpaintingart = await _context.OilPaintingArts.FirstOrDefaultAsync(m => m.OilPaintingArtId == id);
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
    }
}
