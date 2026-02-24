using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AlienFactoryMethod
{
    public class AlienFactory : IEnemyFactory
    {
        public IEnemy GetEnemy(EnemySO enemySO)
        {
            GameObject newEnemy = GameObject.Instantiate(enemySO.prefab);

            if (newEnemy.TryGetComponent(out IEnemy iEnemy))
            {
                iEnemy.Initialize(enemySO);
                return iEnemy;
            }
            else
            {
                return null;   
            }
        }
    }
}
