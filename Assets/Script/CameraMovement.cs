using Unity.VisualScripting;
using UnityEngine;

//This script makes the camera follow the player

public class CameraMovement : MonoBehaviour
{
    //Variables
    public Transform player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Moves the camera to the players position
        transform.position = new Vector3(player.position.x, player.position.y, -10);
    }
}
