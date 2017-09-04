using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
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
        private static Queue<String> myQueue;
        private static HashSet<string> myHashSet;

        //Main method
        static void Main(string[] args)
            {

            Console.Beep();
            Console.Title = TITLE;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("'" + TAG + "' class called");

            mainProgram();
            startMultiThreads();
            ShowEnvironmentDetails();

            Console.Beep();
            MessageBox.Show("All done!");
            // Adds a total of 4 blank lines (then beep again!).
            Console.WriteLine("All finished.\n\n\n\a ");
            }

        static void BasicStringFunctionality()
            {
            Console.WriteLine("\n=> Basic String functionality:\n");
            string firstName = "Freddy";
            Console.WriteLine("Value of firstName: {0}", firstName);
            Console.WriteLine("firstName has {0} characters.", firstName.Length);
            Console.WriteLine("firstName in uppercase: {0}", firstName.ToUpper());
            Console.WriteLine("firstName in lowercase: {0}", firstName.ToLower());
            Console.WriteLine("firstName contains the letter y?: {0}",
                firstName.Contains("y"));
            Console.WriteLine("firstName after replace: {0}", firstName.Replace("dy", ""));

            // The following string is printed verbatim,
            // thus all escape characters are displayed.
            Console.WriteLine(@"C:\MyApp\bin\Debug");

            // White space is preserved with verbatim strings.
            string myLongString = @"This is a very
                very
                    very
                        long string";
            Console.WriteLine(myLongString);
            }

        static void UseDatesAndTimes()
            {
            Console.WriteLine("\n=> Dates and Times:\n");
            // This constructor takes (year, month, day).
            DateTime dt = new DateTime(2015, 10, 17);
            // What day of the month is this?
            Console.WriteLine("The day of {0} is {1}", dt.Date, dt.DayOfWeek);
            // Month is now December.
            dt = dt.AddMonths(2);
            Console.WriteLine("Daylight savings: {0}", dt.IsDaylightSavingTime());
            // This constructor takes (hours, minutes, seconds).
            TimeSpan ts = new TimeSpan(4, 30, 0);
            Console.WriteLine(ts);
            // Subtract 15 minutes from the current TimeSpan and
            // print the result.
            Console.WriteLine(ts.Subtract(new TimeSpan(0, 15, 0)));


            // The example displays the following output:
            //       en-US: 6/19/2015 10:03:06 AM
            //       en-GB: 19/06/2015 10:03:06
            //       fr-FR: 19/06/2015 10:03:06
            //       de-DE: 19.06.2015 10:03:06
            //       ru-RU: 19.06.2015 10:03:06

            DateTime localDate = DateTime.Now;
            String[] cultureNames = { "en-US", "en-GB", "fr-FR", "de-DE", "ru-RU" };

            foreach (var cultureName in cultureNames)
                {
                var culture = new CultureInfo(cultureName);
                Console.WriteLine("{0}: {1}", cultureName,
                                  localDate.ToString(culture));

                }
            }

        static void ParseFromStrings()
            {
            Console.WriteLine("\n=> Data type parsing:\n");
            bool b = bool.Parse("True");
            Console.WriteLine("Value of b: {0}", b);
            double d = double.Parse("99.884");
            Console.WriteLine("Value of d: {0}", d);
            int i = int.Parse("8");
            Console.WriteLine("Value of i: {0}", i);
            char c = Char.Parse("w");
            Console.WriteLine("Value of c: {0}", c);
            }

        static void CharFunctionality()
            {
            Console.WriteLine("\n=> char type Functionality:\n");

            char myChar = 'a';
            Console.WriteLine("char.IsDigit('a'): {0}", char.IsDigit(myChar));
            Console.WriteLine("char.IsLetter('a'): {0}", char.IsLetter(myChar));

            Console.WriteLine("char.IsWhiteSpace('Hello There', 5): {0}",
            char.IsWhiteSpace("Hello There", 5));

            Console.WriteLine("char.IsWhiteSpace('Hello There', 6): {0}",
            char.IsWhiteSpace("Hello There", 6));

            Console.WriteLine("char.IsPunctuation('?'): {0}",
            char.IsPunctuation('?'));
            }

        static void DataTypeFunctionality()
            {
            Console.WriteLine("\n=> Data type Functionality:\n");
            Console.WriteLine("Max of int: {0}", int.MaxValue);
            Console.WriteLine("Min of int: {0}", int.MinValue);
            Console.WriteLine("Max of double: {0}", double.MaxValue);
            Console.WriteLine("Min of double: {0}", double.MinValue);
            Console.WriteLine("double.Epsilon: {0}", double.Epsilon);
            Console.WriteLine("double.PositiveInfinity: {0}",
                double.PositiveInfinity);
            Console.WriteLine("double.NegativeInfinity: {0}",
                double.NegativeInfinity);
            }

        static void ObjectFunctionality()
            {
            Console.WriteLine("\n=> System.Object Functionality:\n");
            // A C# int is really a shorthand for System.Int32,
            // which inherits the following members from System.Object.
            Console.WriteLine("12.GetHashCode() = {0}", 12.GetHashCode());
            Console.WriteLine("12.Equals(23) = {0}", 12.Equals(23));
            Console.WriteLine("12.ToString() = {0}", 12.ToString());
            Console.WriteLine("12.GetType() = {0}", 12.GetType());
            }

        static void FormatNumericalData()
            {
            Console.WriteLine("\nThe value 99999 in various formats:\n");
            Console.WriteLine("c format: {0:c}", 99999);
            Console.WriteLine("d9 format: {0:d9}", 99999);
            Console.WriteLine("f3 format: {0:f3}", 99999);
            Console.WriteLine("n format: {0:n}", 99999);
            // Notice that upper- or lowercasing for hex
            // determines if letters are upper- or lowercase.
            Console.WriteLine("E format: {0:E}", 99999);
            Console.WriteLine("e format: {0:e}", 99999);
            Console.WriteLine("X format: {0:X}", 99999);
            Console.WriteLine("x format: {0:x}", 99999);
            }

        static void ShowEnvironmentDetails()
            {
            // Print out the drives on this machine,
            // and other interesting details.
            foreach (string drive in Environment.GetLogicalDrives()) {
                Console.WriteLine("Drive: {0}", drive);
                }
                
            Console.WriteLine("OS: {0}", Environment.OSVersion);
            Console.WriteLine("Number of processors: {0}", Environment.ProcessorCount);
            Console.WriteLine(".NET Version: {0}", Environment.Version);
            Console.WriteLine("System Directory: {0}", Environment.SystemDirectory);
            Console.WriteLine("User Domain Name: {0}", Environment.UserDomainName);
            Console.WriteLine("Machine Name: {0}", Environment.MachineName);
            Console.WriteLine("Current Directory: {0}", Environment.CurrentDirectory);

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

        private static void setQueue()
            {

            Console.WriteLine("\nQueue:\n");
            myQueue = new Queue<String>();
            myQueue.Enqueue("One");
            myQueue.Enqueue("Two");
            myQueue.Enqueue("Three");

            foreach (var item in myQueue)
                {
                Console.WriteLine((string)item);
                }

            Console.WriteLine((string)myQueue.Dequeue()); //Show and remove an item
            Console.WriteLine((string)myQueue.Peek()); //Show only
            }

        private static void setHashSet()
            {

            Console.WriteLine("\nHashSet:\n");

            string[] items = new string[] { "One", "Four", "Five"};
            myHashSet = new HashSet<String>();
            myHashSet.Add("One");
            myHashSet.Add("Two");
            myHashSet.Add("Three");
            myHashSet.Add("Three");
            myHashSet.Add("Three");

            foreach (var item in myHashSet)
                {
                Console.WriteLine((string)item);
                }

            Console.WriteLine("Total items in the HashSet: " + myHashSet.Count);
            Console.WriteLine("Overlapping items: " + myHashSet.Overlaps(items));
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
                setQueue();
                setHashSet();
                FormatNumericalData();
                ObjectFunctionality();
                DataTypeFunctionality();
                ParseFromStrings();
                UseDatesAndTimes();
                BasicStringFunctionality();

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
