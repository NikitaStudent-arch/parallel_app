using System.Diagnostics.CodeAnalysis;

namespace parallel_app
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Simple example
            //for (int i = 1; i <= 10; i++)
            //{
            //    Console.WriteLine($"Iteration i: {i}");
            //    Thread.Sleep(3000);
            //}

            int sum = 0;
            //Parallel example
            Parallel.For(1, 20, i =>
            {
                //Задачі виконуються паралельлно
                sum += i;
                Console.WriteLine($"Iteration i: {i}");
                Thread.Sleep(3000);
            });
            Console.WriteLine($"Sum: {sum}");
        }
    }
}