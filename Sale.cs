using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject
{
    public class Sale
    {
        public int ID { get; set; }
        public User User { get; set; }
        public int UserID { get; set; }
        public int NumberOfTickets { get; set; }
        public double PaymentAmount { get; set; }
        public DateTime SaleDate { get; set; }

        public override string ToString()
        {
            return $"[{ID}] - {User.Name}, {NumberOfTickets}, {PaymentAmount}, {SaleDate.Date}";
        }
    }
}
