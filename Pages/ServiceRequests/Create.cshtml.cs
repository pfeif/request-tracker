using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RequestTracker.Data;
using RequestTracker.Models;

namespace RequestTracker.Pages.ServiceRequests
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
            ViewData["Client"] = new SelectList(_context.Client, "ID", "Name");
            return Page();
        }

        // The BindProperty attribute enables model binding which allows the property to be linked
        //  to the controller.
        //  https://docs.microsoft.com/en-us/aspnet/core/mvc/models/model-binding?view=aspnetcore-3.1
        [BindProperty]
        public ServiceRequest ServiceRequest { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            // Catch model errors on the client's side.
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Manually set the service request's open data and status.
            ServiceRequest.OpenDate = DateTime.Now;
            ServiceRequest.Status = Status.Created;

            _context.ServiceRequest.Add(ServiceRequest);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
