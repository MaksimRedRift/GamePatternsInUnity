using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Design_patterns.State
{
    public class Enemy
    {
        protected Transform EnemyObj;
        
        //The different states the enemy can be in
        protected enum EnemyFSM
        {
            Attack,
            Flee,
            Stroll,
            MoveTowardsPlayer
        }
        
        //Update the enemy by giving it a new state
        public virtual void UpdateEnemy(Transform playerObj)
        {

        }
        
        //Do something based on a state
        protected void DoAction(Transform playerObj, EnemyFSM enemyMode)
        {
            const float fleeSpeed = 10f;
            const float strollSpeed = 1f;
            const float attackSpeed = 5f;

            switch (enemyMode)
            {
                case EnemyFSM.Attack:
                    //Attack player
                    break;
                case EnemyFSM.Flee:
                    //Move away from player
                    //Look in the opposite direction
                    EnemyObj.rotation = Quaternion.LookRotation(EnemyObj.position - playerObj.position);
                    //Move
                    EnemyObj.Translate(EnemyObj.forward * fleeSpeed * Time.deltaTime);
                    break;
                case EnemyFSM.Stroll:
                    //Look at a random position
                    Vector3 randomPos = new Vector3(Random.Range(0f, 100f), 0f, Random.Range(0f, 100f));
                    EnemyObj.rotation = Quaternion.LookRotation(EnemyObj.position - randomPos);
                    //Move
                    EnemyObj.Translate(EnemyObj.forward * strollSpeed * Time.deltaTime);
                    break;
                case EnemyFSM.MoveTowardsPlayer:
                    //Look at the player
                    EnemyObj.rotation = Quaternion.LookRotation(playerObj.position - EnemyObj.position);
                    //Move
                    EnemyObj.Translate(EnemyObj.forward * attackSpeed * Time.deltaTime);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(enemyMode), enemyMode, null);
            }
        }
    }
}

