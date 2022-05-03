using UnityEngine;

namespace Decoupling_Patterns.Service_Locator.Audio_Service_Locator
{
    /// <summary>
    /// Service provider child class.
    /// </summary>
    public class ConsoleAudio : Audio
    {
        public override void PlaySound(int soundID)
        {
            Debug.Log($"Sound {soundID} has started");
        }

        public override void StopSound(int soundID)
        {
            Debug.Log($"Sound {soundID} has stopped");
        }

        public override void StopAllSounds()
        {
            Debug.Log("All sounds have stopped");
        }
    }
}
