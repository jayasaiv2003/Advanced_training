using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oops_assignments
{
    internal class Tariff
    {
        public string Name;
        public double RatePerKwh;
        public double FixedCharge;

        //        Ctors:

        //Tariff(string name) → defaults: rate=6.0, fixed=50.

        //Tariff(string name, double rate) → defaults fixed=50.

        //Tariff(string name, double rate, double fixedCharge).
        public Tariff(string name)
        {
            this.Name = name;
            this.RatePerKwh = 6.0;
            this.FixedCharge = 50.0;
        }
        public Tariff(string name, double ratePerKwh)
        {
            this.Name = name;
            this.RatePerKwh = ratePerKwh;
            this.FixedCharge = 50.0;
            Validate();
        }
        public Tariff(string name, double ratePerKwh, double fixedCharge)
        {
            this.Name = name;
            this.RatePerKwh = ratePerKwh;
            this.FixedCharge = fixedCharge;
            Validate();
        }
        public void ComputeBill(int units)
        {
            double billAmount = (units * RatePerKwh) + FixedCharge;
            Console.WriteLine($"Bill Amount for {units} units under {Name} tariff is: {billAmount}");
        }
        //Add Validate() that throws if rate <= 0 or fixed < 0.Call in constructors.
        public void Validate()
        {
            if (RatePerKwh <= 0)
            {
                throw new ArgumentException("RatePerKwh must be greater than 0.");
            }
            if (FixedCharge < 0)
            {
                throw new ArgumentException("FixedCharge cannot be negative.");
            }
        }
    }
}
