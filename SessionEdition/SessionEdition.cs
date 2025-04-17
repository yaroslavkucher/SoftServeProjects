using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject
{
    public class SessionEditor
    {

        public void Show(AppDbContext cinema)
        {
            while (true)
            {
                Console.WriteLine("------Session editing-----");
                Console.WriteLine("Watch Session List(wsl), Change status(chs), Back to Main menu(back)");
                Console.WriteLine("Enter: ");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "wsl":
                        {
                            SessionList(cinema);
                            break;
                        }
                    case "chs":
                        {
                            ChangeStatus(cinema);
                            break;
                        }
                    case "back":
                        {
                            return;
                        }
                    default:
                        {
                            Console.WriteLine("Incorrect option. Try again.");
                            break;
                        }
                }
            }
        }

        public void SessionList(AppDbContext cinema)
        {
            Console.WriteLine("-------Session list-------");

            var sessions = cinema.Sessions
                    .Include(s => s.Film)
                    .Include(s => s.Hall)
                    .Include(s => s.SessionStatus)
                    .ToList();

            foreach (var item in sessions)
            {
                Console.WriteLine(item);
            }

        }

        public void ChangeStatus(AppDbContext cinema)
        {
            SessionList(cinema);
            Console.WriteLine();
            bool BadEnter = true;
            while (BadEnter)
            {
                Console.Write("Enter session ID, which status you want to change: ");
                if (int.TryParse(Console.ReadLine(), out int num))
                {
                    var exists = cinema.Sessions.Any(s => s.ID == num);
                    if (exists)
                        {
                        bool IdIsNotANum = true;
                        while (IdIsNotANum)
                        {
                            Console.Write("Enter status(1 - Active, 2 - Cancelled): ");
                            if (int.TryParse(Console.ReadLine(), out int id))
                            {
                                switch (id)
                                {
                                    case 1:
                                        {
                                            cinema.Sessions.Where(x => x.ID == num).FirstOrDefault().SessionStatusID = 1;
                                            break;
                                        }
                                    case 2:
                                        {
                                            cinema.Sessions.Where(x => x.ID == num).FirstOrDefault().SessionStatusID = 2;
                                            break;
                                        }
                                    default:
                                        {
                                            Console.WriteLine("Wrong status ID. Try again.");
                                            continue;
                                        }
                                }
                                IdIsNotANum = false;
                            }
                            else
                            {
                                Console.WriteLine("It's not a number. Try again");
                                continue;
                            }
                        }
                        BadEnter = false;
                    }
                    else
                    {
                        Console.WriteLine("There is no session with this ID. Try another one.");
                    }
                    
                }
                else
                {
                    Console.WriteLine("It's not a number. Try again");
                    continue;
                }
            }
            cinema.SaveChanges();
            Console.WriteLine("All changes saved.");
            
        }

        /*public void AddSession(AppDbContext cinema)
        {
            Console.WriteLine("Enter info about session:");
            Console.Write("Film: ");
            var film = Console.ReadLine();
            cinema.Sessions.Add();
        }*/
    }
}
