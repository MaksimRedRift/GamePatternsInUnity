using System.Collections.Generic;
using UnityEngine;

namespace Optimization_Patterns.Object_Pool.Slow
{
    /// <summary>
    /// Has to inherit from MonoBehaviour so we can use Instantiate().
    /// </summary>
    public class BulletObjectPool : MonoBehaviour
    {
        public GameObject bulletPrefab; // The bullet prefab we instantiate
        
        private readonly List<GameObject> _bullets = new List<GameObject>(); // Store the pooled bullets here
        private const int InitialPoolSize = 10; // How many bullets do we start with when the game starts
        private const int MAXPoolSize = 20; // Sometimes it can be good to put a limit to how many bullets we can isntantiate or we might get millions of them
        
        private void Start()
        {
            if (bulletPrefab == null)
            {
                Debug.LogError("Need a reference to the bullet prefab!");
                return;
            }
            
            // Instantiate new bullets and put them in a list for later use
            for (var i = 0; i < InitialPoolSize; i++)
            {
                GenerateBullet();
            }
        }
        
        /// <summary>
        /// Generate a single new bullet and put it in list.
        /// </summary>
        private void GenerateBullet()
        {
            var newBullet = Instantiate(bulletPrefab, transform);
            newBullet.SetActive(false);
            _bullets.Add(newBullet);
        }
        
        /// <summary>
        /// Try to get a bullet.
        /// </summary>
        /// <returns></returns>
        public GameObject GetBullet()
        {
            // Try to find an inactive bullet
            for (var i = 0; i < _bullets.Count; i++)
            {
                var thisBullet = _bullets[i];

                if (!thisBullet.activeInHierarchy)
                {                
                    return thisBullet;
                }
            }

            // We are out of bullets so we have to instantiate another bullet (if we can)
            if (_bullets.Count >= MAXPoolSize) return null;
            GenerateBullet();

            //The new bullet is last in the list so get it
            var lastBullet = _bullets[_bullets.Count - 1];

            return lastBullet;
        }
    }
}
