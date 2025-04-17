using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject
{
    public class TicketBooking
    {
        public void Start(AppDbContext context)
        {
            Console.WriteLine("=== Ticket Booking ===");

            Console.Write("Enter Session ID: ");
            if (!int.TryParse(Console.ReadLine(), out int sessionId))
            {
                Console.WriteLine("Invalid Session ID.");
                return;
            }

            var session = context.Sessions
                .Include(s => s.Hall)
                .Include(s => s.Film)
                .FirstOrDefault(s => s.ID == sessionId);

            if (session == null)
            {
                Console.WriteLine("Session not found.");
                return;
            }

            // Показати доступні місця
            var bookedSeats = context.Tickets
                .Where(t => t.SessionID == sessionId && t.Status.TicketStatusName != "Available")
                .Select(t => t.Seat)
                .ToList();

            Console.WriteLine($"Available seats (1-{session.Hall.NumberOfSeats}):");

            for (int seat = 1; seat <= session.Hall.NumberOfSeats; seat++)
            {
                if (bookedSeats.Contains(seat))
                    Console.Write(" [X]");
                else
                    Console.Write($" [{seat}]");
            }

            Console.WriteLine("\nSelect seat number: ");
            if (!int.TryParse(Console.ReadLine(), out int selectedSeat) || selectedSeat < 1 || selectedSeat > session.Hall.NumberOfSeats)
            {
                Console.WriteLine("Invalid seat number.");
                return;
            }

            if (bookedSeats.Contains(selectedSeat))
            {
                Console.WriteLine("Seat is already booked.");
                return;
            }

            var reservedStatus = context.TicketStatuses.FirstOrDefault(s => s.TicketStatusName == "Reserved");
            if (reservedStatus == null)
            {
                Console.WriteLine("Reserved status not found.");
                return;
            }

            var ticket = new Ticket
            {
                SessionID = sessionId,
                Seat = selectedSeat,
                TicketPrice = session.TicketPrice,
                TicketStatusID = reservedStatus.TicketStatusID
            };

            context.Tickets.Add(ticket);
            context.SaveChanges();
            Console.WriteLine("Seat successfully booked!");
        }
    }
}
