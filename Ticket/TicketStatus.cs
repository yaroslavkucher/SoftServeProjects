using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject
{
    public class TicketStatus
    {
        public int TicketStatusID { get; set; }
        public string TicketStatusName { get; set; }
        public ICollection<Ticket> Tickets { get; set; }

        public override string ToString()
        {
            return $"[{TicketStatusID}] - {TicketStatusName}";
        }
    }
}
