using System;
using System.Data;
using System.Diagnostics.Metrics;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace oops_assignments
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");


            //Task1

            //Instantiate two meters, set properties via object initializer.


            //meter meter1=new meter { MeterSerial="AP-0001", Location="Feeder-12", InstalledOn=new DateTime(2020, 07, 23), LastReadingKwh=15230 };

            //meter meter2= new meter { MeterSerial = "AP-0002", Location = "Feeder-15", InstalledOn = new DateTime(2021, 08, 24), LastReadingKwh = 9800 };

            //meter1.AddReading(500);  //valid Reading
            //meter1.AddReading(-200);  //invalid Reading, should be ignored`   
            //Console.WriteLine(meter1);


            //Task2

            //Create three tariffs using different constructors.

            //For units = 120, print computed bill for each.

            //Expected Output (example)

            //DOMESTIC: ₹770.00
            //COMMERCIAL: ₹1170.00
            //AGRI: ₹410.00

            Tariff tariff1 = new Tariff("DOMESTIC");
            Tariff tariff2 = new Tariff("COMMERCIAL", 9.0);
            Tariff tariff3 = new Tariff("AGRI", -3.0, 30.0);  //validating for -ve values of rateperkwh
            tariff1.ComputeBill(120);
            tariff2.ComputeBill(120);
            tariff3.ComputeBill(120);


            //Task3

            // Create Device[] with 1 meter + 1 gateway(polymorphic array).

            //Device[] devices = new Device[2];
            //devices[0] = new Meter() { Id = "AP-0001", InstalledOn = new DateTime(2024, 7, 1), PhaseCount = 3 };
            //devices[1] = new Gateway() { Id = "GW-11", InstalledOn = new DateTime(2025, 1, 10), IpAddress = "0.0.5.21" };


            //foreach (Device d in devices)
            //{
            //    d.Describe();
            //}

            //Task4

            //            Put both in List<IReadable> and poll 5 times(loop).

            //Print "SourceId -> deltaKwh" for each poll.

            //Expected Output(sample)

            //AP-0001-> 7
            //GW-21-> 1...

            //List<IReadable> readables = new List<IReadable>();
            //readables.Add(new DlmsMeter("AP-0001"));
            //readables.Add(new ModemGateway("GW-21"));
            //for (int i = 0; i < 5; i++)
            //{
            //    foreach (IReadable r in readables)
            //    {
            //        int deltaKwh = r.ReadKwh();
            //        Console.WriteLine($"{r.SourceId} -> {deltaKwh}");
            //    }
            //}


            //task5

            //       public interface IBillingRule { double Compute(int units); }
            //class DomesticRule : IBillingRule { /* 6.0/unit + 50 fixed */ }
            //class CommercialRule : IBillingRule { /* 8.5/unit + 150 fixed */ }
            //class AgricultureRule : IBillingRule { /* 3.0/unit + 0 fixed */ }

            //            With units = 120, compute bills using each rule instance.

            //Print category +amount.

            //Expected Output

            //DOMESTIC-> ₹770.00
            //COMMERCIAL-> ₹1170.00
            //AGRICULTURE-> ₹360.00


            //BillingEngine domesticBilling = new BillingEngine(new DomesticRule());
            //domesticBilling.GenerateBill(120);
            //BillingEngine commercialBilling = new BillingEngine(new CommercialRule());
            //commercialBilling.GenerateBill(120);
            //BillingEngine agricultureBilling = new BillingEngine(new AgricultureRule());
            //agricultureBilling.GenerateBill(120);


            //task6
            //           

            //Build a valid HourlyKwh array; instantiate a day.

            //Print Date, Total, PeakHour.

            //Expected Output

            //2025-10-01 | Total: 82 kWh | PeakHour: 19

            //int[] HourlyKwh = new int[]
            //{
            //    3,2,1,0,0,0,1,2,3,4,5,6,
            //    5,4,3,2,1,2,3,10,8,6,4,2
            //};
            //  LoadProfileDay profileDay = new LoadProfileDay(new DateTime(2025, 10, 1), HourlyKwh);
            //  DateTime date = profileDay.Date;
            //  int total = profileDay.Total;
            //  int peakHour = profileDay.PeakHour;
            //  Console.WriteLine($"Date: {date} | Total :{total} | PeakHour: {peakHour}");


            //task7


            //            Build a LoadProfileDay with some zeros &highs.

            //Evaluate rules and print triggered messages.

            //Expected Output

            //PeakOveruse triggered on 2025-10-01

            //(or both, depending on data)


            //LoadProfileDay profileDay = new LoadProfileDay(new DateTime(2025, 10, 1), new int[]
            //{
            //    3,2,1,0,0,0,1,2,3,4,5,6,
            //    5,4,3,2,1,2,3,10,8,6,4,2
            //});
            //AlarmRule peakOveruseRule = new PeakOveruseRule(80);
            //AlarmRule sustainedOutageRule = new SustainedOutageRule(3);
            //if (peakOveruseRule.IsTriggered(profileDay))
            //{
            //    Console.WriteLine(peakOveruseRule.Message(profileDay));
            //}
            //if (sustainedOutageRule.IsTriggered(profileDay))
            //{
            //    Console.WriteLine(sustainedOutageRule.Message(profileDay));
            //}

            //task 9
            //Task-9

            //IBillingRule rule = new CommercialRule();
            //BillingContext context = new BillingContext(rule);
            //context.Rebates.Add(new NoOutageRebate());
            //context.Rebates.Add(new HighUsageRebate());
            //double total = context.Finalize(620, 0);
            //double subtotal = rule.Compute(620);
            //Console.WriteLine($"Subtotal : {subtotal} | Total : {total}");

            //Task-10
            //            IEnumerable<Event> events = new List<Event>
            //{
            //    new OutageEvent(new DateTime(2023, 10, 1, 14, 30, 0), "MTR-001", 120),
            //    new TamperEvent(new DateTime(2023, 10, 2, 9, 15, 0), "MTR-002", "TAMPER123"),
            //    new VoltageEvent(new DateTime(2023, 10, 17, 16, 45, 0), "MTR-003", 240.5),
            //    new OutageEvent(new DateTime(2023, 10, 18, 11, 0, 0), "MTR-004", 60),
            //    new TamperEvent(new DateTime(2023, 10, 9, 14, 0, 0), "MTR-005", "TAMPER456"),
            //    new VoltageEvent(new DateTime(2023, 10, 21, 18, 30, 0), "MTR-006", 230.0),
            //    new OutageEvent(new DateTime(2023, 9, 13, 11, 0, 0), "MTR-007", 90),
            //    new VoltageEvent(new DateTime(2023, 8, 21, 18, 36, 17), "MTR-006", 254.0)
            //};
            // EventProcessor.PrintTopSevere(events, 3);



        }



        //Create a Tariff class with :         
        //Props: Name(string), RatePerKwh(double), FixedCharge(double).

        //class Tariff
        //{
        //    string Name;
        //    double RatePerKwh;
        //    double FixedCharge;

        //    //        Ctors:

        //    //Tariff(string name) → defaults: rate=6.0, fixed=50.

        //    //Tariff(string name, double rate) → defaults fixed=50.

        //    //Tariff(string name, double rate, double fixedCharge).
        //    public Tariff(string name)
        //    {
        //        this.Name = name;
        //        this.RatePerKwh = 6.0;
        //        this.FixedCharge = 50.0;
        //    }
        //    public Tariff(string name, double ratePerKwh)
        //    {
        //        this.Name = name;
        //        this.RatePerKwh = ratePerKwh;
        //        this.FixedCharge = 50.0;
        //    }
        //    public Tariff(string name, double ratePerKwh, double fixedCharge)
        //    {
        //        this.Name = name;
        //        this.RatePerKwh = ratePerKwh;
        //        this.FixedCharge = fixedCharge;
        //    }
        //    public void ComputeBill(int units)
        //    {
        //        double billAmount = (units * RatePerKwh) + FixedCharge;
        //        Console.WriteLine($"Bill Amount for {units} units under {Name} tariff is: {billAmount}");
        //    }
        //}

    }
}
