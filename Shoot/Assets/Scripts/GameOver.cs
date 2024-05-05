using UnityEngine;

public class GameOver : MonoBehaviour
{
    public void GameOver_()
    {
        GameManager.instance.PlayAgain();
    }
}
