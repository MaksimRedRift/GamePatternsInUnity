using UnityEngine;
using UnityEngine.UI;

namespace Design_patterns.State.States
{
    public class FuelProductionState : BaseState
    {
        public override void Start()
        {
            Debug.Log("Start FuelProductionState");
        }

        public override void Stop()
        {
            Debug.Log("Stop FuelProductionState");
        }
        
        public override void PutOil()
        {
            StatusText.text = "Fuel in progress";
        }

        public override void ReturnOil()
        {
            StatusText.text = "Not oil to return";
        }

        public override void GetFuel()
        {
            StatusText.text = "Fuel in progress. Wait";
        }

        public FuelProductionState(Text statusText, IStationStateSwitcher stateSwitcher) : base(statusText, stateSwitcher)
        {
        }
    }
}