using System.Collections.Generic;
using UnityEngine;

namespace Optimization_Patterns.Object_Pool.Optimized
{
    /// <summary>
    /// Has to inherit from MonoBehaviour so we can use Instantiate().
    /// </summary>
    public class BulletObjectPoolOptimized : MonoBehaviour
    {
        //The bullet prefab we instantiate
        public MoveBulletOptimized bulletPrefab;

        //Store the pooled bullets here
        //Instead of GameObject, use MoveBulletOptimized so we dont need a million GetComponent because we need access to that script
        private readonly List<MoveBulletOptimized> _bullets = new List<MoveBulletOptimized>();
        //How many bullets do we start with when the game starts
        private const int InitialPoolSize = 10;
        //Sometimes it can be good to put a limit to how many bullets we can isntantiate or we might get millions of them
        private const int MAXPoolSize = 20;

        //First available bullet, so we don't have to search a list to find it
        //Instead we create a linked-list where all unused bullets are linked together
        private MoveBulletOptimized _firstAvailable;
        
        private void Start()
        {
            if (bulletPrefab == null)
            {
                Debug.LogError("Need a reference to the bullet prefab");
            }
            
            //Instantiate new bullets and put them in a list for later use
            for (var i = 0; i < InitialPoolSize; i++)
            {
                GenerateBullet();
            }
            
            //Create the linked-list
            _firstAvailable = _bullets[0];

            //Each bullet points to the next
            for (var i = 0; i < _bullets.Count - 1; i++)
            {
                _bullets[i].Next = _bullets[i + 1];
            }

            //The last one terminates the linked-list
            _bullets[_bullets.Count - 1].Next = null;
        }


        //Generate a single new bullet and put it in the list
        private void GenerateBullet()
        {
            MoveBulletOptimized newBullet = Instantiate(bulletPrefab, transform);
            newBullet.gameObject.SetActive(false);
            _bullets.Add(newBullet);
            //The bullet needs a reference to this object pool so we can fix the linked list when its deactivated
            newBullet.ObjectPool = this;
        }
        
        //A bullet has been deactivated so we need to add it to the linked list
        public void ConfigureDeactivatedBullet(MoveBulletOptimized deactivatedObj)
        {
            //Add it as the first in the linked list so we don't have to check if the first is null
            deactivatedObj.Next = _firstAvailable;

            _firstAvailable = deactivatedObj;
        }
        
        //Try to get a bullet
        public GameObject GetBullet()
        {
            //Instead of searching a list to find an inactive object, we simply get the firstAvilable object
            if (_firstAvailable == null)
            {
                //We are out of bullets so we have to instantiate another bullet (if we can)
                if (_bullets.Count < MAXPoolSize)
                {
                    GenerateBullet();

                    //The new bullet is last in the list so get it
                    MoveBulletOptimized lastBullet = _bullets[_bullets.Count - 1];

                    //Add it to the linked list by reusing the method we use for deactivated bullets, so it will now be the first bullet in the linked-list
                    ConfigureDeactivatedBullet(lastBullet);
                }
                else
                {
                    return null;
                }
            }

            //Remove it from the linked-list
            MoveBulletOptimized newBullet = _firstAvailable;

            _firstAvailable = newBullet.Next;

            return newBullet.gameObject;
        }
    }
}
