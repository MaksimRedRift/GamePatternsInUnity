using Behavioral_Patterns.Type_Object.Animals.Types;
using UnityEngine;

namespace TypeObject.Animal
{
    public class Fish : Behavioral_Patterns.Type_Object.Animals.Animal
    {
        //This is the Type Object
        private readonly IFlyingType _flyingType;

        public Fish(string name, bool canFly)
        {
            Name = name;

            _flyingType = canFly ? new CanFly() as IFlyingType : new CantFly();
        }

        public override void Talk()
        {
            var canFlyString = _flyingType.CanIFly() ? "can" : "can't";

            Debug.Log($"Hello this is {Name}, I'm a fish, and I {canFlyString} fly!");
        }
    }
}
