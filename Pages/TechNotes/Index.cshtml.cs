using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RequestTracker.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RequestTracker.Pages.TechNotes
{
    public class IndexModel : PageModel
    {
        private readonly RequestTracker.Data.RequestTrackerContext _context;

        public IndexModel(RequestTracker.Data.RequestTrackerContext context)
        {
            _context = context;
        }

        public IList<TechNote> TechNote { get;set; }

        public async Task OnGetAsync()
        {
            TechNote = await _context.TechNote
                .Include(t => t.ServiceRequest)
                .Include(t => t.Technician).ToListAsync();
        }
    }
}
