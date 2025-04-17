using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject
{
    public class FinancialReport
    {
        public void Show(AppDbContext context)
        {
            while (true)
            {
                Console.WriteLine("\n=== Financial Statistics Menu ===");
                Console.WriteLine("1 - Total income");
                Console.WriteLine("2 - Total tickets sold");
                Console.WriteLine("3 - Income by film");
                Console.WriteLine("4 - Income by session");
                Console.WriteLine("0 - Back to main menu");
                Console.Write("Select option: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        TotalIncome(context);
                        break;
                    case "2":
                        TotalTicketsSold(context);
                        break;
                    case "3":
                        IncomeByFilm(context);
                        break;
                    case "4":
                        IncomeBySession(context);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }

        public void TotalIncome(AppDbContext context)
        {
            var totalIncome = context.Sales.Sum(s => s.PaymentAmount);
            Console.WriteLine($"\n Total income: {totalIncome} UAH");
        }

        public void TotalTicketsSold(AppDbContext context)
        {
            var totalTickets = context.Tickets
                .Include(t => t.Status)
                .Count(t => t.Status.TicketStatusName == "Bought");
            Console.WriteLine($"\n🎟  Total tickets sold: {totalTickets}");
        }

        public void IncomeByFilm(AppDbContext context)
        {
            Console.WriteLine("\n Income by Film:");

            var incomeByFilm = context.Tickets
                .Include(t => t.Status)
                .Include(t => t.Session).ThenInclude(s => s.Film)
                .Where(t => t.Status.TicketStatusName == "Bought")
                .GroupBy(t => t.Session.Film.Name)
                .Select(g => new
                {
                    FilmName = g.Key,
                    TotalIncome = g.Sum(t => t.TicketPrice)
                });

            foreach (var film in incomeByFilm)
            {
                Console.WriteLine($"{film.FilmName}: {film.TotalIncome} grn");
            }
        }

        public void IncomeBySession(AppDbContext context)
        {
            Console.WriteLine("\n Income by Session:");

            var incomeBySession = context.Tickets
                .Include(t => t.Status)
                .Include(t => t.Session).ThenInclude(s => s.Film)
                .Where(t => t.Status.TicketStatusName == "Bought")
                .GroupBy(t => new { t.Session.ID, t.Session.DateTime, t.Session.Film.Name })
                .Select(g => new
                {
                    SessionID = g.Key.ID,
                    DateTime = g.Key.DateTime,
                    FilmName = g.Key.Name,
                    TotalIncome = g.Sum(t => t.TicketPrice)
                });

            foreach (var session in incomeBySession)
            {
                Console.WriteLine($"Session {session.SessionID} ({session.FilmName} at {session.DateTime}): {session.TotalIncome} grn");
            }
        }
    }
}
