using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public static IEnemy enemyType1, enemyType2;
    public static IEnemy enemyRes;
    public enum EnemyType
    {
        EnemyType1,
        EnemyType2
    }
    public static IEnemy CreateEnemy(EnemyType enemyType)
    {
        switch (enemyType)
        {
            case EnemyType.EnemyType1:
                //enemyRes = Instantiate(enemyType1);
                break;
            case EnemyType.EnemyType2:
                //enemyRes = Instantiate(enemyType2);
                break;
            default:

                break;
        }
        return enemyRes;
    }
}
