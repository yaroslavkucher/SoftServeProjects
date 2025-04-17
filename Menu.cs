using CinemaProject.BookingPurchasing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject
{
    public class Menu
    {
        public void Show(AppDbContext cinema)
        {
            Console.WriteLine("Main menu:");
            while (true)
            {
                Console.WriteLine("What are you want to do?");
                Console.WriteLine("Sessions editing(se), Halls editing(he), Book a seat(book), Tickets Purchasing(purch), Ticket Return(tr), Financial report(fr), Exit(exit)");
                Console.WriteLine("Enter: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "se":
                        var sessionEditor = new SessionEditor();
                        sessionEditor.Show(cinema);
                        Console.WriteLine("Main menu:");
                        break;
                    case "he":
                        var hallEditor = new HallEditor();
                        hallEditor.Show(cinema);
                        Console.WriteLine("Main menu:");
                        break;
                    case "book":
                        var ticketBooking = new TicketBooking();
                        ticketBooking.Start(cinema);
                        Console.WriteLine("Main menu:");
                        break;
                    case "purch":
                        var ticketPurchase = new TicketPurchase();
                        ticketPurchase.Start(cinema);
                        Console.WriteLine("Main menu:");
                        break;
                    case "tr":
                        var returner = new TicketReturn();
                        returner.Start(cinema);
                        Console.WriteLine("Main menu:");
                        break;
                    case "fr":
                        var financialReport = new FinancialReport();
                        financialReport.Show(cinema);
                        Console.WriteLine("Main menu:");
                        break;
                    case "exit":
                        return;
                    default:
                        Console.WriteLine("Incorrect option. Try again.");
                        break;
                }
            }
        }
    }
}
