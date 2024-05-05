using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthPlayer : MonoBehaviour, IHealth
{
    [SerializeField] private float damage;
    [SerializeField] private float healthTotal;
    [SerializeField] private Image healthTotalUI;

    [SerializeField] private int numberOfFlash = 3;
    [SerializeField] private float immortalDuration = 2f;

    private float healthCurrent;
    private bool isImmortal;
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        healthTotalUI.fillAmount = healthTotal / 10f;
        healthCurrent = healthTotal;
    }
    public void TakeDamage()
    {
        if (isImmortal)
        {
            return;
        }
        if (healthCurrent > 0)
        {
            StartCoroutine(TimeImmortal());
            healthCurrent -= damage;
            healthTotalUI.fillAmount = healthCurrent / 10f;
        }
        else
        {

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            TakeDamage();
        }
    }
    private IEnumerator TimeImmortal()
    {
        isImmortal = true;
        Physics2D.IgnoreLayerCollision(6, 7, true);// Bo qua va cham
        for (int i = 0; i < numberOfFlash; i++)
        {
            spriteRenderer.color = new Color(0, .5f, 0, .5f);
            yield return new WaitForSeconds(immortalDuration / (numberOfFlash * 2));
            spriteRenderer.color = new Color(1, 1, 1, .5f);
            yield return new WaitForSeconds(immortalDuration / (numberOfFlash * 2));
        }
        spriteRenderer.color = Color.white;
        Physics2D.IgnoreLayerCollision(6, 7, false);
        isImmortal = false;
    }
}
