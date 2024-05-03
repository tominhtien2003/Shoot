using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthPlayer : MonoBehaviour, IHealth
{
    [SerializeField] private float damage;
    [SerializeField] private float healthTotal;
    [SerializeField] private Image healthTotalUI;

    [SerializeField] private int numberOfFlash = 3;
    [SerializeField] private float immortalTime = 2f;

    private float healthCurrent;

    private void Start()
    {
        healthTotalUI.fillAmount = healthTotal / 10f;
        healthCurrent = healthTotal;
    }
    public void TakeDamage()
    {
        if (healthCurrent > 0)
        {
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
    private IEnumerator Immortal()
    {
        yield return new WaitForSeconds(immortalTime);
    }
}
