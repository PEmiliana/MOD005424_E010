using System;
using System.Collections.Generic;
using System.Threading;
using System.Timers;



namespace MOD005424_FuellingAroundLTD
{
    class Program
    {
        protected static int origRow;
        protected static int origCol;
        protected static List<Pump> pumps = new List<Pump>();
        protected static int pumpNumber = 0;
        public static System.Timers.Timer aTimer;
        private static int cars;


        // Timer code from https://docs.microsoft.com/en-us/dotnet/api/system.timers.timer?view=net-5.0
        // This timer increments the cars variable 
        public static void SetTimer()
        {
            // Create a timer with a 18 second interval.
            aTimer = new System.Timers.Timer(1500);
            aTimer.AutoReset = true;
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;

            aTimer.Enabled = true;

        }
        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {

            cars++;
            Console.WriteLine(cars);
        }
        

        protected static void WriteAt(string s, int x, int y)
        {
            //setting up for the display boxes
            try
            {
                Console.SetCursorPosition(origCol + x, origRow + y);
                Console.Write(s);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }

        public static void Main()
        {
            //float cars = 0;
            float carsFuelled = 0f;
            SetTimer();
        
       

                ConsoleKeyInfo key = new ConsoleKeyInfo();

            for (int i = 0; i < 9; i++)
            {

                int id = i + 1;
                Pump pump = new Pump(id.ToString());
                pumps.Add(pump);
            }
            
            // while true with a thread.sleep to refresh the screen every 100 miliseconds
            
            while (true)
            {

        
                // Clear the screen, then save the top and left coordinates.
                Console.Clear();
                
                origRow = Console.CursorTop;
                origCol = Console.CursorLeft;
                

                for (int i = 0; i < 9; i++)
                {

                    // Draw the left side of a 5x5 rectangle, from top to bottom.
                    WriteAt("+", 0 + (i * 10), 0);
                    WriteAt("|", 0 + (i * 10), 1);
                    WriteAt("  " + pumps[i].Id, 1 + (i * 10), 1);
                    string inUseOutput = "Free";
                    if (pumps[i].InUse)
                    {
                        inUseOutput = "Busy";

                    }
                   
                    WriteAt("" + inUseOutput, 1 + (i * 10), 2);
                    WriteAt("|", 0 + (i * 10), 2);
                    WriteAt("+", 0 + (i * 10), 3);

                    // Draw the bottom side, from left to right.
                    WriteAt("-", 1 + (i * 10), 3); // shortcut: WriteAt("---", 1, 3)
                    WriteAt("-", 2 + (i * 10), 3); // ...
                    WriteAt("-", 3 + (i * 10), 3); // ...
                    WriteAt("-", 4 + (i * 10), 3);
                    WriteAt("-", 5 + (i * 10), 3);
                    WriteAt("+", 5 + (i * 10), 3);

                    // Draw the right side, from bottom to top.
                    WriteAt("|", 5 + (i * 10), 2);
                    WriteAt("|", 5 + (i * 10), 1);
                    WriteAt("+", 5 + (i * 10), 0);

                    // Draw the top side, from right to left.
                    WriteAt("+", 5 + (i * 10), 0); // ...
                    WriteAt("-", 4 + (i * 10), 0); // ...
                    WriteAt("-", 3 + (i * 10), 0); // shortcut: WriteAt("---", 1, 0)
                    WriteAt("-", 2 + (i * 10), 0); // ...
                    WriteAt("-", 1 + (i * 10), 0); // ...

                    /* code above creating an individual box and the WriteAt lines below are from:
                     * https://docs.microsoft.com/en-us/dotnet/api/system.console.setcursorposition?view=net-5.0
                     */
                }


     
                //All the calculations will be done in separate methods in the next iteration to make it reusable, at the moment it was only needed in one instance.

                WriteAt("Number of vehicles fuelled = " + carsFuelled, 90, 0);
                WriteAt("Total Litres of petrol sold = " + (carsFuelled * 27)+"L", 90, 1);
                WriteAt("Till total = £" + (carsFuelled * 27f * 1.12f), 90, 2);
                WriteAt("Commission owed to the attendant = £" + (carsFuelled * 27f * 1.12f / 100), 90, 3);
                WriteAt("Number of cars that left without being fuelled = 0", 90, 6);

                // The unswer is always 0 (on line 138) because the remaining cars are still in the queue.

                WriteAt("Please type the number of an available pump to direct the next customer to:", 0, 5);
                WriteAt("Number of cars arrived at the petrol station = " + cars, 90, 4);
                WriteAt("Number of cars in the queue still to be fuelled = " + (cars - carsFuelled), 90, 5);
                WriteAt("Today's petrol price pe Litre is £1.12", 90, 0);
                WriteAt("", 0, 6);                    
                
                if (Console.KeyAvailable)
                {


                    key = Console.ReadKey(true);

                    //
                    switch (key.Key)
                    {
                        case ConsoleKey.D1:
                            carsFuelled += 1;
                           pumps[0].SetTimer();
                             break;

                        case ConsoleKey.D2:
                            carsFuelled += 1;
                            pumps[1].SetTimer();

                            break;

                        case ConsoleKey.D3:
                            carsFuelled += 1;
                            pumps[2].SetTimer();

                            break;

                        case ConsoleKey.D4:
                            carsFuelled += 1;
                            pumps[3].SetTimer();
                            break;

                        case ConsoleKey.D5:
                            carsFuelled += 1;
                            pumps[4].SetTimer();

                            break;

                        case ConsoleKey.D6:
                            carsFuelled += 1;
                            pumps[5].SetTimer();

                            break;

                        case ConsoleKey.D7:
                            carsFuelled += 1;
                            pumps[6].SetTimer();

                            break;

                        case ConsoleKey.D8:
                            carsFuelled += 1;
                            pumps[7].SetTimer();

                            break;

                        case ConsoleKey.D9:
                            carsFuelled += 1;
                            pumps[8].SetTimer();

                            break;
                    }
                    /* Switch code from https://stackoverflow.com/questions/5891538/listen-for-key-press-in-net-console-app
                     */
                }
                Thread.Sleep(100);

            }
           
        }
      
    }
   
}
