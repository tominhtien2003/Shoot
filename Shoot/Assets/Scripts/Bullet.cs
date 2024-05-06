using System;
using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float timeLife;
    [SerializeField] private float distanceMax = 5.2f;
    [SerializeField] private LayerMask enemyMask;

    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        HandleMovement();
        StartCoroutine(TimeLife());
        if (transform.position.y >= distanceMax)
        {
            DeActivate();
        }
    }
    private void HandleMovement()
    {
        transform.position += new Vector3(0f, speed * Time.deltaTime, 0f);
    }
    private void DeActivate()
    {
        speed = 10f;
        gameObject.SetActive(false);
    }
    private IEnumerator TimeLife()
    {
        yield return new WaitForSeconds(timeLife);
        DeActivate();
    }
    public void Explode()
    {
        animator.SetTrigger("Explode");
    }
    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
}
