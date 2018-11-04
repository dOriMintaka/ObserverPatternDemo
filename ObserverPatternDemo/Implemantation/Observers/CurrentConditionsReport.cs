using ObserverPatternDemo.Implemantation.Observable;

namespace ObserverPatternDemo.Implemantation.Observers
{
    public class CurrentConditionsReport : IObserver<WeatherInfo>
    {
        private WeatherInfo currentInfo = new WeatherInfo() { Humidity = 0, Pressure = 0, Temperature = 0 };
        public void Update(IObservable<WeatherInfo> sender, WeatherInfo info)
        {
            this.currentInfo.Humidity = info.Humidity;
            this.currentInfo.Pressure = info.Pressure;
            this.currentInfo.Temperature = info.Temperature;
        }

        public string GetCurrentCondition()
        {
            return
                $"Current state:\nHumidity: {this.currentInfo.Humidity}\nPressure: {this.currentInfo.Pressure}\nTemperature: {this.currentInfo.Temperature}";
        }
    }
}