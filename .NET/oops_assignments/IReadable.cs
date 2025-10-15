using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oops_assignments
{


//    Define IReadable:

//#
//public interface IReadable
//    {
//        int ReadKwh();             // returns delta since last poll
//        string SourceId { get; }
//    }
//    Implement:

//DlmsMeter : IReadable(returns a random 1--10 kWh).

//ModemGateway : IReadable(returns a random 0--2 kWh representing backfill).
    internal interface IReadable
    {
        int ReadKwh();            
        string SourceId { get; }
    }
    public class DlmsMeter : IReadable
    {
        private static Random rand = new Random();
        public string SourceId { get; private set; }
        public DlmsMeter(string sourceId)
        {
            SourceId = sourceId;
        }
        public int ReadKwh()
        {
            return rand.Next(1, 11); // returns a random value between 1 and 10
        }
    }
    public class ModemGateway : IReadable
    {
        private static Random rand = new Random();
        public string SourceId { get; private set; }
        public ModemGateway(string sourceId)
        {
            SourceId = sourceId;
        }
        public int ReadKwh()
        {
            return rand.Next(0, 3); // returns a random value between 0 and 2
        }
    }
}
