using System;
using System.Timers;

namespace MOD005424_FuellingAroundLTD
{
    public class Pump
    {
        private float litresDispenced;
        public string Id { get; set; }
        public bool InUse { get; set; }
        public System.Timers.Timer aTimer;
        public Pump(string id)
        {
            this.Id = id;
            InUse = false;
    
        }
        // Timer code from https://docs.microsoft.com/en-us/dotnet/api/system.timers.timer?view=net-5.0
        // This timer switches the display message in the boxes from Busy to Free
        public void SetTimer(int duration)
        {
            // Create a timer with a 18 second interval.
            aTimer = new System.Timers.Timer(duration);
            litresDispenced = (duration / 1000) * 1.5f;
           InUse = true;
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
           
            aTimer.Enabled = true;
            
        }
        //
      
        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            InUse = false;
            Program.litresDispencedList.Add(litresDispenced);
           
            aTimer.Stop();
            aTimer.Dispose();
            
        }
    }
}
