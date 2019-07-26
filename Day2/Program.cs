using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;



namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new Application();
            do {
                app.readK();
                app.doCalc();
                Console.WriteLine("Wpisz 0 aby zakończyć/enter aby kupić kolejny bilet");
            } while (Console.ReadLine() != "0");
        }
    }
}
