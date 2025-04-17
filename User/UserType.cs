using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject
{
    public class UserType
    {
        public int UserTypeID { get; set; }
        public string UserTypeName { get; set; }
        public ICollection<User> Users { get; set; }

        public override string ToString()
        {
            return $"[{UserTypeID}] - {UserTypeName}";
        }
    }
}
