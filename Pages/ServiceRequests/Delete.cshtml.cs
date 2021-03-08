using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RequestTracker.Data;
using RequestTracker.Models;

namespace RequestTracker.Pages.ServiceRequests
{
    public class DeleteModel : PageModel
    {
        private readonly RequestTracker.Data.RequestTrackerContext _context;

        public DeleteModel(RequestTracker.Data.RequestTrackerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ServiceRequest ServiceRequest { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ServiceRequest = await _context.ServiceRequest
                .Include(s => s.Client)
                .Include(s => s.Technician).FirstOrDefaultAsync(m => m.ID == id);

            if (ServiceRequest == null)
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

            ServiceRequest = await _context.ServiceRequest.FindAsync(id);

            if (ServiceRequest != null)
            {
                _context.ServiceRequest.Remove(ServiceRequest);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
