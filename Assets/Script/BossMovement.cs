using System;
using Unity.VisualScripting;
using UnityEngine;

//This script makes the boss go towards the player

public class BossMovement : MonoBehaviour
{
    //Variables
    private float bossSpeed = 1f;
    public Rigidbody2D rb;
    public Transform playerTransform;
    private Vector2 _movementDelta;
    private float _rotation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Resets the rotation
        _rotation = rb.rotation;
    }
    // Update is called once per frame
    void Update()
    {
        //Gets the players position
        var directionToTarget = ((Vector2)playerTransform.position - rb.position).normalized;
        //Gets the rotation to face the player
        _rotation = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg + 90f;
        //Gets the movement delta
        _movementDelta = directionToTarget * bossSpeed;
    }
    private void FixedUpdate()
    {
        //Initialises the boss movement
        rb.MovePosition(rb.position + _movementDelta * Time.fixedDeltaTime);
        //Sets the rotation
        rb.SetRotation(_rotation);

    }
}