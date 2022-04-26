using System;
using System.Collections.Generic;
using System.Linq;
using Design_patterns.State.States;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

namespace Design_patterns.State
{
    public class StationBehaviour : MonoBehaviour, IStationStateSwitcher
    {
        [SerializeField] private Text _statusText;
        [SerializeField] private Button _putOil, _returnOil, _getFuel;

        private BaseState _currentState;
        private List<BaseState> _allStates;

        private void Start()
        {
            _allStates = new List<BaseState>
            {
                new NotOilState(_statusText, this),
                new HasOilState(_statusText, this),
                new FuelProductionState(_statusText, this)
            };
            _currentState = _allStates[0];
            
            _putOil.onClick.AddListener(PutOil);
            _returnOil.onClick.AddListener(ReturnOil);
            _getFuel.onClick.AddListener(GetFuel);
        }

        private void PutOil()
        {
            _currentState.PutOil();
            SwitchState<HasOilState>();
        }
        
        private void ReturnOil()
        {
            _currentState.ReturnOil();
            SwitchState<FuelProductionState>();
        }

        private void GetFuel()
        {
            _currentState.GetFuel();
            SwitchState<NotOilState>();
        }

        public void SwitchState<T>() where T : BaseState
        {
            var state = _allStates.FirstOrDefault(s => s is T);
            _currentState.Stop();
            state?.Start();
            _currentState = state;
        }
    }
}
