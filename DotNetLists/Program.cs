using System;
using System.Collections;
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
            dictionarySample();
            arrayListSample();

            Console.WriteLine("\nPlease press any key...");
            Console.ReadLine(); //Wait for input before closing the console

            }


        private static void dictionarySample() {

            Console.WriteLine("Dictionaries for key value pairs:");

            Dictionary<String, String> configs = new Dictionary<String, String>();

            configs.Add("resolution", "1920x1080");
            configs.Add("title", "My website");
            configs.Add("name", "My name is John");

            Console.WriteLine("\nPrint key value pairs:");
            foreach (var config in configs)
                {

                Console.WriteLine(config);
                }

            Console.WriteLine("\nPrint keys:");
            foreach (var config in configs)
                {

                Console.WriteLine(config.Key);
                }

            Console.WriteLine("\nPrint values:");
            foreach (var config in configs)
                {

                Console.WriteLine(config.Value);
                }

            //Show item by key
            Console.WriteLine(configs["name"]);


            }



        private static void listSample() {

            Console.WriteLine("Lists for indexed values:");

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


        private static void arrayListSample()
            {

            Console.WriteLine("ArrayLists for dynamic-sized:");

            //Lists
            ArrayList list = new ArrayList();

            list.Add("Kim");
            list.Add("Ted");
            list.Add("John");

            foreach (var customer in list)
                {

                Console.WriteLine(customer);
                }          

            }


        }
    }
