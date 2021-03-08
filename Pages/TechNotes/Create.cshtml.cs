using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using RequestTracker.Models;
using System.Threading.Tasks;
using System;

namespace RequestTracker.Pages.TechNotes
{
    public class CreateModel : PageModel
    {
        private readonly RequestTracker.Data.RequestTrackerContext _context;

        public CreateModel(RequestTracker.Data.RequestTrackerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ServiceRequestID"] = new SelectList(_context.ServiceRequest, "ID", "ID");
            ViewData["TechnicianID"] = new SelectList(_context.Technician, "ID", "Name");
            return Page();
        }

        [BindProperty]
        public TechNote TechNote { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            TechNote.Date = DateTime.Now;

            _context.TechNote.Add(TechNote);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
