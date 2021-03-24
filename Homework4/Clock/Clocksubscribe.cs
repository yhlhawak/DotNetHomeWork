using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clock
{
    class Clocksubscribe
    {
        public void ticksolution(DateTime dateTime)
        {
            Console.WriteLine(dateTime.ToLongTimeString());
        }

        public void alarmsolution(DateTime dateTime)
        {
            if (dateTime.ToLongTimeString().Equals(Clock.alarmtime))
                Console.WriteLine("闹钟提醒！！！！");
        }
    }
}
