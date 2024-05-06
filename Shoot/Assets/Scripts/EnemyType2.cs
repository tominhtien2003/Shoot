using UnityEngine;

public class EnemyType2 : MonoBehaviour, IEnemy
{
    [SerializeField] private float speed;
    [SerializeField] private LayerMask playerMask;

    private CircleCollider2D circleCollider;
    private void Awake()
    {
        circleCollider = GetComponent<CircleCollider2D>();
    }
    private void Update()
    {
        HandleMovement();
        HandleAttack();
    }
    public void HandleAttack()
    {
        bool checkPlayer = Physics2D.OverlapCircle(circleCollider.bounds.center, circleCollider.radius, playerMask);
        if (checkPlayer)
        {
            Player.instance.GetComponent<HealthPlayer>().TakeDamage();
        }
    }

    public void HandleMovement()
    {
        transform.position += new Vector3(0f, -speed * Time.deltaTime, 0f);
    }
    private void OnDestroy()
    {
        
    }
}
