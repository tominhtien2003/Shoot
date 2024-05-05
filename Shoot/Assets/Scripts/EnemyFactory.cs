using System;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] private Transform enemyType1Pref, enemyType2Pref;
    private Transform enemyRes;
    public enum EnemyType
    {
        EnemyType1,
        EnemyType2
    }
    public Transform CreateEnemy(EnemyType enemyType, Vector3 pos ,Quaternion rotation)
    {
        switch (enemyType)
        {
            case EnemyType.EnemyType1:
                enemyRes = Instantiate(enemyType1Pref , pos , rotation);
                break;
            case EnemyType.EnemyType2:
                enemyRes = Instantiate(enemyType2Pref , pos , rotation);
                break;
            default:
                enemyRes = null;
                break;
        }
        return enemyRes;
    }
}
