using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oops_assignments
{
    public interface IRebate
    {
        string Code { get; }
        double Apply(double currentTotal, int outageDays);
    }
    class NoOutageRebate : IRebate
    {
        public string Code => "NO_OUTAGE";
        public double Apply(double currentTotal, int outageDays)
        {
            if (outageDays == 0)
                return -0.02 * currentTotal;
            return 0;
        }
    }
    class HighUsageRebate : IRebate
    {
        public string Code => "HIGH_USAGE";
        public double Apply(double currentTotal, int outageDays)
        {
            if (currentTotal > 500)
                return -0.03 * currentTotal;
            return 0;
        }
    }
    class BillingContext
    {
        public IBillingRule Rule { get; }
        public List<IRebate> Rebates { get; } = new();
        public BillingContext(IBillingRule rule) => Rule = rule;
        public double Finalize(int units, int outageDays)
        {
            double total = Rule.Compute(units);
            foreach (var r in Rebates) total += r.Apply(total, outageDays);
            return total;
        }
    }

}

