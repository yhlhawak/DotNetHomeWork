using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clock
{
    class Clock
    {
        static public string alarmtime = "15:28:00";

        public delegate void ClockHanlder(DateTime dateTime);

        public event ClockHanlder Tick;
        public event ClockHanlder Alarm;


        public void Change(DateTime date)
        {
            Tick(date);
            Alarm(date);
        }
    }
}
