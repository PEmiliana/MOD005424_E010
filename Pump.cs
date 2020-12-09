using System;
using System.Timers;

namespace MOD005424_FuellingAroundLTD
{
    public class Pump
    {
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
        public void SetTimer()
        {
            // Create a timer with a 18 second interval.
            aTimer = new System.Timers.Timer(18000);
           InUse = true;
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
           
            aTimer.Enabled = true;
            
        }
        //
      
        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            InUse = false;
           
            aTimer.Stop();
            aTimer.Dispose();
            
        }
    }
}
