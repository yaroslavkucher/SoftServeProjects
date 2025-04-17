using CinemaProject;
public class Program
{
    public static void Main()
    {
        var cinema = new AppDbContext();

        

        Console.WriteLine($"Hello, Administrator!");
        var menu = new Menu();
        menu.Show(cinema);
        Console.WriteLine("See you later:)");
    }
}


/*Console.WriteLine("-------TicketStatus-------");
foreach (var item in cinema.TicketStatuses)
{
    Console.WriteLine(item);
}*/

/*void SessionEditing()
{
    while (true)
    {
        Console.WriteLine("------Session editing-----");
        Console.WriteLine("Watch Session List(wsl), Add Session(adds), Remove Session(rms), Change status(chs), Back to Main menu(back)");
        Console.WriteLine("Enter: ");
        string input = Console.ReadLine();
        switch (input)
        {
            case "wsl":
                {
                    //SessionEditing();
                    break;
                }
            case "adds":
                {
                    //HallsEditing();
                    break;
                }
            case "rms":
                {
                    //TicketSelling();
                    break;
                }
            case "chs":
                {
                    //TicketSelling();
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

//void Menu()
{
    Console.WriteLine("Main menu:");
    while(true)
    {
        Console.WriteLine("What are you want to do?");
        Console.WriteLine("Sessions editing(se), Halls editing(he), tickets selling(ts), Exit(exit)");
        Console.WriteLine("Enter: ");
        string input = Console.ReadLine();
        switch(input)
        {
            case "se":
            {
                SessionEditing();
                break;
            }
            case "he":
            {
                //HallsEditing();
                break;
            }
            case "ts":
            {
                //TicketSelling();
                break;
            }
            case "exit":
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
    
}*/