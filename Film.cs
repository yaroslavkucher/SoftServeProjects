using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject
{
    public class Film
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public int Duration { get; set; }
        public int Release_year { get; set; }
        public int Age_restrictions { get; set; }
        public string Description { get; set; }
        public Discount Discount { get; set; }
        public int DiscountID { get; set; }
        public ICollection<Session> Sessions { get; set; }

        public override string ToString()
        {
            return $"[{ID}] - {Name}, {Genre}, {Director}, {Duration}m, {Release_year}, {Age_restrictions}, {Description}";
        }
    }
}

/*
        cinema.Films.Add(new Film() {Name = "The Shawshank Redemption", Genre = "Drama", Director = "Frank Darabont", Duration = 142, Release_year = 1994, Age_restrictions = 17, Description = "A powerful story of hope, resilience, and friendship based on Stephen King's novella."});
        cinema.Films.Add(new Film() { Name = "The Godfather", Genre = "Crime Drama", Director = "Francis Ford Coppola", Duration = 175, Release_year = 1972, Age_restrictions = 17, Description = "An iconic saga of mafia power and family loyalty." });
        cinema.Films.Add(new Film() { Name = "The Dark Knight", Genre = "Superhero Action", Director = "Christopher Nolan", Duration = 152, Release_year = 2008, Age_restrictions = 13, Description = "Batman faces off against the chaotic Joker in Gotham’s dark underworld." });
        cinema.Films.Add(new Film() { Name = "Schindler’s List", Genre = "Historical Drama", Director = "Steven Spielberg", Duration = 195, Release_year = 1993, Age_restrictions = 17, Description = "A moving depiction of humanity during the horrors of the Holocaust." });
        cinema.Films.Add(new Film() { Name = "Forrest Gump", Genre = "Drama", Director = "Robert Zemeckis", Duration = 142, Release_year = 1994, Age_restrictions = 13, Description = "An ordinary man unwittingly becomes part of America’s greatest moments." });
        cinema.Films.Add(new Film() { Name = "Fight Club", Genre = "Psychological Thriller", Director = "David Fincher", Duration = 139, Release_year = 1999, Age_restrictions = 17, Description = "A cult classic about consumerism, rebellion, and inner turmoil." });
        cinema.Films.Add(new Film() { Name = "The Lord of the Rings: The Return of the King", Genre = "Fantasy", Director = "Peter Jackson", Duration = 201, Release_year = 2003, Age_restrictions = 13, Description = "An epic conclusion to Tolkien’s legendary trilogy." });
        cinema.Films.Add(new Film() { Name = "Star Wars: The Empire Strikes Back", Genre = "Sci-Fi", Director = "Irvin Kershner", Duration = 124, Release_year = 1980, Age_restrictions = 10, Description = "The Rebels face their toughest challenge in their battle against the Empire." });
        cinema.Films.Add(new Film() { Name = "Inception", Genre = "Sci-Fi Thriller", Director = "Christopher Nolan", Duration = 148, Release_year = 2010, Age_restrictions = 13, Description = "A mind-bending journey into dreams and reality." });
        cinema.Films.Add(new Film() { Name = "The Matrix", Genre = "Sci-Fi", Director = "Lana & Lilly Wachowski", Duration = 136, Release_year = 1999, Age_restrictions = 17, Description = "A revolutionary look at virtual reality and human freedom." });

        cinema.SaveChanges();*/
