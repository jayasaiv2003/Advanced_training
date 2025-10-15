using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oops_assignments
{
    internal class meter
    {
        //public string MeterSerial;
        //public string Location;
        //public DateTime InstalledOn;
        //public int LastReadingKwh;

        //Make fields auto-properties with validation in set.
        
            private string _meterSerial;
            public string MeterSerial
            {
                get => _meterSerial;
                set
                {
                    if (string.IsNullOrWhiteSpace(value))
                        throw new ArgumentException("MeterSerial cannot be null or empty.");
                    _meterSerial = value.Trim();
                }
            }

            private string _location;
            public string Location
            {
                get => _location;
                set
                {
                    if (string.IsNullOrWhiteSpace(value))
                        throw new ArgumentException("Location cannot be null or empty.");
                    _location = value.Trim();
                }
            }

            private DateTime _installedOn;
            public DateTime InstalledOn
            {
                get => _installedOn;
                set
                {
                    if (value > DateTime.Now)
                        throw new ArgumentException("InstalledOn cannot be a future date.");
                    _installedOn = value;
                }
            }

            private int _lastReadingKwh;
            public int LastReadingKwh
            {
                get => _lastReadingKwh;
                set
                {
                    if (value < 0)
                        throw new ArgumentException("LastReadingKwh cannot be negative.");
                    _lastReadingKwh = value;
                }
            }

            public void AddReading(int deltaKwh)
            {
                if (deltaKwh > 0) //condition check
                {
                    LastReadingKwh += deltaKwh;

                }
            }

            //object initializer

            //public meter(string meterSerial, string location, DateTime installedOn, int lastReadingKwh)
            //{
            //    this.MeterSerial = meterSerial;
            //    this.Location = location;
            //    this.InstalledOn = installedOn;
            //    this.LastReadingKwh = lastReadingKwh;
            //}

            //Summary() : returns "SERIAL Location: X | Reading: Y".
            public string Summary()
            {
                return $"{MeterSerial} Location: {Location} | Reading: {LastReadingKwh}";
            }

            //Add ToString() and just Console.WriteLine(meter).
            public override string ToString()
            {
                return Summary();
            }
        
    }
}
