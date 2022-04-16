using System.Collections.Generic;
using UnityEngine;

namespace Design_patterns.Flyweight
{
    /// <summary>
    /// Class that includes lists with position of body parts.
    /// </summary>
    public class Alien : MonoBehaviour
    {
        public List<Vector3> eyePositions;
        public List<Vector3> legPositions;
        public List<Vector3> armPositions;
    }
}
