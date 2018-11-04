using System;
using ObserverPatternDemo.Implemantation.Observable;

namespace ObserverPatternDemo.Implemantation.Observers
{
    using System.Collections.Generic;

    public class StatisticReport : IObserver<WeatherInfo>
    {
        List<WeatherInfo> infos = new List<WeatherInfo>();

        public void Update(IObservable<WeatherInfo> sender, WeatherInfo info)
        {
            WeatherInfo temp = new WeatherInfo();
            temp.Pressure = info.Pressure;
            temp.Humidity = info.Humidity;
            temp.Temperature = info.Temperature;
            this.infos.Add(temp);
        }

        public string GenerateReport()
        {
            return
                $"Humidity:\nMean: {this.GetMeanHumidity()}%, Minimum: {this.GetMinHumidity()}%, Maximum: {this.GetMaxHumidity()}%\n"
                + $"Pressure:\nMean: {this.GetMeanPressure()}mmHg, Minimum: {this.GetMinPressure()}mmHg, Maximum: {this.GetMaxPressure()}mmHg\n"
                + $"Temperature:\nMean: {this.GetMeanTemperature()}C, Minimum: {this.GetMinTemperature()}C, Maximum: {this.GetMaxTemperature()}C\n";
        }

        public double GetMeanTemperature()
        {
            if (this.infos.Count == 0)
            {
                throw new InvalidOperationException("Not enough data!");
            }

            int sum = 0;
            foreach (var w in this.infos)
            {
                sum += w.Temperature;
            }

            return (double)sum / this.infos.Count;
        }

        public int GetMaxTemperature()
        {
            if (this.infos.Count == 0)
            {
                throw new InvalidOperationException("Not enough data!");
            }

            int max = Int32.MinValue;
            foreach (var w in this.infos)
            {
                if (w.Temperature > max)
                {
                    max = w.Temperature;
                }
            }

            return max;
        }

        public int GetMinTemperature()
        {
            if (this.infos.Count == 0)
            {
                throw new InvalidOperationException("Not enough data!");
            }

            int min = Int32.MaxValue;
            foreach (var w in this.infos)
            {
                if (w.Temperature < min)
                {
                    min = w.Temperature;
                }
            }

            return min;
        }

        public double GetMeanHumidity()
        {
            if (this.infos.Count == 0)
            {
                throw new InvalidOperationException("Not enough data!");
            }

            int sum = 0;
            foreach (var w in this.infos)
            {
                sum += w.Humidity;
            }

            return (double)sum / this.infos.Count;
        }

        public int GetMaxHumidity()
        {
            if (this.infos.Count == 0)
            {
                throw new InvalidOperationException("Not enough data!");
            }

            int max = Int32.MinValue;
            foreach (var w in this.infos)
            {
                if (w.Humidity > max)
                {
                    max = w.Humidity;
                }
            }

            return max;
        }

        public int GetMinHumidity()
        {
            if (this.infos.Count == 0)
            {
                throw new InvalidOperationException("Not enough data!");
            }

            int min = Int32.MaxValue;
            foreach (var w in this.infos)
            {
                if (w.Humidity < min)
                {
                    min = w.Humidity;
                }
            }

            return min;
        }

        public double GetMeanPressure()
        {
            if (this.infos.Count == 0)
            {
                throw new InvalidOperationException("Not enough data!");
            }

            int sum = 0;
            foreach (var w in this.infos)
            {
                sum += w.Pressure;
            }

            return (double)sum / this.infos.Count;
        }

        public int GetMaxPressure()
        {
            if (this.infos.Count == 0)
            {
                throw new InvalidOperationException("Not enough data!");
            }

            int max = Int32.MinValue;
            foreach (var w in this.infos)
            {
                if (w.Pressure > max)
                {
                    max = w.Pressure;
                }
            }

            return max;
        }

        public int GetMinPressure()
        {
            if (this.infos.Count == 0)
            {
                throw new InvalidOperationException("Not enough data!");
            }

            int min = Int32.MaxValue;
            foreach (var w in this.infos)
            {
                if (w.Pressure < min)
                {
                    min = w.Pressure;
                }
            }

            return min;
        }
    }
}
