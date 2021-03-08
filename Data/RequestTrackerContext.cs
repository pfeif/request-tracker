using Microsoft.EntityFrameworkCore;

namespace RequestTracker.Data
{
    public class RequestTrackerContext : DbContext
    {
        public RequestTrackerContext(DbContextOptions<RequestTrackerContext> options) : base(options)
        { }

        public DbSet<RequestTracker.Models.Client> Client { get; set; }
        public DbSet<RequestTracker.Models.Technician> Technician { get; set; }
        public DbSet<RequestTracker.Models.ServiceRequest> ServiceRequest { get; set; }
        public DbSet<RequestTracker.Models.TechNote> TechNote { get; set; }
    }
}
