using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RequestTracker.Models;
using System.Threading.Tasks;

namespace RequestTracker.Pages.TechNotes
{
    public class DeleteModel : PageModel
    {
        private readonly RequestTracker.Data.RequestTrackerContext _context;

        public DeleteModel(RequestTracker.Data.RequestTrackerContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TechNote = await _context.TechNote.FindAsync(id);

            if (TechNote != null)
            {
                _context.TechNote.Remove(TechNote);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
