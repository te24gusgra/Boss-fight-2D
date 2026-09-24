using System;
using Unity.VisualScripting;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    private float bossSpeed = 0.5f;
    public Rigidbody2D rb;
    public Transform playerTransform;
    private Vector2 _movementDelta;
    private float _rotation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rotation = rb.rotation;
    }
    // Update is called once per frame
    void Update()
    {
        var directionToTarget = ((Vector2)playerTransform.position - rb.position).normalized;
        _rotation = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg + 90f;
        _movementDelta = directionToTarget * bossSpeed;
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + _movementDelta * Time.fixedDeltaTime);
        rb.SetRotation(_rotation);

    }
}