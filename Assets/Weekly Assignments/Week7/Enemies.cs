using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AlienFactoryMethod
{
    public class Enemies : MonoBehaviour, IEnemy
    {
        public EnemyType EnemyType { get; private set; }
        private EnemySO enemySO;

        public void Initialize(EnemySO _enemySO)
        {
            enemySO = _enemySO;
            EnemyType = _enemySO.enemyType;
            DoUniqueBehavior();
        }

        public void SpawnAction(string enemyType)
        {
            Debug.Log("Enemy " + enemyType + " has spawned");
        }

        private void DoUniqueBehavior()
        {
            switch (EnemyType)
            {
                case EnemyType.Queen:
                    Debug.Log("Queen: She is releasing spores!");
                    PlayParticleEffect();
                    break;
                case EnemyType.Scout:
                    Debug.Log("Scout: Scaning the area!");
                    PlayParticleEffect();
                    break;
                case EnemyType.War:
                    Debug.Log("War: Opening Fire!");
                    PlayParticleEffect();
                    break;
                default:
                    Debug.Log("Unknown enemy type");
                    break;
            }
        }

        private void PlayParticleEffect()
        {
            if (enemySO.particleEffect != null)
            {
                ParticleSystem ps = Instantiate(enemySO.particleEffect, transform);
                ps.transform.localPosition = Vector3.zero;
                ps.Play();
                Destroy(ps.gameObject, ps.main.duration + ps.main.startLifetime.constant);
            }
            else
            {
                Debug.LogWarning("No particle effect was assigned for " + EnemyType);
            }
        }
    }
}
