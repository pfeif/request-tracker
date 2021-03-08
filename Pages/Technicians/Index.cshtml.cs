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
    public class IndexModel : PageModel
    {
        private readonly RequestTracker.Data.RequestTrackerContext _context;

        public IndexModel(RequestTracker.Data.RequestTrackerContext context)
        {
            _context = context;
        }

        public IList<Technician> Technician { get;set; }

        public async Task OnGetAsync()
        {
            Technician = await _context.Technician.ToListAsync();
        }
    }
}
