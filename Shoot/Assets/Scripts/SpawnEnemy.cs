using System.Collections;
using UnityEngine;
using static EnemyFactory;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private Transform left, right;
    [SerializeField] private float timeBetweenSpawnEnemy;

    private EnemyFactory enemyFactory;

    private void Start()
    {
        enemyFactory = GameObject.Find("EnemyFactor").GetComponent<EnemyFactory>();
        InvokeRepeating("SpawnEnemy_", 0f, Random.Range(0.3f, timeBetweenSpawnEnemy));
    }

    private void SpawnEnemy_()
    {
        EnemyType enemyType = GetRandomEnemyType();
        Vector3 pos = new Vector3(Random.Range(left.position.x, left.position.y), transform.position.y, 0f);
        enemyFactory.CreateEnemy(enemyType, pos, transform.rotation);
    }
    private EnemyType GetRandomEnemyType()
    {
        int enumLength = System.Enum.GetValues(typeof(EnemyType)).Length;
        int randomIndex = Random.Range(0, enumLength);
        return (EnemyType)randomIndex;
    }
}
