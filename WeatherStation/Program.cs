namespace WeatherStation
{
    using System;
    using System.Diagnostics;
    using System.Threading;

    using ObserverPatternDemo.Implemantation.Observable;
    using ObserverPatternDemo.Implemantation.Observers;

    class Program
    {
        static void Main(string[] args)
        {
            WeatherData data = new WeatherData();
            CurrentConditionsReport currentConditionsReport = new CurrentConditionsReport();
            StatisticReport statisticReport = new StatisticReport();

            data.Register(currentConditionsReport);
            data.Register(statisticReport);
            int time = 0, period = 0;
            string str = " ";
            while (!int.TryParse(str, out time) || time < 0)
            {
                Console.WriteLine("Enter time in seconds: ");
                str = Console.ReadLine();
            }

            str = " ";
            while (!int.TryParse(str, out period) || period < 0)
            {
                Console.WriteLine("Enter period in milliseconds: ");
                str = Console.ReadLine();
            }

            Start(time, period, data);

            Console.WriteLine(statisticReport.GenerateReport());
        }

        private static WeatherInfo GenerateWeatherChanges()
        {
            Random random = new Random();
            WeatherInfo info = new WeatherInfo();
            info.Pressure = random.Next(700, 800);
            info.Humidity = random.Next(0, 100);
            info.Temperature = random.Next(-10, 25);
            return info;
        }

        static void Help()
        {
            Console.WriteLine("List of commands: ");
            Console.WriteLine("1. Update weather");
            Console.WriteLine("2. Get current weather state");
            Console.WriteLine("3. Generate weather report");
            Console.WriteLine("4. Exit");
        }

        private static void Start(int time, int period, WeatherData data)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while (stopwatch.ElapsedMilliseconds < time * 1000)
            {
                data.GetCurrentWeather(GenerateWeatherChanges());
                Thread.Sleep(period);
            }
        }
    }
}
