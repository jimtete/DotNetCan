//Excercise9();
//Excercise10();
//Excercise12();
//Excercise13();
//Excercise15();
//Excercise16();
//Excercise17();
//Excercise18();
//Excercise19();
//Excercise20();
//Excercise21();
//Excercise22();
//Excercise23();
//Excercise24();
//Excercise25();
//Exercise26();




//MyExcercise1();

static void Excercise9()
{
    int a, b, c, d;
    Console.WriteLine("Enter the first number: ");
    a = Int32.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
    Console.WriteLine("Enter the second number: ");
    b = Int32.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
    Console.WriteLine("Enter the third number: ");
    c = Int32.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
    Console.WriteLine("Enter the fourth number: ");
    d = Int32.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

    Console.WriteLine("The average of {0}, {1}, {2} and {3} is: {4}", a, b, c, d, (a + b + c + d) / 4);
}
//
static void Excercise10()
{
    int x, y, z;
    Console.WriteLine("Enter the first number - ");
    x = Int32.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
    Console.WriteLine("Enter the second number - ");
    y = Int32.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
    Console.WriteLine("Enter the third number - ");
    z = Int32.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

    Console.WriteLine("Result of specified numbers {0}, {1} and {2}, (x+y)*z = {3} and x*y + y*z = {4}"
        , x, y, z, (x + y) * z, x * y + y * z);

}
//
static void Excercise12()
{
    int d;
    Console.Write("Enter a digit: ");
    d = Int32.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

    for (int i = 0; i < 2; i++)
    {
        Console.WriteLine("{0} {0} {0} {0}",d);
        Console.WriteLine("{0}{0}{0}{0}",d);
    }
}
//
static void Excercise13()
{
    Console.Write("Enter a digit: ");
    int d = Int32.Parse(Console.ReadLine());
    Console.WriteLine("{0}{0}{0}",d);
    Console.WriteLine("{0} {0}",d);
    Console.WriteLine("{0} {0}",d);
    Console.WriteLine("{0} {0}",d);
    Console.WriteLine("{0}{0}{0}",d);
}
//
static void Excercise15()
{
    Console.Write("Test data: ");
    string input = Console.ReadLine();

    Console.WriteLine(input.Remove(3,1));
    Console.WriteLine(input.Remove(5,1));
    Console.WriteLine(input.Remove(1,1));
}
//
static void Excercise16()
{
    Console.Write("Test data: ");
    string input = Console.ReadLine() ?? throw new InvalidOperationException();
    string first = input.Substring(0, 1);
    string last = input.Substring(input.Length-1, 1);

    Console.WriteLine(last+input.Substring(1,input.Length-1)+first);
}
//
static void MyExcercise1()
{
    Console.WriteLine(CheckString("stealthisalbum"));


    static string CheckString(string str)
    {

        return RecursiveCheck(str, str.Substring(0, 1), str.Substring(1, 1));

    }

    static string RecursiveCheck(string mainString, string subString, string character)
    {
        for (int i = 0; i < subString.Length; i++)
        {
            if (character.Equals(subString.Substring(i, 1))) return character;
        }

        if (subString.Length + 1 == mainString.Length) return "";

        return RecursiveCheck(mainString, mainString.Substring(0, subString.Length + 1),
            mainString.Substring(subString.Length, 1));


    }
    
}
//
static void Excercise17()
{
    Console.Write("Sample input: ");
    string str = Console.ReadLine();
    string first = str.Substring(0, 1);

    str = first + str + first;
    Console.WriteLine("New String: {0}",str);

}
//
static void Excercise18()
{
    Console.WriteLine("Give me two integers");
    Console.Write("a:");
    int a = Int32.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
    Console.Write("b:");
    int b = Int32.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

    Console.WriteLine(CheckPosNeg(a, b));

    static bool CheckPosNeg(int a, int b)
    {
        return ((a > 0 && b < 0) || (a < 0 && b > 0));
    }

}
//
static void Excercise19()
{
    Console.WriteLine("Give me two integers");
    Console.Write("a:");
    int a = Int32.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
    Console.Write("b:");
    int b = Int32.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

    Console.WriteLine("Sum: {0}",ReturnSum(a,b));

    static int ReturnSum(int a, int b)
    {
        if (a == b) return 6 * a;
        return a + b;
    }
}
//
static void Excercise20()
{

    Console.WriteLine("Give me two integers");
    Console.Write("a:");
    int a = Int32.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
    Console.Write("b:");
    int b = Int32.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

    Console.WriteLine("Absolute difference of the two integers: {0}", DifferenceCalculator(a, b));

    static int DifferenceCalculator(int a, int b)
    {
        if (a > b) return 2 * (a - b);
        return b - a;
    }
}
//
static void Excercise21()
{
    Console.WriteLine("Give me two integers");
    Console.Write("a:");
    int a = Int32.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
    Console.Write("b:");
    int b = Int32.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

    Console.WriteLine("Result of the two numbers calculations: {0}", 
        (a == 20 || b == 20 || a + b == 20));

}
//
static void Excercise22()
{
    Console.WriteLine("Give me an integer");
    Console.Write("a:");
    int a = Int32.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

    Console.WriteLine("Integer {0} fits the parameters: {1}", a, CheckParameters(a));

    static bool CheckParameters(int a)
    {
        if (a > 300) return false;
        return (a % 100) <= 20;
    }
}
//
static void Excercise23()
{
    Console.Write("Give me a string: ");
    String str = Console.ReadLine() ?? throw new InvalidOperationException();

    Console.WriteLine(str.ToLower());
}
//
static void Excercise24()
{
    string input = "Afto einai ena dokimasitko string?";

    string longest = FindLongestSubstring("", 0, input);

    Console.WriteLine("Longest string: {0}", longest);

    static string FindLongestSubstring(string sub, int length, string str)
    {
        if (str.IndexOf(" ") == str.LastIndexOf(" "))
        {
            if (((str.Substring(0, str.IndexOf(" "))).Length > length) &&
                (str.Substring(str.IndexOf(" ")+1, str.Length-1-str.IndexOf(" "))).Length > length)
                return (str.Substring(0, str.IndexOf(" ")));

            if ((str.Substring(str.IndexOf(" ")+1, str.Length-str.IndexOf(" ")-1)).Length > length)
                return (str.Substring(str.IndexOf(" ")+1, str.Length-1-str.IndexOf(" ")));
            
            return sub;
        }

        string temp = str.Substring(0, str.IndexOf(" "));
        
        
        int start = str.IndexOf(" ");
        int end = str.Length;
        
        
        string remainingString = str.Substring(start+1,end-start-1);

        if (temp.Length > length) return FindLongestSubstring(temp, temp.Length, remainingString);
        return FindLongestSubstring(sub, length, remainingString);
    }
}
//
static void Excercise25()
{
    for (int i = 1; i <= 99; i++)
    {
        if (i % 2 == 1) Console.WriteLine(i);
    }
}
//
static void Exercise26()
{
    int sum = CalculateSumOfPrime(500,2);
    Console.WriteLine("The sum of the first 500 numbers is: {0}", sum);

    static int CalculateSumOfPrime(int n,int number)
    {
        if (n == 0) return 0;
        for (int i = 2; i <= number; i++)
        {
            if (number % i == 0 && number != i) return CalculateSumOfPrime(n, number + 1);
            
        }
        return number + CalculateSumOfPrime(n - 1, number + 1);
    }

}