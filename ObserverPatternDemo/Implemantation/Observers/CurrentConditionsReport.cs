using ObserverPatternDemo.Implemantation.Observable;

namespace ObserverPatternDemo.Implemantation.Observers
{
    using System;

    public class CurrentConditionsReport : ObserverPatternDemo.IObserver<WeatherInfo>
    {
        private WeatherInfo currentInfo = new WeatherInfo() { Humidity = 0, Pressure = 0, Temperature = 0 };

        public void Update(ObserverPatternDemo.IObservable<WeatherInfo> sender, WeatherInfo info)
        {
            this.currentInfo.Humidity = info.Humidity;
            this.currentInfo.Pressure = info.Pressure;
            this.currentInfo.Temperature = info.Temperature;
            Console.WriteLine(this.GetCurrentCondition());
        }

        public string GetCurrentCondition()
        {
            return
                $"Current state:\nHumidity: {this.currentInfo.Humidity}%\nPressure: {this.currentInfo.Pressure}mmHg\nTemperature: {this.currentInfo.Temperature}C\n";
        }
    }
}