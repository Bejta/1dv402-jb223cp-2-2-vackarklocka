using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L02A
{
    class AlarmClock
    {
        //private fields
        private int _alarmHour;
        private int _alarmMinute;
        private int _hour;
        private int _minute;

        //Properties
        public int AlarmHour
        {
            get
            {
                return _alarmHour;
            }
            set
            {
                if (value < 0 || 23 < value)
                    throw new ArgumentException("Alarmtimmen är inte i intervallet 0-23");

                _alarmHour = value;
            }
        }
        public int AlarmMinute
        {
            get
            {
                return _alarmMinute;
            }
            set
            {
                if (value < 0 || 59 < value)
                    throw new ArgumentException("Alarmminuten är inte i intervallet 0-59");

                _alarmMinute = value;
            }
        }
        public int Hour
        {
            get
            {
                return _hour;
            }
            set
            {
                if (value < 0 || 23 < value)
                    throw new ArgumentException("Timmen är inte i intervallet 0-23");

                _hour = value;
            }
        }
        public int Minute
        {
            get
            {
                return _minute;
            }
            set
            {
                if (value < 0 || 59 < value)
                    throw new ArgumentException("Minuten är inte i intervallet 0-59");

                _minute = value;
            }
        }

        /* Constructors chaining. First constructor without parameters
         * calls the second constructor with two parameters, and the second
         * constructor with two parameters calls the third constructor with four parameters.
         * In the body of fourth constructor sets the values for fields.*/
        public AlarmClock()
            : this(0, 0)
        {
        }
        public AlarmClock(int hour, int minute)
            : this(hour, minute, 0, 0)
        {
        }
        public AlarmClock(int hour, int minute, int alarmHour, int alarmMinute)
        {
            Hour = hour;
            Minute = minute;
            AlarmHour = alarmHour;
            AlarmMinute = alarmMinute;
        }
        //Method TicToc
        public bool TickTock()
        {
            //Checks if Minute is 59, and then reset it to 0
            if (Minute == 59)
            {
                Minute = 0;

                //Checks if Hour is 23, and then reset it to 0
                switch (Hour)
                {
                    case 23: Hour = 0;
                        break;
                    default: Hour++;
                        break;
                }
            }
            else
            {
                Minute++;
            }

            if (Minute == AlarmMinute && Hour == AlarmHour)
                return true;

            return false;
        }

        //Method ToString

        public override string ToString()
        {
            string row = Hour.ToString() + ":" + Minute.ToString("D2") + " (" + AlarmHour.ToString() + ":" + AlarmMinute.ToString("D2") + ")";
            return row;
        }
    }
}
