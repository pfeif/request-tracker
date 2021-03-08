using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RequestTracker.Data;
using RequestTracker.Models;

namespace RequestTracker.Pages.ServiceRequests
{
    public class EditModel : PageModel
    {
        private readonly RequestTracker.Data.RequestTrackerContext _context;

        public EditModel(RequestTracker.Data.RequestTrackerContext context)
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

            ViewData["Client"] = new SelectList(_context.Client, "ID", "Name");
            ViewData["Technician"] = new SelectList(_context.Technician, "ID", "Name");
            ViewData["Status"] = new SelectList(Enum.GetValues(typeof(Status)));

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

            _context.Attach(ServiceRequest).State = EntityState.Modified;

            // Detects concurrency exceptions when two clients (not IT clients) are trying to edit
            //  or delete data at the same time.
            // TODO: Implement store wins handling.
            //  https://docs.microsoft.com/en-us/aspnet/core/data/ef-rp/concurrency?view=aspnetcore-3.1&tabs=visual-studio
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceRequestExists(ServiceRequest.ID))
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

        private bool ServiceRequestExists(int id)
        {
            return _context.ServiceRequest.Any(e => e.ID == id);
        }
    }
}
