using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject
{
    public class HallType
    {
        public int ID { get; set; }
        public string HallName { get; set; }
        public ICollection<CinemaHall> CinemaHalls { get; set; }

        public override string ToString()
        {
            return $"[{ID}] - {HallName}";
        }
    }
}
