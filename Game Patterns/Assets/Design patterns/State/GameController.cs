using System.Collections.Generic;
using UnityEngine;

namespace Design_patterns.State
{
    public class GameController : MonoBehaviour
    {
        public GameObject playerObj;
        public GameObject creeperObj;
        public GameObject skeletonObj;

        //A list that will hold all enemies
        List<Enemy> enemies = new List<Enemy>();

        private void Start()
        {
            //Add the enemies we have
            enemies.Add(new Creeper(creeperObj.transform));
            enemies.Add(new Skeleton(skeletonObj.transform));
        }


        private void Update()
        {
            //Update all enemies to see if they should change state and move/attack player
            for (var i = 0; i < enemies.Count; i++)
            {
                enemies[i].UpdateEnemy(playerObj.transform);
            }
        }
    }
}
