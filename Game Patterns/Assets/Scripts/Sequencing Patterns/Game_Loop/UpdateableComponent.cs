using UnityEngine;

namespace Sequencing_Patterns.Game_Loop
{
    /// <summary>
    /// Base class for objects with a custom Update method.
    /// </summary>
    public class UpdateableComponent : MonoBehaviour, IUpdateable
    {
        /// <summary>
        /// Unity's method which is working fine because the class inherits from MonoBehaviour.
        /// </summary>
        private void Start()
        {
            //Register the object 
            GameController.RegisterUpdateableObject(this);
            OnStart();
        }

        /// <summary>
        /// This is a custom Start method which the child can override, because we can't use Unity's Start in both parent and child.
        /// </summary>
        protected virtual void OnStart() {}
        
        /// <summary>
        /// Custom update method, which the child can override.
        /// </summary>
        /// <param name="dt">Delta time.</param>
        public virtual void OnUpdate(float dt) {}      
        
        private void OnDestroy()
        {
            //Unegister the object
            //Remember that it's dangerous to call another method in OnDestroy() because the other method might already be destroyed
            GameController.UnregisterUpdateableObject(this);
        }
    }
}
