﻿namespace AD
{
    public class Opgave2
    {
        static long calls = 0;

        private static long FibonacciRecursiveInternal(int n)
        {
            calls++;
            return n + (n - 1);
        }

        public static long FibonacciRecursive(int n)
        {
            calls = 0;
            FibonacciRecursiveInternal(n);
            return (n < 2) ? n : FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);

        }

        private static long FibonacciIterativeInternal(int n)
        {
            calls++;
            return calls;
        }

        public static long FibonacciIterative(int n)
        {
            calls = 0;
            if (n == 0) return 0;
            int prev = 0;
            int next = 1;
            for (int i = 1; i < n; i++)
            {
                FibonacciIterativeInternal(i);
                int sum = prev + next;
                prev = next;
                next = sum;
            }
            return next;
        }

        public static void Run()
        {
            int MAX = 35;

            System.Console.WriteLine("Recursief:");
            for (int n = 1; n <= MAX; n++)
            {
                System.Console.WriteLine("          Fibonacci({0,2}) = {1,8} ({2,9} calls)", n, FibonacciRecursive(n), calls);
            }
            System.Console.WriteLine("Iteratief:");
            for (int n = 1; n <= MAX; n++)
            {
                System.Console.WriteLine("          Fibonacci({0,2}) = {1,8} ({2,9} loops)", n, FibonacciIterative(n), calls);
            }
        }
    }
}
