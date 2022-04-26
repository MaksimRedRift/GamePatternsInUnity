using UnityEngine.UI;

namespace Design_patterns.State
{
    public abstract class BaseState
    {
        protected Text StatusText;
        protected IStationStateSwitcher StateSwitcher;

        protected BaseState(Text statusText, IStationStateSwitcher stateSwitcher)
        {
            StatusText = statusText;
            StateSwitcher = stateSwitcher;
        }

        public abstract void Start();
        public abstract void Stop();

        public abstract void PutOil();
        
        public abstract void ReturnOil();
        
        public abstract void GetFuel();
    }
}
