using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public UserType Type { get; set; }
        public int UserTypeID { get; set; }
        public int Bonuses { get; set; }
        public ICollection<Sale> Sales { get; set; }

        public override string ToString()
        {
            return $"[{ID}] - {Name}, {Email}, {Type}, {Bonuses}";
        }
    }
}

/*var regular = cinema.UserTypes.FirstOrDefault(u => u.UserTypeName == "Common user");
        var admin = cinema.UserTypes.FirstOrDefault(u => u.UserTypeName == "Administrator");

        var users = new List<User>
        {
            new User { Name = "Alice", Email = "alice@example.com", UserTypeID = regular.UserTypeID, Bonuses = 5 },
            new User { Name = "Bob", Email = "bob@example.com", UserTypeID = admin.UserTypeID, Bonuses = 15 },
            new User { Name = "Charlie", Email = "charlie@example.com", UserTypeID = regular.UserTypeID, Bonuses = 3 },
            new User { Name = "Diana", Email = "diana@example.com", UserTypeID = admin.UserTypeID, Bonuses = 20 },
            new User { Name = "Eve", Email = "eve@example.com", UserTypeID = regular.UserTypeID, Bonuses = 2 },
            new User { Name = "Frank", Email = "frank@example.com", UserTypeID = admin.UserTypeID, Bonuses = 18 },
            new User { Name = "Grace", Email = "grace@example.com", UserTypeID = regular.UserTypeID, Bonuses = 7 },
            new User { Name = "Heidi", Email = "heidi@example.com", UserTypeID = admin.UserTypeID, Bonuses = 10 },
            new User { Name = "Ivan", Email = "ivan@example.com", UserTypeID = regular.UserTypeID, Bonuses = 4 },
            new User { Name = "Judy", Email = "judy@example.com", UserTypeID = admin.UserTypeID, Bonuses = 12 },
        };

        cinema.Users.AddRange(users);
        cinema.SaveChanges();*/
