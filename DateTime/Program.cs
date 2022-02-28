using System;
using System.Text.RegularExpressions;

namespace DateTimeT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Clear();

            DateTime dateTime = new DateTime(1993, 3, 26);

            //Curren date
            Console.WriteLine(DateTime.Now);

            //current day, incorrect time format
            Console.WriteLine(DateTime.Today);

            //tomorrow date
            Console.WriteLine("Tomorrows Date: " + getTomorrow().ToString());

            //Day of week
            Console.WriteLine("Today is " + DateTime.Today.DayOfYear + " AKA " + DateTime.Today.DayOfWeek );

            Console.WriteLine("First day of year 1999: " + GetFirstDayOfYear(1999).DayOfWeek);

            int days = DateTime.DaysInMonth(2000, 2);//how many days did that month have?
            Console.WriteLine("Days in Feb 2000: " + days);

            Console.WriteLine("Days in Feb 2001: " + DateTime.DaysInMonth(2001, 2));
            Console.WriteLine("Days in Feb 2002: " + DateTime.DaysInMonth(2002, 2));
            Console.WriteLine("Days in Feb 2003: " + DateTime.DaysInMonth(2003, 2));
            Console.WriteLine("Days in Feb 2004: " + DateTime.DaysInMonth(2004, 2));

            DateTime current = DateTime.Now;
            Console.WriteLine("CurrentMinute: " + current.Minute);
            Console.WriteLine(current.Hour + ":" + current.Minute + ":" + current.Second);

            //write a date in this format yyyy-mm-dd
            Console.WriteLine("write a date in this format yyyy-mm-dd:");
            string input = Console.ReadLine();

            Regex DateFormat = new Regex(@"^\d{4}\-(0?[1-9]|1[012])\-(0?[1-9]|[12][0-9]|3[01])$");

            while(!DateFormat.IsMatch(input)) 
            {
                Console.Write("INVALID FORMAT, re-enter: ");
                input = Console.ReadLine();
            }
            if (DateTime.TryParse(input, out dateTime))
            {
                TimeSpan daysPassed = DateTime.Now.Subtract(dateTime);
                Console.WriteLine("DAYS SINCE {0}: ", daysPassed.Days);
            }
        }

        static DateTime GetFirstDayOfYear(int year)
        {
            return new DateTime(year, 1, 1);
        }

        static DateTime getTomorrow()
        {
            return DateTime.Today.AddDays(1);   
        }
    }
}
