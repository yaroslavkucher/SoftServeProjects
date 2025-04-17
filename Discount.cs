using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject
{
    public class Discount
    {
        public int ID { get; set; }
        public Film Film { get; set; }
        public int FilmID { get; set; }
        public double DiscountPercent { get; set; }
        public double RegUsersDiscountPercent { get; set; }

        public override string ToString()
        {
            return $"[{ID}] - {Film}, {DiscountPercent}, {RegUsersDiscountPercent}";
        }
    }
}
