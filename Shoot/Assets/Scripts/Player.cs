using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance {  get; private set; }

    [SerializeField] private float speed;
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform pointHoldBullet;

    private Rigidbody2D rb;
    private string tagBullet = "Bullet"; 
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            /*DontDestroyOnLoad(gameObject);*/
        }
        else
        {
            //Destroy(gameObject);
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
        GameManager.instance.objectPooler.SpawnObject(tagBullet, pointHoldBullet.position, pointHoldBullet.rotation);
    }
    private void HandleMovement()
    {
        float inputHor = Input.GetAxisRaw("Horizontal");
        float inputVer = Input.GetAxisRaw("Vertical");
        //Debug.Log(inputHor + " " + inputVer);
        rb.MovePosition(rb.position + new Vector2(inputHor, inputVer) * speed * Time.fixedDeltaTime);

    }
    public void ChangeBullet()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartCoroutine(TimeChangeBullet());
        }
    }
    private IEnumerator TimeChangeBullet()
    {
        transform.GetComponent<ScorePlayer>().slider.value = 0f;
        tagBullet = "Bullet1";
        yield return new WaitForSeconds(20f);
        tagBullet = "Bullet";
    }
}
