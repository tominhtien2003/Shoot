using TMPro;
using UnityEngine;

public class ScorePlayer : MonoBehaviour
{
    public static int score = 0;
    [SerializeField] private TextMeshProUGUI _text;
    private void Start()
    {
        score = 0;
    }
    private void Update()
    {
        _text.text = score.ToString();
    }
}
