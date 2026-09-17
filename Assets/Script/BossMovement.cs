using Unity.VisualScripting;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public float bossSpeed = 1.75f;
    public Rigidbody2D rb;
    public Transform playerTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }
    private Vector2 _movementDelta;
    // Update is called once per frame
    void Update()
    {
        var directionToTarget = ((Vector2)playerTransform.position - rb.position).normalized;
        _movementDelta = directionToTarget * bossSpeed;
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + _movementDelta * Time.fixedDeltaTime);

    }

    private void BossCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Destroy(coll.gameObject);
        }
    }
}