using System.Collections.Generic;

namespace Design_patterns.Observer
{
    //Invokes the notificaton method
    public class Subject
    {
        //A list with observers that are waiting for something to happen
        private readonly List<Observer> _observers = new List<Observer>();

        //Send notifications if something has happened
        public void Notify()
        {
            foreach (var observer in _observers)
            {
                //Notify all observers even though some may not be interested in what has happened
                //Each observer should check if it is interested in this event
                observer.OnNotify();
            }
        }

        //Add observer to the list
        public void AddObserver(Observer observer) => _observers.Add(observer);
        
        //Remove observer from the list
        public void RemoveObserver(Observer observer) => _observers.Remove(observer);
    }
}