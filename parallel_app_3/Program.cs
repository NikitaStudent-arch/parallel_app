namespace parallel_app_3
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? City { get; set; }
        public bool IsActive { get; set; }
        public int Points { get; set; }
        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Age: {Age}, City: {City}, IsActive: {IsActive}, Points: {Points}";
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            var users = GetUsers();
            //var result = users.AsParallel()
            //    .Where(u => u.City.Equals("Kharkiv") && u.IsActive == true && u.Points > 70);
            //PrintCollection(result);

            var result1 = users.AsParallel()
                .Where(u => u.Age >= 18)
                .Select(u => new { u.Name, u.Age });
            PrintCollection(result1);
            var result2 = users.AsParallel()
                .Where(u => u.City == "Kharkiv")
                .Select(u => u.Name);
            PrintCollection(result2);
            var result3 = users.AsParallel()
                .Where(u => u.IsActive == true)
                .Select(u => new { u.Name, u.Points });
            PrintCollection(result3);
            var result4 = users.AsParallel()
                .Where(u => u.Points >= 80)
                .Select(u => new { u.Name, u.Points })
                 .OrderByDescending(u => u.Points);
            PrintCollection(result4);
            var result5 = users.AsParallel()
                .OrderByDescending(u => u.Points)
                .Take(5)
                .Select(u => new { u.Name, u.Points });
            PrintCollection(result5);
            double averageAge = users.AsParallel()
                .Average(u => u.Age);
            Console.WriteLine($"Average Age: {averageAge}");
            double maxPoints = users.AsParallel().Max(u => u.Points);
            double minPoints = users.AsParallel().Min(u => u.Points);
            Console.WriteLine($"Max: {maxPoints}, min: {minPoints}");
            var result8 = users.AsParallel()
                .GroupBy(u => u.City)
                .Select(g => new { City = g.Key, Count = g.Count() });
            PrintCollection(result8);
            var result9 = users.AsParallel()
                .Where(u => u.Age >= 18 && u.Age <= 25)
                .Select(u => new
                {
                    u.Name,
                    ThreadId = Thread.CurrentThread.ManagedThreadId
                });
            PrintCollection(result9);
            var result10 = users.AsParallel()
                .Select(u => new
                {
                    u.Name,
                    NewPoints = Math.Round(u.Points * 1.10, 2)
                })
                .Where(u => u.NewPoints > 90);
            PrintCollection(result10);
        }
        public static void PrintCollection<T>(IEnumerable<T> values)
        {
            foreach (var value in values)
            {
                Console.WriteLine(value);
            }
        }
        public static IEnumerable<User> GetUsers()
            => new List<User>()
                {
                    new User { Id = 1, Name = "Oleksandr", Age = 17, City = "Kharkiv", IsActive = true, Points = 85 },
                    new User { Id = 2, Name = "Mariia", Age = 19, City = "Kyiv", IsActive = true, Points = 92 },
                    new User { Id = 3, Name = "Andrii", Age = 16, City = "Lviv", IsActive = false, Points = 65 },
                    new User { Id = 4, Name = "Iryna", Age = 21, City = "Kharkiv", IsActive = true, Points = 78 },
                    new User { Id = 5, Name = "Dmytro", Age = 18, City = "Odesa", IsActive = false, Points = 45 },
                    new User { Id = 6, Name = "Sofiia", Age = 20, City = "Kyiv", IsActive = true, Points = 99 },
                    new User { Id = 7, Name = "Maksym", Age = 17, City = "Kharkiv", IsActive = true, Points = 55 },
                    new User { Id = 8, Name = "Anna", Age = 22, City = "Lviv", IsActive = false, Points = 88 }
                };
    }
}