namespace AD
{
    public class Opgave4
    {
        public static int Enen(int n)
        {
            int value = 0;
            if (n % 2 != 0)
                value++;
            return (n < 1) ? value  : value + Enen(n / 2);
        }

        public static void Run()
        {
            for (int i = 0; i < 20; i++)
            {
                System.Console.WriteLine("Enen({0,4}) = {1,2}", i, Enen(i));
            }
            System.Console.WriteLine("Enen(1024) = {0,2}", Enen(1024));
            System.Console.WriteLine();
        }
    }
}
