using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject
{
    public class CinemaHall
    {
        public int CinemaHallID { get; set; }
        public int NumberOfSeats { get; set; }
        public HallType HallType { get; set; }
        public int HallTypeID { get; set; }
        public ICollection<Session> Sessions { get; set; }

        public override string ToString()
        {
            return $"[{CinemaHallID}] - {NumberOfSeats}, {HallType.HallName}";
        }
    }
}

/*
        cinema.Halls.Add(new CinemaHall() { NumberOfSeats = 50, HallTypeID  = 1 });
        cinema.Halls.Add(new CinemaHall() { NumberOfSeats = 150, HallTypeID = 1 });
        cinema.Halls.Add(new CinemaHall() { NumberOfSeats = 68, HallTypeID = 1 });
        cinema.Halls.Add(new CinemaHall() { NumberOfSeats = 15, HallTypeID = 2 });
        cinema.Halls.Add(new CinemaHall() { NumberOfSeats = 20, HallTypeID = 2 });
        cinema.Halls.Add(new CinemaHall() { NumberOfSeats = 80, HallTypeID = 1 });

        cinema.SaveChanges();*/