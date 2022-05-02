using UnityEngine;

namespace Behavioral_Patterns.Subclass_Sandbox
{
    /// <summary>
    /// Implementation of the Subclass Sandbox pattern from the book Game Programming Patterns.
    /// </summary>
    public class GameController : MonoBehaviour
    {
        private SkyLaunch _skyLaunch;
        
        private void Start()
        {
            _skyLaunch = new SkyLaunch();
        }
        
        private void Update()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                _skyLaunch.Activate();
            }
        }
    }
}
