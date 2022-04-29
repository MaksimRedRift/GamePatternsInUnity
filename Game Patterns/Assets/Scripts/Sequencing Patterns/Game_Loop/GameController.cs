using System.Collections.Generic;
using UnityEngine;

namespace Sequencing_Patterns.Game_Loop
{
    //Example of custom update method to illustrate the update method pattern in the book "Game Programming Patterns"
    //This idea is based on code from the book "Unity 2017 Game Optimization"
    //This class will run all our custom update methods in Unity's own Update method, which will make it easier to pause the game
    public class GameController : MonoBehaviour
    {
        //The list with all objects with a custom update method
        //Is static to make it easier to illustrate the example, but you could maybe use the Observer pattern to register methods
        private static readonly List<IUpdateable> UpdateableObjects = new List<IUpdateable>();
        private bool _isPaused;
        
        //This should be the game's only MonoBehaviour Update method
        private void Update()
        {
            //Run all custom update methods
            if (!_isPaused && UpdateableObjects != null)
            {
                var dt = Time.deltaTime;

                //Iterate through all objects backwards in case one object decides to destroy itself
                for (int i = UpdateableObjects.Count - 1; i >= 0; i--)
                {
                    IUpdateable updateableObj = UpdateableObjects[i];

                    updateableObj.OnUpdate(dt);
                }
            }

            //Pause-unpause
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _isPaused = !_isPaused;
            }
        }
        
        //Register new object
        public static void RegisterUpdateableObject(IUpdateable obj)
        {
            if (!UpdateableObjects.Contains(obj))
            {
                UpdateableObjects.Add(obj);
            }
            else
            {
                var mb = (MonoBehaviour)obj;

                Debug.Log($"{mb.gameObject.name} has already been registered");
            }
        }

        //Unregister
        public static void UnregisterUpdateableObject(IUpdateable obj)
        {
            if (UpdateableObjects.Contains(obj))
            {
                UpdateableObjects.Remove(obj);
            }
        }
    }
}
