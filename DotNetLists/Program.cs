using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;


namespace DotNetLists
    {

    class Program
        {

        private readonly static string TAG = typeof(Program).Name;
        private readonly static string TITLE = "C# & .NET: Programming";
        private static string userInput = "";

        private static ConcurrentDictionary<int, int> items;
        private static Thread thread1, thread2;

        private static Stack<String> myStack;

        //Main method
        static void Main(string[] args)
            {

            Console.Title = TITLE;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("'" + TAG + "' class called");

            mainProgram();
            startMultiThreads();

            MessageBox.Show("All done!");

            }

        private static void setStack() {

            Console.WriteLine("\nStack:\n");
            myStack = new Stack<String>();
            myStack.Push("One");
            myStack.Push("Two");
            myStack.Push("Three");

            foreach (var item in myStack) {
                Console.WriteLine((string)item);
                }

            Console.WriteLine((string)myStack.Pop()); //Show and remove an item
            Console.WriteLine((string)myStack.Peek()); //Show only
            }

        private static void setTuple()
            {
            Console.WriteLine("\nTuple:\n");
            var myTuple = Tuple.Create(1, "hello", true);
            Console.WriteLine(myTuple.Item2);
            }

        private static void startMultiThreads() {

            Console.WriteLine("\nStart Multi Threads:\n");

            items = new ConcurrentDictionary<int, int>();
            thread1 = new Thread(new ThreadStart(addItem));
            thread2 = new Thread(new ThreadStart(addItem));

            thread1.Start();
            thread2.Start();

            }

        private static void addItem() {

            Console.WriteLine("'addItem' method called");
            items.TryAdd(1, 2);
            Console.WriteLine("Total items: " + items.Count);
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
                setTuple();
                setStack();

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

            Hashtable table = new Hashtable();
            table.Add("title", "Some Title");
            string s = (string)table["title"];
            Console.Write(s);
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

        //Class Program
        }

    //DotNetLists
    }
