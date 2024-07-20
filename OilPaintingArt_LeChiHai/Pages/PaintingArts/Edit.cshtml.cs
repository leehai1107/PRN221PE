﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObjects;
using DataAccessLayer;

namespace OilPaintingArt_LeChiHai.Pages.PaintingArts
{
    public class EditModel : PageModel
    {
        private readonly DataAccessLayer.OilPaintingArt2024DbContext _context;

        public EditModel(DataAccessLayer.OilPaintingArt2024DbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public OilPaintingArt OilPaintingArt { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oilpaintingart =  await _context.OilPaintingArts.FirstOrDefaultAsync(m => m.OilPaintingArtId == id);
            if (oilpaintingart == null)
            {
                return NotFound();
            }
            OilPaintingArt = oilpaintingart;
           ViewData["SupplierId"] = new SelectList(_context.SupplierCompanies, "SupplierId", "SupplierId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(OilPaintingArt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OilPaintingArtExists(OilPaintingArt.OilPaintingArtId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool OilPaintingArtExists(int id)
        {
            return _context.OilPaintingArts.Any(e => e.OilPaintingArtId == id);
        }
    }
}
