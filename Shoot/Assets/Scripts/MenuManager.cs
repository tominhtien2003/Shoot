using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Main");
    }
    public void Quit()
    {
        Debug.Log("Quit button was pressed!");
        Application.Quit();
    }
}
