using UnityEngine;

namespace Sequencing_Patterns.Game_Loop
{
    /// <summary>
    /// Attach to all object that should have a custom Update (and Start) method. (The parent class will handle the registration of the OnUpdate method).
    /// </summary>
    public class ObjectWithCustomUpdateMethod : UpdateableComponent
    {
        private const float Speed = 10f;
        private const float MapRadius = 10f;

        //Custom start, which will be called from the parent which uses Unity's Start() method
        protected override void OnStart()
        {
            Debug.Log($"[{name}]Custom Start is working");
            //Generate a random direction
            transform.rotation = GetRandomDirection();
        }
        
        public override void OnUpdate(float dt)
        {
            //Move forward
            var newPos = transform.position + transform.forward * Speed * dt;

            //Are we outside of the circle?
            if ((newPos - Vector3.zero).sqrMagnitude > MapRadius * MapRadius)
            {
                //If so we cant move and have to change directon
                transform.rotation = GetRandomDirection();
            }
            //Move to the new postion
            else
            {
                transform.position = newPos;
            }
        }

        //Generate a quaternion with a random rotation around y axis
        private static Quaternion GetRandomDirection()
        {
            var randomDir = Quaternion.Euler(new Vector3(0f, Random.Range(0f, 360f), 0f));
            return randomDir;
        }
    }
}
