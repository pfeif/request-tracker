using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RequestTracker.Models;
using System.Linq;
using System.Threading.Tasks;

namespace RequestTracker.Pages.TechNotes
{
    public class EditModel : PageModel
    {
        private readonly RequestTracker.Data.RequestTrackerContext _context;

        public EditModel(RequestTracker.Data.RequestTrackerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TechNote TechNote { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TechNote = await _context.TechNote
                .Include(t => t.ServiceRequest)
                .Include(t => t.Technician).FirstOrDefaultAsync(m => m.ID == id);

            if (TechNote == null)
            {
                return NotFound();
            }
           ViewData["ServiceRequestID"] = new SelectList(_context.ServiceRequest, "ID", "Description");
           ViewData["TechnicianID"] = new SelectList(_context.Technician, "ID", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TechNote).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TechNoteExists(TechNote.ID))
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

        private bool TechNoteExists(int id)
        {
            return _context.TechNote.Any(e => e.ID == id);
        }
    }
}
