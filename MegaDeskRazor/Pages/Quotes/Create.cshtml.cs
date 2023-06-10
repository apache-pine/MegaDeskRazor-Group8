using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MegaDeskRazor.Data;
using MegaDeskRazor.Models;

namespace MegaDeskRazor.Pages.Quotes
{
    public class CreateModel : PageModel
    {
        private readonly MegaDeskRazor.Data.MegaDeskRazorContext _context;

        public CreateModel(MegaDeskRazor.Data.MegaDeskRazorContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Desk Desk { get; set; }

        [BindProperty]
        public DeskQuote DeskQuote { get; set; }

        public IActionResult OnGet()
        {
            ViewData["DeliveryTypeId"] = new SelectList(_context.Set<DeliveryType>(), "DeliveryTypeId", "DeliveryName");
            ViewData["DesktopMaterialId"] = new SelectList(_context.Set<DesktopMaterial>(), "DesktopMaterialId", "DesktopMaterialName");
            
            return Page();
        }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            _context.Desk.Add(Desk);
            await _context.SaveChangesAsync();

            DeskQuote.QuoteDate = DateTime.Now;

            DeskQuote.DeskId = Desk.DeskId;

            DeskQuote.Desk = Desk;

            DeskQuote.QuotePrice = DeskQuote.GetQuotePrice(_context);

            _context.DeskQuote.Add(DeskQuote);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
