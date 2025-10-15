using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oops_assignments
{

//    Define:

//#
//public interface IBillingRule { double Compute(int units); }
//    class DomesticRule : IBillingRule { /* 6.0/unit + 50 fixed */ }
//    class CommercialRule : IBillingRule { /* 8.5/unit + 150 fixed */ }
//    class AgricultureRule : IBillingRule
//    { /* 3.0/unit + 0 fixed */ }
//Create BillingEngine with IBillingRule Rule; and double GenerateBill(int units).
    internal interface IBillingRule
    {
        double Compute(int units);

    }
    public class DomesticRule : IBillingRule
    {
       
        public double Compute(int units)
        {
            return (units * 6.0) + 50.0;
        }
    }
    public class CommercialRule : IBillingRule
    {
        
        public double Compute(int units)
        {
            return (units * 8.5) + 150.0;
        }
    }

    public class AgricultureRule : IBillingRule
    {
        public double Compute(int units)
        {
            return (units * 3.0) + 0.0;
        }
    }
     class BillingEngine
    {
        public IBillingRule Rule;
        public BillingEngine(IBillingRule rule)
        {
            this.Rule = rule;
        }
        public void GenerateBill(int units)
        {
            double a = Rule.Compute(units);
            Console.WriteLine($"{Rule}->{a}");
        }
    }
}
