using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthEnemy : MonoBehaviour , IHealth
{
    [SerializeField] private float damage;
    [SerializeField] private float healthTotal;
    [SerializeField] private LayerMask collisionMask;

    private float healthCurrent;
    private CircleCollider2D circleCollider;
    private Collider2D _collider;
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        circleCollider = GetComponent<CircleCollider2D>();
    }
    private void Start()
    {
        healthCurrent = healthTotal;
    }
    private void Update()
    {
        if (DetectCollision())
        {
            TakeDamage();
        }
    }
    
    private IEnumerator TimeDownDestroy()
    {
        animator.SetTrigger("Explode");
        Physics2D.IgnoreLayerCollision(7, 8);
        yield return new WaitForSeconds(.25f);
        Destroy(gameObject);
    }
    private bool DetectCollision()
    {
        _collider = Physics2D.OverlapCircle(circleCollider.bounds.center, circleCollider.radius, collisionMask);
        if (_collider != null)
        {
            Bullet _bullet = _collider.transform.GetComponent<Bullet>();
            _bullet.SetSpeed(0f);
            _bullet.Explode();
        }
        return _collider != null;
    }

    public void TakeDamage()
    {
        if (healthCurrent > 0)
        {
            healthCurrent -= damage;
            if (healthCurrent <= 0)
            {
                StartCoroutine(TimeDownDestroy());
            }
        }
    }
}
