using System;
using Design_patterns.Prototype.Monsters;
using UnityEngine;

namespace Design_patterns.Prototype
{
    public class ClientPrototype : MonoBehaviour
    {
        [SerializeField] private Ghost _ghost;
        [SerializeField] private Demon _demon;
        [SerializeField] private EnemySpawner _enemySpawner;

        private Enemy _spawnedEnemy;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                _spawnedEnemy = _enemySpawner.SpawnMonster(_ghost);
                Debug.Log("Spawned ghost");
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                _spawnedEnemy = _enemySpawner.SpawnMonster(_demon);
                Debug.Log("Spawned demon");
            }
        }
    }
}
