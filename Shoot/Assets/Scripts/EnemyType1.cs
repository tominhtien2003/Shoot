using UnityEngine;

public class EnemyType1 : MonoBehaviour, IEnemy
{
    [SerializeField] private float speed;
    [SerializeField] private LayerMask playerMask;

    private float timeLife = 0f;

    private CircleCollider2D circleCollider;
    private void Awake()
    {
        circleCollider = GetComponent<CircleCollider2D>();
    }
    private void Update()
    {
        timeLife += Time.deltaTime;
        if (timeLife > 7f)
        {
            Destroy(gameObject);
        }
        HandleMovement();
        HandleAttack();
    }
    public void HandleAttack()
    {
        bool checkPlayer = Physics2D.OverlapCircle(circleCollider.bounds.center, circleCollider.radius, playerMask);
        if (checkPlayer)
        {

            Player.instance.GetComponent<IHealth>().TakeDamage();
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
