using System.Diagnostics;

public class FibonacciCalculator

{
    // Recursive: It calls itself. 5 calls 4 that calls 3 that calls 2... Inefficient.
    public static int FibonacciRecursive(int n)
    {
        if (n <= 1)
        {
            return n;
        }
        return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);
    }

    // Iterative: a, b and c save the values so every number is calculated once. More efficient.
    public static int FibonacciIterative(int n)
    {
        if (n <= 1)
        {
            return n;
        }

        int a = 0, b = 1, c = 0;

        for (int i = 2; i <= n; i++)
        {
            c = a + b;
            a = b;
            b = c;
        }

        return c;
    }
    
    
    //ChatGPT helped here:
    public static void Main(string[] args)
    {
        int n = 40;

        // Measure time for recursive Fibonacci
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        int recursiveResult = FibonacciRecursive(n);
        stopwatch.Stop();
        Console.WriteLine($"Recursive Fibonacci({n}) = {recursiveResult}");
        Console.WriteLine($"Time taken (recursive): {stopwatch.ElapsedMilliseconds} ms");

        // Measure time for iterative Fibonacci
        stopwatch.Reset();
        stopwatch.Start();
        int iterativeResult = FibonacciIterative(n);
        stopwatch.Stop();
        Console.WriteLine($"Iterative Fibonacci({n}) = {iterativeResult}");
        Console.WriteLine($"Time taken (iterative): {stopwatch.ElapsedMilliseconds} ms");
    }
}