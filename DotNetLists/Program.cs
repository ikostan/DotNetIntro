using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetLists
    {
    class Program
        {
        static void Main(string[] args)
            {

            listSample();

            Console.WriteLine("\nPlease press any key...");
            Console.ReadLine(); //Wait for input before closing the console

            }

        private static void listSample() {

            //Lists
            List<String> customers = new List<String>();
            customers.Add("Kim");
            customers.Add("Ted");
            customers.Add("John");

            foreach (var customer in customers)
                {

                    Console.WriteLine(customer);
                }

            //Show specific customer
            Console.WriteLine(customers[1]);

            }


        }
    }
