using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject
{
    public class Session
    {
        public int ID { get; set; }
        public Film Film { get; set; }
        public int FilmID { get; set; }
        public CinemaHall Hall { get; set; }
        public int HallID { get; set; }
        public DateTime DateTime {  get; set; }
        public double TicketPrice { get; set; }
        public SessionStatus SessionStatus { get; set; }
        public int SessionStatusID { get; set; }

        public override string ToString()
        {
            return $"[{ID}] - {Film?.Name}, Hall№ {Hall?.CinemaHallID}, {DateTime}, {TicketPrice} UAH, {SessionStatus?.SessionStatusName}";
        }
    }
}

/*
        cinema.Sessions.Add(new Session() { FilmID = 8, HallID = 3, DateTime = new DateTime(2025, 4, 25, 18, 20, 0), TicketPrice = 190, SessionStatusID = 1 });
        cinema.Sessions.Add(new Session() { FilmID = 5, HallID = 5, DateTime = new DateTime(2025, 4, 28, 11, 30, 0), TicketPrice = 270, SessionStatusID = 1 });
        cinema.Sessions.Add(new Session() { FilmID = 1, HallID = 1, DateTime = new DateTime(2025, 4, 23, 15, 30, 0), TicketPrice = 250, SessionStatusID = 1 });
        cinema.Sessions.Add(new Session() { FilmID = 6, HallID = 2, DateTime = new DateTime(2025, 4, 22, 19, 45, 0), TicketPrice = 200, SessionStatusID = 2 });
        cinema.Sessions.Add(new Session() { FilmID = 3, HallID = 6, DateTime = new DateTime(2025, 4, 25, 18, 20, 0), TicketPrice = 240, SessionStatusID = 1 });
        cinema.Sessions.Add(new Session() { FilmID = 8, HallID = 4, DateTime = new DateTime(2025, 4, 28, 13, 30, 0), TicketPrice = 190, SessionStatusID = 1 });
        cinema.Sessions.Add(new Session() { FilmID = 10, HallID = 4, DateTime = new DateTime(2025, 4, 20, 20, 10, 0), TicketPrice = 310, SessionStatusID = 1 });
        cinema.Sessions.Add(new Session() { FilmID = 9, HallID = 1, DateTime = new DateTime(2025, 4, 21, 11, 30, 0), TicketPrice = 280, SessionStatusID = 2 });
        cinema.Sessions.Add(new Session() { FilmID = 4, HallID = 3, DateTime = new DateTime(2025, 4, 25, 18, 20, 0), TicketPrice = 260, SessionStatusID = 2 });
        cinema.Sessions.Add(new Session() { FilmID = 2, HallID = 5, DateTime = new DateTime(2025, 5, 1, 19, 20, 0), TicketPrice = 300, SessionStatusID = 1 });
        cinema.Sessions.Add(new Session() { FilmID = 3, HallID = 2, DateTime = new DateTime(2025, 4, 30, 9, 35, 0), TicketPrice = 180, SessionStatusID = 2 });
        cinema.Sessions.Add(new Session() { FilmID = 5, HallID = 1, DateTime = new DateTime(2025, 4, 25, 12, 15, 0), TicketPrice = 250, SessionStatusID = 1 });
        cinema.Sessions.Add(new Session() { FilmID = 6, HallID = 6, DateTime = new DateTime(2025, 5, 2, 13, 40, 0), TicketPrice = 260, SessionStatusID = 1 });
        cinema.Sessions.Add(new Session() { FilmID = 3, HallID = 4, DateTime = new DateTime(2025, 4, 29, 10, 50, 0), TicketPrice = 196, SessionStatusID = 1 });

        cinema.SaveChanges();*/