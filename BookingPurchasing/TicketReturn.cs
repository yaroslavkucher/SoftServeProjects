using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject.BookingPurchasing
{
    public class TicketReturn
    {
        public void Start(AppDbContext context)
        {
            Console.WriteLine("=== Ticket Return ===");

            Console.Write("Enter Session ID: ");
            if (!int.TryParse(Console.ReadLine(), out int sessionId))
            {
                Console.WriteLine("Invalid Session ID.");
                return;
            }

            Console.Write("Enter Seat number: ");
            if (!int.TryParse(Console.ReadLine(), out int seat))
            {
                Console.WriteLine("Invalid seat number.");
                return;
            }

            var ticket = context.Tickets
                .Include(t => t.Status)
                .Include(t => t.Session).ThenInclude(s => s.Film)
                .FirstOrDefault(t => t.SessionID == sessionId && t.Seat == seat);

            if (ticket == null)
            {
                Console.WriteLine("Ticket not found.");
                return;
            }

            if (ticket.Status.TicketStatusName != "Bought")
            {
                Console.WriteLine("Only bought tickets can be returned.");
                return;
            }

            var returnedStatus = context.TicketStatuses.FirstOrDefault(s => s.TicketStatusName == "Returned");
            if (returnedStatus == null)
            {
                Console.WriteLine("Returned status not found.");
                return;
            }

            ticket.TicketStatusID = returnedStatus.TicketStatusID;

            context.SaveChanges();
            Console.WriteLine($"Ticket for film \"{ticket.Session.Film.Name}\" successfully returned.");
        }
    }
}
