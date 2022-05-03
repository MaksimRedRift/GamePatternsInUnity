using Decoupling_Patterns.Service_Locator_Another_Implementation.Services;
using UnityEngine;

namespace Decoupling_Patterns.Service_Locator_Another_Implementation
{
    public class GameController : MonoBehaviour
    {
        private void Start()
        {
            var firstService = ServiceLocator.Resolve<FirstService>();
            var secondService = ServiceLocator.Resolve<SecondService>();
            var thirdService = ServiceLocator.Resolve<ThirdService>();

            firstService?.SayHi();
            secondService?.SimpleMethod();
            thirdService?.Foo();
        }
    }
}
