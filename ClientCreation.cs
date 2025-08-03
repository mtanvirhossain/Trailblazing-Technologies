using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Trailblazing_Technologies
{
    class ClientCreation
    {
        private string clientName;
        private int numberOfUsers;
        private String offerType;
        private double offerRate;
        private double offerFee;

        public List<Client> listOfAllClients = new List<Client>();

        public void CreateClient()
        {
            Console.Write("Please enter the client name: ");
            clientName = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(clientName) || (!Regex.IsMatch(clientName, @"^[A-Za-z\s\-\!\@\#\$\%\^\&\*\(\)_\+=\[\]\{\}\|:;""'<>,\.\?\/~`]+$")))
            {
                Console.Write("Client name cannot be empty. Please enter the client name: ");
                clientName = Console.ReadLine();
            }
            Console.Write("please enter the number of users : ");
            numberOfUsers = Convert.ToInt32(Console.ReadLine());
            while (numberOfUsers<0 || numberOfUsers>100)
            {
                Console.Write("Please enter the currect number of users (1-100): ");
                numberOfUsers = Convert.ToInt32(Console.ReadLine());
            }
           

            Console.Write("Special offer granted? (Y/N): ");
            offerType = Console.ReadLine();

            FeeCalculation newClient = new FeeCalculation();

            offerRate = newClient.CalculateOfferRate(numberOfUsers);
            offerFee = newClient.CalculateFee(numberOfUsers, offerRate, offerType);

            Console.WriteLine("\nThe subscription for " + clientName + " has been created.");
            Console.WriteLine("The Subscription fee is " + offerFee);

            Client myClient = new Client();

            myClient.ClientName = clientName;
            myClient.NumberOfUsers = numberOfUsers;
            myClient.OfferFee = offerFee;
            myClient.OfferType = offerType;

            listOfAllClients.Add(myClient);

        }


        public void DisplayAllClients()
        {
            Client clientWithMaxOfferFee = listOfAllClients.MaxBy(c => c.OfferFee);

            // Find client with min OfferFee
            Client clientWithMinOfferFee = listOfAllClients.MinBy(c => c.OfferFee);

            Console.WriteLine("\nClients Subscription Summary");
            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine("Name \t \t Users \t \t Offer \t \t Fee\t");
            Console.WriteLine("---------------------------------------------------------------------");

            foreach (var item in listOfAllClients)
            {
                Console.WriteLine(item.ClientName + "\t \t" + item.NumberOfUsers + "\t \t" + item.OfferType + "\t \t" + item.OfferFee + "\t");
            }

            Console.WriteLine("---------------------------------------------------------------------");
            double max = listOfAllClients.Max(x => x.OfferFee);
            double min = listOfAllClients.Min(x => x.OfferFee);
            Console.WriteLine($"The client paying the most is {clientWithMaxOfferFee.ClientName} and the value is {max}");
            Console.WriteLine($"The client paying the least is {clientWithMinOfferFee.ClientName} and the value is {min}");
            Console.WriteLine("---------------------------------------------------------------------");
        }
    }
}
