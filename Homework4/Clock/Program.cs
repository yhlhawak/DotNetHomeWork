using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Clock
{
    class Program
    {
        
        static void timechange(object sender, ElapsedEventArgs args)
        {
            Clock clock = new Clock();
            Clocksubscribe clocksubscribe = new Clocksubscribe();
            clock.Tick += new Clock.ClockHanlder(clocksubscribe.ticksolution);
            clock.Alarm += new Clock.ClockHanlder(clocksubscribe.alarmsolution);
            clock.Change(DateTime.Now);
        }
        static void Main(string[] args)
        {   
            
            Timer timer = new Timer(1000);
            timer.AutoReset = true;
            timer.Elapsed += new ElapsedEventHandler(timechange);
            timer.Start();
            Console.ReadLine();
        }
    }
}
