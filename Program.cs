using System;
using System.Collections.Generic;
using System.Threading;
using System.Timers;



namespace MOD005424_FuellingAroundLTD
{
     public class Program
    {
        protected static int origRow;
        protected static int origCol;
        protected static List<Pump> pumps = new List<Pump>();
        public static System.Timers.Timer aTimer;
        private static int cars;
        static Random random = new Random();
        public static List<float> litresDispencedList = new List<float>();


        // Timer code from https://docs.microsoft.com/en-us/dotnet/api/system.timers.timer?view=net-5.0
        // This timer increments the cars variable 
        public static void SetTimer()
        {
            // Create a timer with a 1.5 second interval.
            aTimer = new System.Timers.Timer(1500);
            aTimer.AutoReset = true;
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;

            aTimer.Enabled = true;

        }
        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {

            cars++;
            aTimer.Stop();
            aTimer.Interval = random.Next(1500, 2200); // set the next time interval to be between 1.5 to 2.2 seconds
            aTimer.Start();
        
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

                float totalLitersDispenced = 0f;
                foreach (float amount in litresDispencedList)
                {
                    totalLitersDispenced += amount;
                }

     
                //All the calculations will be done in separate methods in the next iteration to make it reusable, at the moment it was only needed in one instance.

                WriteAt("Number of vehicles fuelled = " + carsFuelled, 90, 1);
                WriteAt("Total Litres of petrol sold = " + totalLitersDispenced +"L", 90, 2);
                WriteAt("Till total = £" + (totalLitersDispenced * 1.12f), 90, 3);
                WriteAt("Commission owed to the attendant = £" + (totalLitersDispenced * 1.12f / 100), 90, 4);
                WriteAt("Number of cars that left without being fuelled = 0", 90, 7);

                // The reason why the unswer is always 0 is because the remaining cars are still in the queue.

                WriteAt("Please type the number of an available pump to direct the next customer to:", 0, 5);
                WriteAt("Number of cars arrived at the petrol station = " + cars, 90, 5);
                WriteAt("Number of cars in the queue still to be fuelled = " + (cars - carsFuelled), 90, 6);
                WriteAt("Today's petrol price per Litre is £1.12", 90, 0);
                WriteAt("", 0, 6);

                if (Console.KeyAvailable)
                {


                    key = Console.ReadKey(true);

                    //
                    switch (key.Key)
                    {
                        case ConsoleKey.D1:
                            carsFuelled += 1;
                           pumps[0].SetTimer(random.Next(16000, 20000));
                             break;

                        case ConsoleKey.D2:
                            carsFuelled += 1;
                            pumps[1].SetTimer(random.Next(16000, 20000));

                            break;

                        case ConsoleKey.D3:
                            carsFuelled += 1;
                            pumps[2].SetTimer(random.Next(16000, 20000));

                            break;

                        case ConsoleKey.D4:
                            carsFuelled += 1;
                            pumps[3].SetTimer(random.Next(16000, 20000));
                            break;

                        case ConsoleKey.D5:
                            carsFuelled += 1;
                            pumps[4].SetTimer(random.Next(16000, 20000));

                            break;

                        case ConsoleKey.D6:
                            carsFuelled += 1;
                            pumps[5].SetTimer(random.Next(16000, 20000));

                            break;

                        case ConsoleKey.D7:
                            carsFuelled += 1;
                            pumps[6].SetTimer(random.Next(16000, 20000));

                            break;

                        case ConsoleKey.D8:
                            carsFuelled += 1;
                            pumps[7].SetTimer(random.Next(16000, 20000));

                            break;

                        case ConsoleKey.D9:
                            carsFuelled += 1;
                            pumps[8].SetTimer(random.Next(16000, 20000));

                            break;
                    }
                    
                }
                Thread.Sleep(100);

            }
           
        }
      
    }
   
}
