using System.Collections;
using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    private void Start()
    {
        SceneTransitionExcute();
    }
    public void SceneTransitionExcute()
    {
        StartCoroutine(TimeWaitSceneTransition());
    }
    private IEnumerator TimeWaitSceneTransition()
    {
        yield return new WaitForSeconds(1f);
        transform.GetComponent<Animator>().SetTrigger("SceneTransition");
        GameObject.Find("MenuManager").GetComponent<MenuManager>().Play();
    }
}
