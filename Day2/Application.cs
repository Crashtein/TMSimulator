using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day2
{
    class Application
    {
        public Application()
        {
            ticketNumber = 0;
        }
        Ticket ticket;
        TicketType typ;
        int ticketNumber;
        public void readK()
        {
            string input = null;
            while (input != "k" && input != "K" && input != "a" && input != "A")
            {
                Console.Clear();
                Console.WriteLine("Dzień dobry!");
                Console.WriteLine("Określ rodzaj biletu");
                Console.WriteLine("K - kolejowe");
                Console.WriteLine("A - autobusowe");
                input = Console.ReadLine();
            }
            if (input == "k" || input == "K")
            {
                ticket = new TicketK();
            }
            else
            {
                //a or A
                ticket = new TicketA();
            }
        }
        public void doCalc()
        {
            string input = null;
            while (input != "Z" && input != "z" && input != "S" && input != "s" && input != "x" && input != "X")
            {
                Console.WriteLine("Co chcesz zrobić?");
                Console.WriteLine("Z - Zakup biletu");
                Console.WriteLine("S - Sprawdzenie biletu");
                Console.WriteLine("X - koniec i powrót do początkowego menu");
                input = Console.ReadLine();
            }
            if (input == "z" || input == "Z")
            {
                this.buyTicket();
            }
            else if (input == "s" || input == "S")
            {
                this.checkTicket();
            }
            else
            {
                //x or X
                //end f
            }
        }
        private void buyTicket()
        {
            string inputType = null;
            while (inputType != "n" && inputType != "N" && inputType != "u" && inputType != "U")
            {
                Console.WriteLine("Podaj typ biletu: ");
                Console.WriteLine("N - normalny");
                Console.WriteLine("U - ulgowy");
                inputType = Console.ReadLine();
            }
            if (inputType == "n" || inputType == "N")
            {
                typ = TicketType.N;
            }
            else
            {
                typ = TicketType.U;
            }
            ticket.CalculatePrice(typ);
            Console.WriteLine("Drukowanie biletu...");
            ticketNumber++;
            ticket.PrintTicket(ticketNumber);
        }
        private void checkTicket()
        {
            Console.WriteLine("Podaj numer biletu(np. K123): ");
            var ticketName = Console.ReadLine();

            if (ticketName[0] == 'A')
            {
                this.checkA(ticketName);
            }
            else if (ticketName[0] == 'K')
            {
                this.checkK(ticketName);
            }
            else
            {
                Console.WriteLine("Brak w bazie takiego biletu!");
            }
        }
        private void checkA(string ticketName)
        {
            DateTime Date;
            if (File.Exists(ticketName = System.AppDomain.CurrentDomain.BaseDirectory + "\\autobus\\" + ticketName + ".txt"))
            {
                System.IO.StreamReader file = new System.IO.StreamReader(ticketName);
                var sDate = file.ReadLine();
                Console.WriteLine("Bilet zakupiono: " + sDate);
                if (DateTime.TryParse(sDate, out Date))
                {
                    Date = Date.AddMinutes(30);
                    Console.WriteLine("Bilet ważny do: " + Date);
                    if (Date > DateTime.Now)
                    {
                        Console.WriteLine("Bilet wciąż ważny!");
                    }
                    else
                    {
                        Console.WriteLine("Bilet nieważny!");
                    }
                }
            }
            else
            {
                Console.WriteLine("Brak w bazie takiego biletu!");
            }
        }
        private void checkK(string ticketName)
        {
            DateTime Date;
            if (File.Exists(ticketName = System.AppDomain.CurrentDomain.BaseDirectory + "\\kolej\\" + ticketName + ".txt"))
            {
                System.IO.StreamReader file = new System.IO.StreamReader(ticketName);
                var sDate = file.ReadLine();
                var sLength = file.ReadLine();
                Console.WriteLine("Bilet zakupiono: " + sDate);
                Console.WriteLine("Na odległość: " + sLength + "km");
                var Length = Int32.Parse(sLength);
                if (DateTime.TryParse(sDate, out Date))
                {
                    if (0 < Length && Length <= 100)
                    {
                        Date = Date.AddHours(3);
                    }
                    else if (100 < Length && Length <= 200)
                    {
                        Date = Date.AddHours(12);
                    }
                    else if (200 < Length)
                    {
                        Date = Date.AddHours(24);
                    }

                    Console.WriteLine("Bilet ważny do: " + Date);
                    if (Date > DateTime.Now)
                    {
                        Console.WriteLine("Bilet wciąż ważny!");
                    }
                    else
                    {
                        Console.WriteLine("Bilet nieważny!");
                    }
                }
            }
            else
            {
                Console.WriteLine("Brak w bazie takiego biletu!");
            }
        }
    }
}
