using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject
{
    public class SessionStatus
    {
        public int SessionStatusID { get; set; }
        public string SessionStatusName { get; set; }
        public ICollection<Session> Sessions { get; set; }

        public override string ToString()
        {
            return $"[{SessionStatusID}] - {SessionStatusName}";
        }
    }
}
