using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L02A
{
    class Program
    {
        /* Field HorizontalLine that has to be static (the same as Main Method).
         * Alternative is more complex so I could create an instance of Program class.
         */
        public static string HorizontalLine;
        static void Main(string[] args)
        {

            HorizontalLine = " \n═════════════════════════════════════════════════════════════════════════════ ";

            Console.Title = "Digital-Väckarklocka-Nivå A";
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ╔══════════════════════════════════════╗ ");
            Console.WriteLine(" ║        Väckarklokan URLED <TM>       ║ ");
            Console.WriteLine(" ║        modellnr.: 1DV402S2L2A        ║ ");
            Console.WriteLine(" ╚══════════════════════════════════════╝ ");
            Console.ResetColor();

            //Test1-Default Constructor
            ViewTestHeader(" Test 1.\n Test av standardkonstruktorn.\n");
            AlarmClock acDefaultConstructor = new AlarmClock();
            Console.WriteLine(acDefaultConstructor.ToString().PadLeft(15));

            //Test2-Constructor with two parameters
            ViewTestHeader(" Test 2.\n Test av konstruktorn med två parametrar, (9,42).\n");
            AlarmClock acTwoParametersConstructor = new AlarmClock(9, 42);
            Console.WriteLine(acTwoParametersConstructor.ToString().PadLeft(15));

            //Test3-Constructor with four parameters
            ViewTestHeader(" Test 3.\n Test av konstruktorn med fyra parametrar, (13,24,7,35).\n");
            AlarmClock acFourParametersConstructor = new AlarmClock(13, 24, 7, 35);
            Console.WriteLine(acFourParametersConstructor.ToString().PadLeft(15));

            //Test4-TickTock() method with existing constructor
            ViewTestHeader(" Test 4.\n Ställer befintligt AlarmClock-objekt till 23:58 och låter den gå 13 minuter.\n");
            acFourParametersConstructor.Hour = 23;
            acFourParametersConstructor.Minute = 58;
            Run(acFourParametersConstructor, 13);

            //Test5-TickTock() method with existing constructor and alarm time
            ViewTestHeader(" Test 5.\n Ställer befintligt AlarmClock-objekt till tiden 6:12 och alarmtiden till 6:15 och låter den gå 6 minuter.\n");
            acFourParametersConstructor.Hour = 6;
            acFourParametersConstructor.Minute = 12;
            acFourParametersConstructor.AlarmHour = 6;
            acFourParametersConstructor.AlarmMinute = 15;
            Run(acFourParametersConstructor, 6);

            //Test6 Throwing exceptions - Properties
            ViewTestHeader(" Test 6.\n Testar egenskaperna så att undantag kastas då tid och alarmtid tilldelas felaktiga värden.\n");
            try
            {
                acFourParametersConstructor.Hour = -6;
            }
            catch (ArgumentException e)
            {
                ViewErrorMessage(e.Message);
            }
            try
            {
                acFourParametersConstructor.Minute = 62;
            }
            catch (ArgumentException e)
            {
                ViewErrorMessage(e.Message);
            }
            try
            {
                acFourParametersConstructor.AlarmHour = 30;
            }
            catch (ArgumentException e)
            {
                ViewErrorMessage(e.Message);
            }
            try
            {
                acFourParametersConstructor.AlarmMinute = -1;
            }
            catch (ArgumentException e)
            {
                ViewErrorMessage(e.Message);
            }
            //Test7 Throwing exceptions - Constructors
            ViewTestHeader(" Test 7.\n Testar konstruktorerna så att undantag kastas då tid och alarmtid tilldelas felaktiga värden.\n");
            try
            {
                AlarmClock constructorFail = new AlarmClock(-6, 62);
            }
            catch (ArgumentException e)
            {
                ViewErrorMessage(e.Message);
            }
            try
            {
                AlarmClock constructorFailAlarm = new AlarmClock(6, 51, 25, -2);
            }
            catch (ArgumentException e)
            {
                ViewErrorMessage(e.Message);
            }

        }
        private static void Run(AlarmClock ac, int minutes)
        {
            for (int i = 0; i < minutes; i++)
            {
                if (ac.TickTock())
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(" ♫  {0}  BEEP!  BEEP!  BEEP!  BEEP!", ac.ToString().PadLeft(11));
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine(ac.ToString().PadLeft(15));
                }
            }
        }
        private static void ViewErrorMessage(string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        private static void ViewTestHeader(string header)
        {
            Console.WriteLine(" " + HorizontalLine);
            Console.WriteLine(header);
        }
    }
}
