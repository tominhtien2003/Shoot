using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScorePlayer : MonoBehaviour
{
    public static int score = 0;
    [SerializeField] private TextMeshProUGUI _text;
    public Slider slider;
    private void Start()
    {
        score = 0;
    }
    public void AddScore()
    {
        ++score;
        _text.text = score.ToString();
        if (slider.value <1f) slider.value += .02f;
        if (slider.value == 1f)
        {
            Player.instance.ChangeBullet();
        }
    }
}
