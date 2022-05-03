using UnityEngine;

namespace Decoupling_Patterns.Service_Locator_Another_Implementation.Services
{
    public class FirstService : MonoBehaviour
    {
        private void Awake()
        {
            ServiceLocator.Register(this);
        }

        private void OnDestroy()
        {
            ServiceLocator.Unregister(this);
        }

        public void SayHi() => Debug.Log("Hi, this is the " + nameof(FirstService));
    }
}