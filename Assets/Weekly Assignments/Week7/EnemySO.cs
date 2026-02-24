using UnityEngine;

namespace AlienFactoryMethod
{
    [CreateAssetMenu(fileName = "Enemies", menuName = "Enemy SO's")]
    public class EnemySO : ScriptableObject
    {
        public GameObject prefab;
        public EnemyType enemyType;
        public ParticleSystem particleEffect;
    }
}