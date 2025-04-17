using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject
{
    public class HallEditor
    {

        public void Show(AppDbContext cinema)
        {
            while (true)
            {
                Console.WriteLine("------Hall editing-----");
                Console.WriteLine("Watch Hall List(whl), Change status(chs), Back to Main menu(back)");
                Console.WriteLine("Enter: ");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "whl":
                        {
                            HallList(cinema);
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

        public void HallList(AppDbContext cinema)
        {
            Console.WriteLine("-------Hall list-------");

            var halls = cinema.Halls
                    .Include(s => s.HallType)
                    .ToList();

            foreach (var item in halls)
            {
                Console.WriteLine(item);
            }

        }

        public void ChangeStatus(AppDbContext cinema)
        {
            HallList(cinema);
            Console.WriteLine();
            bool BadEnter = true;
            while (BadEnter)
            {
                Console.Write("Enter Hall ID, which status you want to change: ");
                if (int.TryParse(Console.ReadLine(), out int num))
                {
                    var exists = cinema.Halls.Any(s => s.CinemaHallID == num);
                    if (exists)
                    {
                        bool IdIsNotANum = true;
                        while (IdIsNotANum)
                        {
                            Console.Write("Enter status(1 - Common, 2 - VIP): ");
                            if (int.TryParse(Console.ReadLine(), out int id))
                            {
                                switch (id)
                                {
                                    case 1:
                                        {
                                            cinema.Halls.Where(x => x.CinemaHallID == num).FirstOrDefault().HallTypeID = 1;
                                            break;
                                        }
                                    case 2:
                                        {
                                            cinema.Halls.Where(x => x.CinemaHallID == num).FirstOrDefault().HallTypeID = 2;
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
                        Console.WriteLine("There is no hall with this ID. Try another one.");
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
