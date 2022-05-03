using Behavioral_Patterns.Type_Object.Animals;
using UnityEngine;

namespace Behavioral_Patterns.Type_Object
{
    /// <summary>
    /// Main class to illustrate the Type object pattern.
    /// </summary>
    public class TypeObjectController : MonoBehaviour
    {
        private void Start()
        {
            var ostrich = new Bird("ostrich", false);
            var pigeon = new Bird("pigeon", true);
            var rat = new Mammal("rat", false);
            var bat = new Mammal("bat", true);
            var flyingFish = new Fish("Flying fish", true);

            ostrich.Talk();
            pigeon.Talk();
            rat.Talk();
            bat.Talk();
            flyingFish.Talk();
        }
    }
}
