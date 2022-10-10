namespace FactorialAPI;

public interface IStaticMethods
{
    public int RecursiveFactorial(int n);
}

public sealed class StaticMethods : IStaticMethods
{
    public int RecursiveFactorial(int n)
    {
        if (n == 0)
        {
            return 1;
        }
        return RecursiveFactorial(n - 1) * n;
    }
    
}