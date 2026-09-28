using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

//This script controls the players movement

public class PlayerMovement : MonoBehaviour
{
    //Variables
    [SerializeField] private float playerSpeed = 1f;
    private Rigidbody2D _rb;
    private Vector2 _movementInput;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //Adds the velocity
        _rb.linearVelocity = _movementInput * playerSpeed * Time.deltaTime;
    }

    private void OnMove(InputValue inputValue)
    {
        _movementInput = inputValue.Get<Vector2>();
    }
}
