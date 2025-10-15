using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oops_assignments
{

    //Create:
    //class LoadProfileDay
    //{
    //    public DateTime Date { get; }
    //    public int[] HourlyKwh { get; } // length 24
    //    public LoadProfileDay(DateTime date, int[] hourly)
    //    {
    //        // clone array; validate length == 24; values >= 0
    //    }
    //    public int Total => /* sum */;
    //    public int PeakHour => /* 0..23 of max */;
    //}
    internal class LoadProfileDay
    {
        public DateTime Date { get; }
        public int[] HourlyKwh { get; } 
        public LoadProfileDay(DateTime date, int[] hourly)
        {
            if (hourly.Length != 24)
            {
                throw new ArgumentException("Array length must be 24.");
            }
            foreach (var value in hourly)
            {
                if (value < 0)
                {
                    throw new ArgumentException("Array values must be non-negative.");
                }
            }
            Date = date;
            HourlyKwh = (int[])hourly.Clone(); 
        }
        public int Total => HourlyKwh.Sum();
        public int PeakHour => Array.IndexOf(HourlyKwh, HourlyKwh.Max());
    }
}
