using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject
{
    public class TicketPurchase
    {
        public void Start(AppDbContext context)
        {
            Console.WriteLine("=== Ticket Purchase ===");

            Console.Write("Enter User ID: ");
            if (!int.TryParse(Console.ReadLine(), out int userId))
            {
                Console.WriteLine("Invalid User ID.");
                return;
            }

            var user = context.Users.FirstOrDefault(u => u.ID == userId);
            if (user == null)
            {
                Console.WriteLine("User not found.");
                return;
            }

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

            if (ticket.Status.TicketStatusName != "Reserved")
            {
                Console.WriteLine($"Ticket is not reserved. Current status: {ticket.Status.TicketStatusName}");
                return;
            }

            var boughtStatus = context.TicketStatuses.FirstOrDefault(s => s.TicketStatusName == "Bought");
            if (boughtStatus == null)
            {
                Console.WriteLine("Bought status not found.");
                return;
            }

            double originalPrice = ticket.TicketPrice;
            double discountAmount = 0;

            var discount = context.Discounts.FirstOrDefault(d => d.FilmID == ticket.Session.Film.ID);
            int salesCount = context.Sales.Count(s => s.UserID == userId);

            if (discount != null)
            {
                if (salesCount >= 3)
                {
                    discountAmount = originalPrice * (discount.RegUsersDiscountPercent / 100);
                    Console.WriteLine($"Regular user discount: -{discount.RegUsersDiscountPercent}%");
                }
                else
                {
                    discountAmount = originalPrice * (discount.DiscountPercent / 100);
                    Console.WriteLine($"Standard discount: -{discount.DiscountPercent}%");
                }
            }

            double finalPrice = originalPrice - discountAmount;
            if (finalPrice < 0) finalPrice = 0;

            // Можливість витратити бонуси
            Console.WriteLine($"\nFinal price before bonuses: {finalPrice:F2} UAH");
            Console.WriteLine($"User {user.Name} has {user.Bonuses} bonus points.");
            Console.Write("Use bonus points to reduce price? (y/n): ");
            string useBonusesInput = Console.ReadLine().ToLower();

            if (useBonusesInput == "y" && user.Bonuses > 0)
            {
                int bonusToUse = (int)Math.Min(user.Bonuses, finalPrice);
                finalPrice -= bonusToUse;
                user.Bonuses -= bonusToUse;

                Console.WriteLine($"Applied {bonusToUse} bonuses. New price: {finalPrice:F2} UAH");
            }

            // Оновлення квитка
            ticket.TicketPrice = finalPrice;
            ticket.TicketStatusID = boughtStatus.TicketStatusID;

            // Запис продажу
            var sale = new Sale
            {
                UserID = userId,
                NumberOfTickets = 1,
                PaymentAmount = finalPrice,
                SaleDate = DateTime.Now
            };

            context.Sales.Add(sale);

            // Нарахування нових бонусів
            int earnedBonuses = (int)(finalPrice / 10);
            user.Bonuses += earnedBonuses;

            context.SaveChanges();

            Console.WriteLine($"\nTicket purchased successfully!");
            Console.WriteLine($"Final price: {finalPrice:F2} UAH");
            Console.WriteLine($"Earned bonuses: {earnedBonuses}. Current total: {user.Bonuses}.");
        }
    }
}
