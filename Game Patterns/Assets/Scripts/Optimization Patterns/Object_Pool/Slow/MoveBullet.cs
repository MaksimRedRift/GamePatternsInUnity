using UnityEngine;

namespace Optimization_Patterns.Object_Pool.Slow
{
    public class MoveBullet : MonoBehaviour
    {
        [SerializeField] private float _bulletSpeed = 10f;
        [SerializeField] private float _deactivationDistance = 30f;

        private void Update()
        {        
            transform.Translate(Vector3.forward * _bulletSpeed * Time.deltaTime);

            //Deactivate the bullet when it's far away
            if (Vector3.SqrMagnitude(transform.position) > _deactivationDistance * _deactivationDistance)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
