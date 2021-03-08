using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RequestTracker.Models;
using System.Threading.Tasks;

namespace RequestTracker.Pages.TechNotes
{
    public class DetailsModel : PageModel
    {
        private readonly RequestTracker.Data.RequestTrackerContext _context;

        public DetailsModel(RequestTracker.Data.RequestTrackerContext context)
        {
            _context = context;
        }

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
    }
}
