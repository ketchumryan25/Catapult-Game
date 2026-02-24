using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AlienFactoryMethod
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Button spawnButton;
        [SerializeField] private EnemySO enemyToSpawn;
        [SerializeField] private Vector2 spawnPositionMin;
        [SerializeField] private Vector2 spawnPositionMax;

        private AlienFactory alienFactory;

        private void Start()
        {
            alienFactory = new AlienFactory();
            spawnButton.onClick.AddListener(SpawnEnemy);
        }

        public void SpawnEnemy()
        {
            Vector2 spawnPosition = new Vector2(Random.Range(spawnPositionMin.x, spawnPositionMax.x), Random.Range(spawnPositionMin.y, spawnPositionMax.y));

            IEnemy iEnemy = alienFactory.GetEnemy(enemyToSpawn);
            string enemyTypeString = iEnemy.EnemyType.ToString();
            iEnemy.SpawnAction(enemyTypeString);

            MonoBehaviour enemy = iEnemy as MonoBehaviour;
            if (enemy != null)
                {
                    enemy.transform.position = spawnPosition;
                }
            else
                {
                    Debug.LogWarning("Failed to cast IEnemy");
                }
        }

        private void GrabEnemyType(string enemyType)
        {
        }
    }
}
