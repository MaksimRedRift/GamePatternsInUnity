using Optimization_Patterns.Object_Pool.Optimized;
using UnityEngine;

namespace Optimization_Patterns.Object_Pool
{
    public class GunController : MonoBehaviour
    {
        //public BulletObjectPool bulletPool; //Pick which object pool you want to use
        public BulletObjectPoolOptimized bulletPool;
        
        private const float RotationSpeed = 60f;
        private const float FireInterval = 0.1f;
        private float _fireTimer;

        private void Start()
        {
            _fireTimer = Mathf.Infinity;

            if (bulletPool == null)
            {
                Debug.LogError("Need a reference to the object pool");
            }
        }

        private void Update()
        {
            // Rotate gun
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(Vector3.up, -RotationSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(Vector3.up, RotationSpeed * Time.deltaTime);
            }
            
            // Fire gun
            if (Input.GetKey(KeyCode.Space) && _fireTimer > FireInterval)
            {
                _fireTimer = 0f;

                var newBullet = GetABullet();

                if (newBullet != null)
                {
                    newBullet.SetActive(true);

                    newBullet.transform.forward = transform.forward;
                    //Move the bullet to the tip of the gun or it will look strange if we rotate while firing
                    newBullet.transform.position = transform.position + transform.forward * 2f;
                }
                else
                {
                    Debug.Log("Couldn't find a new bullet");
                }
            }
            //Update the time since we last fired a bullet
            _fireTimer += Time.deltaTime;
        }
        
        private GameObject GetABullet()
        {
            var bullet = bulletPool.GetBullet();
            return bullet;
        }
    }
}
