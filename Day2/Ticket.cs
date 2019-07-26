using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

enum TicketType { N, U };

namespace Day2
{
    abstract class Ticket
    {
        protected double price;
        public abstract void CalculatePrice(TicketType typ);
        public abstract void PrintTicket(int ticketNumber);
    }
    class TicketA : Ticket
    {
        public override void CalculatePrice(TicketType typ)
        {
            price = 2.90;   //here you can change basic price
            if(typ == TicketType.U)
            {
                price = price / 2;
            }
            Console.WriteLine("Cena biletu autobusowego '" + typ + "' Wynosi: " + String.Format("{0:N2}", price) + "zl");
        }
        public override void PrintTicket(int ticketNumber)
        {
            string fileName = null;
            fileName += 'A';
            fileName += ticketNumber.ToString();
            Console.WriteLine("Numer twojego biletu to: " + fileName);
            fileName += ".txt";
            string currentPath = System.AppDomain.CurrentDomain.BaseDirectory;
            System.IO.Directory.CreateDirectory(currentPath + "\\autobus\\");
            System.IO.File.WriteAllText(currentPath + "\\autobus\\" + fileName, DateTime.Now.ToString());
        }
    }
    class TicketK : Ticket
    {
        private double routeLength;
        public override void CalculatePrice(TicketType typ)
        {
            //here you can change prices for km
            double to100 = 1.04;
            double over100 = 0.73;
            routeLength = 0;
            while (routeLength <=0)
            {
                Console.WriteLine("Podaj długość trasy w km(np. 258,54): ");
                var readKm = Console.ReadLine();
                Double.TryParse(readKm, out routeLength);
            }
            if (routeLength <= 100 && routeLength > 0)
            {
                price = to100 * routeLength;
            }
            else if (routeLength > 100)
            {
                price = to100 * 100 + over100 * (routeLength - 100);
            }
            if(typ == TicketType.U)
            {
                price = price / 2;
            }
            Console.WriteLine("Cena biletu kolejowego '" + typ + "' na długości: " + routeLength.ToString() + "km Wynosi: " + String.Format("{0:N2}",price) + "zl");
        }
        public override void PrintTicket(int ticketNumber)
        {
            string fileName = null;
            fileName += 'K';
            fileName += ticketNumber.ToString();
            Console.WriteLine("Numer twojego biletu to: " + fileName);
            fileName += ".txt";
            string currentPath = System.AppDomain.CurrentDomain.BaseDirectory;
            System.IO.Directory.CreateDirectory(currentPath + "\\kolej\\");
            System.IO.File.WriteAllText(currentPath + "\\kolej\\" + fileName, DateTime.Now.ToString() + "\r\n" + routeLength.ToString());
        }
    }
}