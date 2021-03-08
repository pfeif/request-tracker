using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RequestTracker.Data;
using RequestTracker.Models;

namespace RequestTracker.Pages.Technicians
{
    public class DetailsModel : PageModel
    {
        private readonly RequestTracker.Data.RequestTrackerContext _context;

        public DetailsModel(RequestTracker.Data.RequestTrackerContext context)
        {
            _context = context;
        }

        public Technician Technician { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Technician = await _context.Technician.FirstOrDefaultAsync(m => m.ID == id);

            if (Technician == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
