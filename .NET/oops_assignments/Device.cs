using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oops_assignments
{

    //Base class Device :

    //Props: Id(string), InstalledOn(DateTime).

    //Method: Virtual Describe() → "Device Id: ... InstalledOn: ..."

    //Derived:

    //Meter adds PhaseCount(int) and overrides Describe() to include it.

    //Gateway adds IpAddress(string) and overrides Describe().
    internal class Device
    {

        public string Id;
        public DateTime InstalledOn;
        
        public virtual void Describe()
        {
            Console.WriteLine($"Device Id: {Id} InstalledOn: {InstalledOn}");
        }
        //add protected constructor in base.
        protected Device()
        {
            if (InstalledOn == null)
            {
                InstalledOn = DateTime.Now;
            }
        }
    }
    internal class Meter : Device
    {
        public int PhaseCount;
        public override void Describe()
        {
            base.Describe();
            Console.WriteLine($"Device Id: {Id} InstalledOn: {InstalledOn},PhaseCount: {PhaseCount}");
        }
    }
    internal class Gateway : Device
    {
        public string IpAddress;
        public override void Describe()
        {
            base.Describe();
            Console.WriteLine($"Device Id: {Id} InstalledOn: {InstalledOn},IpAddress: {IpAddress}");
        }
    }
}
