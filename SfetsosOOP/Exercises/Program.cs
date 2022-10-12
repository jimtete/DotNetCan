//Exercise37();
//Exercise39();
//Exercise40();
//Exercise41();
Exercise42();

static void Exercise37()
{
    string Str = "PHP Tutorial";

    Console.WriteLine(GetModifiedString(Str));

    static string GetModifiedString(String str)
    {
        if (str.Substring(1, 2).Equals("HP"))
        {
            return str.Substring(0, 1) + str.Substring(3, str.Length - 3);
        }

        return "";
    }
}
//
static void Exercise39()
{
    int a, b, c;
    Console.Write("first integer:");
    a = Int32.Parse(Console.ReadLine()!);
    Console.Write("second integer:");
    b = Int32.Parse(Console.ReadLine()!);
    Console.Write("third integer:");
    c = Int32.Parse(Console.ReadLine()!);

    Console.Write("Largest number of {0}, {1} and {2} is: {3}",a,b,c,CheckTwoNumbers(CheckTwoNumbers(a,b),c));
    
    static int CheckTwoNumbers(int a, int b)
    {
        if (a > b) return a;
        return b;
    }

}
//
static void Exercise40()
{
    Console.Write("first integer: ");
    int a = Int32.Parse(Console.ReadLine()!);
    Console.Write("second integer: ");
    int b = Int32.Parse(Console.ReadLine()!);

    int DiffA = Math.Abs(a - 20);
    int DiffB = Math.Abs(b - 20);

    if (DiffA > DiffB) Console.WriteLine(b);
    else if (DiffA < DiffB) Console.WriteLine(a);
    else Console.WriteLine(0);
}
//
static void Exercise41()
{
    string input = "why are we here, just to suffer";

    int value = CheckString(input, "w");

    Console.WriteLine("Assumption:{0}",(value>=1&&value<=3));

    static int CheckString(string input, string c)
    {
        if (input.Length==0) return 0;
        if (input.Substring(0, 1).Equals(c))
        {
            return 1+CheckString(input.Substring(1, input.Length - 1),c);
        }

        return CheckString(input.Substring(1, input.Length - 1), c);


    }


}
//
static void Exercise42()
{
    
}