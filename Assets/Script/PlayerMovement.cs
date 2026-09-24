using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

//This script controls the players movement

public class PlayerMovement : MonoBehaviour
{
    //Variables
    private float playerSpeed = 125f;
    public Rigidbody2D rb;
    private Vector2 input;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Gets the players rigidbody
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
   
    void Update()
    {
        //Detects the inputs
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        //Makes so you dont go faster by moving diagonal
        input.Normalize();
    }

    private void FixedUpdate()
    {
        //Adds the velocity
        rb.linearVelocity = input * playerSpeed * Time.deltaTime;
    }
}
