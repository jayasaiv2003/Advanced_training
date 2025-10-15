using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oops_assignments
{


//      Create:

//#
//abstract class AlarmRule
//    {
//        public string Name { get; }
//        protected AlarmRule(string name) => Name = name;
//        public abstract bool IsTriggered(LoadProfileDay day);
//        public virtual string Message(LoadProfileDay day)
//            => $"{Name} triggered on {day.Date:yyyy-MM-dd}";
//    }

//    class PeakOveruseRule : AlarmRule
//    {   // trigger if day.Total > threshold
//        private readonly int _threshold;
//        public PeakOveruseRule(int threshold) : base("PeakOveruse") => _threshold = threshold;
//        public override bool IsTriggered(LoadProfileDay day) => day.Total > _threshold;
//    }

//    class SustainedOutageRule : AlarmRule
//    {   // trigger if consecutive zero hours >= N
//        private readonly int _minConsecutive;
//        public SustainedOutageRule(int min) : base("SustainedOutage") => _minConsecutive = min;
//        public override bool IsTriggered(LoadProfileDay day) { /* scan */ }
//}
//Tasks

//Build a LoadProfileDay with some zeros & highs.

//Evaluate rules and print triggered messages.

//Expected Output

//PeakOveruse triggered on 2025-10-01
    internal abstract class AlarmRule
    {
        public string Name { get; }
        protected AlarmRule(string name) => Name = name;
        public abstract bool IsTriggered(LoadProfileDay day);
        public virtual string Message(LoadProfileDay day)
        {
            return $"{Name} triggered on {day.Date:yyyy-MM-dd}";
        }

    }
    internal class PeakOveruseRule : AlarmRule
    {
        private readonly int _threshold;
        public PeakOveruseRule(int threshold) : base("PeakOveruse")
        {
            _threshold = threshold;
        }
        public override bool IsTriggered(LoadProfileDay day)
        {
            return day.Total > _threshold;
        }
    }
    internal class SustainedOutageRule : AlarmRule
    {
        private readonly int _minConsecutive;
        public SustainedOutageRule(int min) : base("SustainedOutage")
        {
            _minConsecutive = min;
        }
        public override bool IsTriggered(LoadProfileDay day)
        {
            int consecutiveZeros = 0;
            foreach (var hour in day.HourlyKwh)
            {
                if (hour == 0)
                {
                    consecutiveZeros++;
                    if (consecutiveZeros >= _minConsecutive)
                    {
                        return true;
                    }
                }
                else
                {
                    consecutiveZeros = 0;
                }
            }
            return false;
        }
    }
}
