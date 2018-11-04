namespace WeatherStation
{
    using System;

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

            bool isRunning = true;
            Help();
            while (isRunning)
            {
                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Help();
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        data.GetCurrentWeather(GenerateWeatherChanges());
                        Console.WriteLine("Updated successfully!");
                        break;
                    case 2:
                        try
                        {
                            Console.WriteLine(currentConditionsReport.GetCurrentCondition());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        break;
                    case 3:
                        try
                        {
                            Console.WriteLine(statisticReport.GenerateReport());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        break;
                    case 4:
                        isRunning = false;
                        break;
                    default:
                        Help();
                        break;
                }
            }
        }

        static WeatherInfo GenerateWeatherChanges()
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
    }
}
