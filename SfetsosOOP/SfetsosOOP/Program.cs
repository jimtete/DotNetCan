// See https://aka.ms/new-console-template for more information

using SfetsosOOP;

var EE1 = new EpidotisiEnikoiou("Kikos","Kikou",-1,5000,0);
var EE2 = new EpidotisiEnikoiou("Nikos", "Nikas", -1, 4200,2);
var EE3 = new EpidotisiEnikoiou("Paulos","Paulou",-1,4100,1);
var EE4 = new EpidotisiEnikoiou("Vasilis","Vasileiou",-1,7000,3);

EpidotisiEnikoiou[] EE = { EE1, EE2, EE3, EE4 };

foreach (var ee in EE)
{
    ee.SitRep = 1;
    if (ee.DependentMembers > 0) ee.SitRep = 2;
    Console.WriteLine(ee.Check());
}

