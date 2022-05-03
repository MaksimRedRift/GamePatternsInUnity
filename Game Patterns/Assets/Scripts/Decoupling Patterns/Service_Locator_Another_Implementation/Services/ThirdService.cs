using UnityEngine;

namespace Decoupling_Patterns.Service_Locator_Another_Implementation.Services
{
    public class ThirdService : MonoBehaviour
    {
        private void Awake()
        {
            ServiceLocator.Register(this);
        }

        private void OnDestroy()
        {
            ServiceLocator.Unregister(this);
        }

        public void Foo()
        {
            Debug.Log("This is Foo method from " + nameof(ThirdService));
        }
    }
}