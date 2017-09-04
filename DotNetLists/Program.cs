using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;


namespace DotNetLists
    {

    class Program
        {

        private readonly static string TAG = typeof(Program).Name;
        private readonly static string TITLE = "C# & .NET: Programming";
        private static string userInput = "0";

        //Main method
        static void Main(string[] args)
            {

            Console.Title = TITLE;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("'" + TAG + "' class called");

            mainProgram();

            MessageBox.Show("All done!");

            }

        private static void getUserInput() {

            do {

                Console.WriteLine("\nEnter '1' to RUN the application OR '2' to EXIT:\n");
                userInput = Console.ReadLine();

                if (!(userInput == "1" || userInput == "2")) {

                    Console.WriteLine("ERROR: invalid input!");
                    }
                }
            while (!(userInput == "1" || userInput == "2"));
            }


        private static void mainProgram() {

            getUserInput();

            if (userInput == "1")
                {

                listSample();
                dictionarySample();
                arrayListSample();


                hashTableSample();
                threadSafeSample();

                Console.WriteLine("\nPress ENTER key to continue...");
                Console.ReadLine(); // Wait for Enter key to be pressed.
                }
            else if (userInput == "2")
                {

                exitApp();
                }
            }


        private static void dictionarySample() {

            Console.WriteLine("\nDictionaries for key value pairs:");

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

            Console.WriteLine("\nLists for indexed values:");

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

            Console.WriteLine("\nArrayLists for dynamic-sized (deprecated):");

            //ArrayLists
            ArrayList list = new ArrayList();

            list.Add("Kim");
            list.Add("Ted");
            list.Add("John");

            foreach (var customer in list)
                {
                Console.WriteLine(customer);
                }

            //Access by key
            Console.WriteLine(list[1].ToString());
            }

        private static void hashTableSample() {

            Console.WriteLine("\nHashTable for key value pairs (deprecated):");

            }

        private static void threadSafeSample()
            {

            Console.WriteLine("\n:");
            
            }

        private static void exitApp() {

            if (System.Windows.Forms.Application.MessageLoop)
                {
                // WinForms app
                System.Windows.Forms.Application.Exit();
                }
            else
                {
                // Console app
                System.Environment.Exit(1);
                }

            }

        }

    //Class Program
    }
