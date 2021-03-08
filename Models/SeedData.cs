using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RequestTracker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestTracker.Models
{
    // The SeedData class will be responsible for filling the database with starter data.
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RequestTrackerContext(
                serviceProvider.GetRequiredService<DbContextOptions<RequestTrackerContext>>()))
            {
                // Check the tables for data. If any of them already contain data, then return.
                //  There's nothing more to do here.
                if (context.Client.Any() || context.Technician.Any()
                    || context.ServiceRequest.Any() || context.TechNote.Any())
                {
                    return;
                }

                // The clients are Brooklyn's finest from the Nine-Nine.
                context.Client.AddRange(
                    new Client { ID = 1, FirstName = "Jake", LastName = "Peralta", PhoneNumber = "+1-718-555-0156" },
                    new Client { ID = 2, FirstName = "Rosa", LastName = "Diaz", PhoneNumber = "+1-718-555-0105" },
                    new Client { ID = 3, FirstName = "Terry", LastName = "Jeffords", PhoneNumber = "+1-718-555-0182" },
                    new Client { ID = 4, FirstName = "Amy", LastName = "Santiago", PhoneNumber = "+1-718-555-0170" },
                    new Client { ID = 5, FirstName = "Charles", LastName = "Boyle", PhoneNumber = "+1-718-555-0164" },
                    new Client { ID = 6, FirstName = "Raymond", LastName = "Holt", PhoneNumber = "+1-718-555-0198" }
                    );

                // Save the changes to the database. Strictly speaking, I only need to save the
                //  changes once, after I've added all of the data. However, the seed data isn't
                //  large, and saving after every table helps in the event of an error.
                context.SaveChanges();

                // The IT crowd is from The IT Crowd.
                context.Technician.AddRange(
                    new Technician { ID = 1, FirstName = "Roy", LastName = "Trenneman", PhoneNumber = "+44 20 7946 0619" },
                    new Technician { ID = 2, FirstName = "Maurice", LastName = "Moss", PhoneNumber = "+44 20 7946 0120" },
                    new Technician { ID = 3, FirstName = "Richmond", LastName = "Avenal", PhoneNumber = "+44 20 7946 0412" },
                    new Technician { ID = 4, FirstName = "Jen", LastName = "Barber", PhoneNumber = "+44 20 7946 0249" }
                    );

                context.SaveChanges();

                // Now might be a good time to drop a reference for the DateTime.Parse method.
                //  https://docs.microsoft.com/en-us/dotnet/api/system.datetime.parse?view=netcore-3.1
                context.ServiceRequest.AddRange(
                    new ServiceRequest
                    {
                        ID = 1,
                        ClientID = 1,
                        OpenDate = DateTime.Parse("04/01/2020 09:18:33"),
                        Description = "I can't turn this thing on!",
                        Status = Status.Assigned,
                        TechnicianID = 4
                    },
                    new ServiceRequest
                    {
                        ID = 2,
                        ClientID = 6,
                        OpenDate = DateTime.Parse("04/02/2020 07:30:15"),
                        Description = "Something on my desktop is askew.",
                        Status = Status.InProcess,
                        TechnicianID = 1
                    },
                    new ServiceRequest
                    {
                        ID = 3,
                        ClientID = 2,
                        OpenDate = DateTime.Parse("04/03/2020 13:17:55"),
                        Description = "I threw my monitor through the wall. Bring me a new one.",
                        Status = Status.Completed,
                        TechnicianID = 2,
                        CloseDate = DateTime.Parse("04/03/2020 13:31:24")
                    },
                    new ServiceRequest
                    {
                        ID = 4,
                        ClientID = 3,
                        OpenDate = DateTime.Parse("04/04/2020 16:43:46"),
                        Description = "Aw man. Terry's yogurt got in the keyboard.",
                        Status = Status.Created
                    });

                context.SaveChanges();

                context.TechNote.AddRange(
                    new TechNote
                    {
                        ID = 1,
                        ServiceRequestID = 1,
                        TechnicianID = 4,
                        Date = DateTime.Parse("04/01/2020 13:15:46"),
                        Note = "Even I know where the power button is. It's over there next to the Internet."
                    },
                    new TechNote
                    {
                        ID = 2,
                        ServiceRequestID = 2,
                        TechnicianID = 2,
                        Date = DateTime.Parse("04/02/2020 10:38:54"),
                        Note = "I asked him if he tried turning it off and back on again."
                    },
                    new TechNote
                    {
                        ID = 3,
                        ServiceRequestID = 3,
                        TechnicianID = 2,
                        Date = DateTime.Parse("04/03/2020 08:36:22"),
                        Note = "I think I might need some womens' slacks for this one."
                    });

                context.SaveChanges();
            }
        }
    }
}
