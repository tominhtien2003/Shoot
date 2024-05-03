using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance {  get; private set; }

    [SerializeField] private float speed;
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform pointHoldBullet;

    private Rigidbody2D rb;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        InvokeRepeating("HandleAttack", 0f, attackCooldown);
    }
    private void FixedUpdate()
    {
        HandleMovement();
    }
    private void HandleAttack()
    {
        GameManager.instance.objectPooler.SpawnObject("Bullet", pointHoldBullet.position, pointHoldBullet.rotation);
    }
    private void HandleMovement()
    {
        float inputHor = Input.GetAxisRaw("Horizontal");
        float inputVer = Input.GetAxisRaw("Vertical");
        //Debug.Log(inputHor + " " + inputVer);
        if (inputHor != 0f)
        {
            rb.velocity = new Vector2(inputHor * speed, rb.velocity.y);
        }
        if (inputVer != 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, inputVer * speed);
        }
        if (inputHor == 0f && inputVer == 0f)
        {
            rb.velocity = Vector2.zero;
        }

    }
}