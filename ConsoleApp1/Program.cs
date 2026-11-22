namespace parallel_app_2
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] numbers_sorted = { 1, 2, 3, 4, 5, 6, 7 };
            var result = numbers_sorted.AsParallel().Where(n => n > 2);
            Parallel.For(0, numbers_sorted.Length, i =>
            {
                Console.Write(numbers_sorted[i] + "\t");
            });

            //Console.Write("Input n: ");
            //int n = int.Parse(Console.ReadLine());
            //Parallel.For(1, n + 1, i =>
            //{
            //    Console.WriteLine($"{i}^2 = {i*i}");
            //});
        }
    }
}
