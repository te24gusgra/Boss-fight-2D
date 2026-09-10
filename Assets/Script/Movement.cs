using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float playerSpeed = 125f;
    public Rigidbody2D rb;
    private Vector2 input;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
   
    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        input.Normalize();

        if (Input.GetKeyDown("left shift"))
        {
            playerSpeed = 200f;
        }

    }

    private void FixedUpdate()
    {
        rb.linearVelocity = input * playerSpeed * Time.deltaTime;
    }
}
