using System.Collections.Generic;
using UnityEngine;

namespace Design_patterns.Flyweight
{
    /// <summary>
    /// Flyweight design pattern main class.
    /// </summary>
    public class Flyweight : MonoBehaviour
    {
        // The list that stores all aliens
        private List<Alien> _allAliens = new List<Alien>();
        
        private List<Vector3> _eyePositions;
        private List<Vector3> _legPositions;
        private List<Vector3> _armPositions;

        private void Start()
        {
            _eyePositions = GetBodyPartPositions();
            _legPositions = GetBodyPartPositions();
            _armPositions = GetBodyPartPositions();
            
            // Create all aliens
            for (var i = 0; i < 10000; i++)
            {
                var newAlien = new Alien();

                // Add eyes and leg positions
                // Without flyweight
                /*
                newAlien.eyePositions = GetBodyPartPositions();
                newAlien.armPositions = GetBodyPartPositions();
                newAlien.legPositions = GetBodyPartPositions();
                */
                
                //With flyweight
                newAlien.eyePositions = _eyePositions;
                newAlien.armPositions = _legPositions;
                newAlien.legPositions = _armPositions;

                _allAliens.Add(newAlien);
            }
        }
        
        
        // Generate a list with body part positions
        private static List<Vector3> GetBodyPartPositions()
        {
            // Create a new list
            var bodyPartPositions = new List<Vector3>();

            // Add body part positions to the list
            for (var i = 0; i < 1000; i++)
            {
                bodyPartPositions.Add(new Vector3());
            }

            return bodyPartPositions;
        }
    }
}
