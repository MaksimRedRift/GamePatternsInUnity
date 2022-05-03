using Decoupling_Patterns.Service_Locator.Audio_Service_Locator;
using UnityEngine;

namespace Decoupling_Patterns.Service_Locator
{
    /// <summary>
    /// This class used to test that the implementation is working.
    /// </summary>
    public class GameController : MonoBehaviour
    {
        private void Start()
        {
            // Register the service provider in the Locator
            var consoleAudio = new ConsoleAudio();

            Locator.Provide(consoleAudio);
            // Locator.Provide(null);
        }

        private void Update()
        {
            var consoleAudio = Locator.GetAudio();

            if (Input.GetKeyDown(KeyCode.P))
            {
                consoleAudio.PlaySound(23);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                consoleAudio.StopSound(23);
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                consoleAudio.StopAllSounds();
            }
        }
    }
}
