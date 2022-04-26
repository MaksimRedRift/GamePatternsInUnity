using UnityEngine;
using UnityEngine.UI;

namespace Design_patterns.State.States
{
    public class HasOilState : BaseState
    {
        public override void Start()
        {
            Debug.Log("Start HasOilState");
        }

        public override void Stop()
        {
            Debug.Log("Stop HasOilState");
        }
        
        public override void PutOil()
        {
            StatusText.text = "Oil tank is full!";
        }

        public override void ReturnOil()
        {
            StatusText.text = "Return to no oil";
        }

        public override void GetFuel()
        {
            StatusText.text = "Get fuel";
        }

        public HasOilState(Text statusText, IStationStateSwitcher stateSwitcher) : base(statusText, stateSwitcher)
        {
        }
    }
}