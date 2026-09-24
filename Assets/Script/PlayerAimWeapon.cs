using System;
using UnityEngine;

//This script makes the player aim and look towards the mouse

public class PlayerAimWeapon : MonoBehaviour
{
    //Variables
    [SerializeField] private Transform aimTransform;
    [SerializeField] private Transform playerTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Gets the posisition and direction of the mouse and player
        Vector3 mousePosition = GetMouseWorldPosition(); 
        Vector3 aimDirection = (mousePosition - aimTransform.position).normalized;
        Vector3 playerPosition = GetMouseWorldPosition();
        Vector3 playerDirection = (mousePosition - aimTransform.position).normalized;

        //Gets the angle of the direction of the mouse to use
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;

        //
        aimTransform.eulerAngles = new Vector3(0, 0, angle + 90);
        playerTransform.eulerAngles = new Vector3(0, 0, angle + 90);
    }

    private Vector3 GetMouseWorldPosition()
    {
        //
        Vector3 mouseScreenPosition = Input.mousePosition;
        mouseScreenPosition.z = 10f;
        return Camera.main.ScreenToWorldPoint(mouseScreenPosition);
    }
}
