using UnityEngine;

namespace Design_patterns.Prototype
{
    public class EnemySpawner : MonoBehaviour
    {
        private ICopyable _copy;

        public Enemy SpawnMonster(Enemy prototype)
        {
            _copy = prototype.Copy();
            return (Enemy)_copy;
        }
    }
}
