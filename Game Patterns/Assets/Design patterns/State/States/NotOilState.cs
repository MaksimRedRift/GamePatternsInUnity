using UnityEngine;
using UnityEngine.UI;

namespace Design_patterns.State.States
{
    public class NotOilState : BaseState
    {
        public override void Start()
        {
            Debug.Log("Start NotOilState");
        }

        public override void Stop()
        {
            Debug.Log("Stop NotOilState");
        }

        public override void PutOil()
        {
            StatusText.text = "Successfully inserted oil";
        }

        public override void ReturnOil()
        {
            StatusText.text = "Not oil to return";
        }

        public override void GetFuel()
        {
            StatusText.text = "Not oil to create full";
        }

        public NotOilState(Text statusText, IStationStateSwitcher stateSwitcher) : base(statusText, stateSwitcher)
        {
        }
    }
}