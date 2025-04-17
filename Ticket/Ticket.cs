using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject
{
    public class Ticket
    {
        public int TicketID {  get; set; }
        public Session Session { get; set; }
        public int SessionID { get; set; }
        public int Seat { get; set; }
        public double TicketPrice { get; set; }
        public TicketStatus Status { get; set; }
        public int TicketStatusID { get; set; }

        public override string ToString()
        {
            return $"[{TicketID}] - {SessionID}, {Seat}, {TicketPrice}, {Status.TicketStatusName}";
        }
    }
}
