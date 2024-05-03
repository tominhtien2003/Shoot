using UnityEngine;

public class Wall : MonoBehaviour
{
    private BoxCollider2D boxCollider2D;
    [SerializeField] private LayerMask playerMask;
    private void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        if (CheckPlayer())
        {

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
    }
    private bool CheckPlayer()
    {
        return Physics2D.OverlapBox(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, playerMask);
    }
}
