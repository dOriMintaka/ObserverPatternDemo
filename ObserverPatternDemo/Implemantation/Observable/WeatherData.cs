using System;

namespace ObserverPatternDemo.Implemantation.Observable
{
    using System.Collections.Generic;

    public class WeatherData : IObservable<WeatherInfo>
    {
        private readonly WeatherInfo info = new WeatherInfo();

        private List<IObserver<WeatherInfo>> observers = new List<IObserver<WeatherInfo>>();

        public WeatherData()
        {
            this.info = new WeatherInfo();
        }

        void IObservable<WeatherInfo>.Notify(IObservable<WeatherInfo> sender, WeatherInfo info)
        {
            foreach (var o in this.observers)
            {
                o.Update(sender, info);
            }
        }

        public void Register(IObserver<WeatherInfo> observer)
        { 
            this.observers.Add(observer);
        }

        public void Unregister(IObserver<WeatherInfo> observer)
        {
            this.observers.Remove(observer);
        }

        public void GetCurrentWeather(WeatherInfo info)
        {
            this.info.Pressure = info.Pressure;
            this.info.Humidity = info.Humidity;
            this.info.Temperature = info.Temperature;
            ((IObservable<WeatherInfo>)this).Notify(this, this.info);
        }
    }
}