namespace SfetsosOOP;

public class EpidotisiEnikoiou
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int SitRep { get; set; }
    public float Income { get; set; }
    public int DependentMembers { get; set; }

    public EpidotisiEnikoiou(string? firstName, string? lastName, int sitRep, float income, int dependentMembers)
    {
        FirstName = firstName;
        LastName = lastName;
        SitRep = sitRep;
        Income = income;
        DependentMembers = dependentMembers;
    }

    public bool Check()
    {
        if (DependentMembers == 0)
        {
            return Income <= 3600;
        }

        if (DependentMembers >= 3)
        {
            return (new EpidotisiEnikoiou(FirstName, LastName, SitRep, Income - 1200, 2)).Check();
        }

        return (new EpidotisiEnikoiou(FirstName, LastName, SitRep, Income - 600, DependentMembers - 1)).Check();
    }
    
}