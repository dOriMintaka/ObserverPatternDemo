using System;

namespace ObserverPatternDemo.Implemantation.Observable
{
    using System.Collections.Generic;

    public class WeatherData : IObservable<WeatherInfo>
    {
        private List<IObserver<WeatherInfo>> observers = new List<IObserver<WeatherInfo>>();

        public void Notify(IObservable<WeatherInfo> sender, WeatherInfo info)
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
    }
}