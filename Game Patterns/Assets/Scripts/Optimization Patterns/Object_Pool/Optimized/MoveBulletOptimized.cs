using UnityEngine;

namespace Optimization_Patterns.Object_Pool.Optimized
{
    public class MoveBulletOptimized : MonoBehaviour
    {
        [SerializeField] private float _bulletSpeed = 10f;
        [SerializeField] private float _deactivationDistance = 30f;

        // Needed to optimize object pooling
        [System.NonSerialized] public MoveBulletOptimized Next;
        // Instead of using this dependency you could use the Observer pattern because other things may happen when the bullet dies
        [System.NonSerialized] public BulletObjectPoolOptimized ObjectPool;

        private void Update()
        {        
            transform.Translate(Vector3.forward * _bulletSpeed * Time.deltaTime);

            //Deactivate the bullet when it's far away
            if (Vector3.SqrMagnitude(transform.position) > _deactivationDistance * _deactivationDistance)
            {
                //In the optimized version, we have to tell the object pool that this bullet has been deactivated
                ObjectPool.ConfigureDeactivatedBullet(this);

                gameObject.SetActive(false);
            }
        }
    }
}
