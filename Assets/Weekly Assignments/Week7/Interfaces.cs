using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AlienFactoryMethod
{
    public interface IEnemyFactory
    {
        IEnemy GetEnemy(EnemySO enemySO);
    }

    public interface IEnemy
    {
        EnemyType EnemyType { get; }
        void Initialize(EnemySO _enemySO);
        void SpawnAction(string EnemyType);
    }
}
