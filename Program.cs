using System;

namespace Trailblazing_Technologies
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Trailblazing Technologies");
            Console.WriteLine("Logged in as: MD Tanvir Hossain");

            Boolean session = true;
            int code;

            ClientCreation myObject = new ClientCreation(); 

            while (session)
            {
                Console.WriteLine("\nPlease check the options below:");
                Console.WriteLine("1- Create a new client");
                Console.WriteLine("2- Show all the clients");
                Console.WriteLine("3- Quit");

                Console.Write("\nChoose your option: ");
                code = Convert.ToInt32(Console.ReadLine());

                switch (code)
                {
                    case 1:
                        myObject.CreateClient();
                        break;

                    case 2:
                        if (myObject.listOfAllClients.Count == 0)
                        {
                            Console.WriteLine("There is no client to display client information");
                            Console.WriteLine("Please go to option 1 to create a client first");
                        }
                        else
                        myObject.DisplayAllClients();
                        break;

                    case 3:
                        Console.WriteLine("You have terminated the program");
                        session = false;
                        break;

                    default:
                        Console.WriteLine("Please! Enter one of the numbers from the choice list below");
                        break;
                }
            }
        }
    }
}
