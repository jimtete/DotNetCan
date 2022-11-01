Console.Write("Give me test cases: ");
int TestCase = Int32.Parse(Console.ReadLine());
int [] Patients = new int[TestCase];
List<int[,]> Windows = new List<int[,]>();

for (int i = 0; i < TestCase; i++)
{
    Console.Write("Give me number of patients: ");
    Patients[i] = Int32.Parse(Console.ReadLine());
    int[,]Window = new int [Patients[i],2];
    
    for (int j = 0; j < Patients[i]; j++)
    {
        Console.WriteLine("Give me window");
        Console.Write("[a:");
        Window[j,0] = Int32.Parse(Console.ReadLine());
        Console.Write("b]:");
        Window[j,1] = Int32.Parse(Console.ReadLine());
    }
    Windows.Add(Window);
}

//Printing the data

Console.WriteLine(TestCase);
foreach (var VARIABLE in Patients)
{
    Console.Write(VARIABLE + " ");
}

foreach (var x in Windows)
{
    foreach (var y in x)
    {
        Console.WriteLine(y + " ");
    }
    Console.WriteLine();
}