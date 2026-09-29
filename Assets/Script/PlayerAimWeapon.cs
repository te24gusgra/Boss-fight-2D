using System;
using UnityEngine;
using UnityEngine.InputSystem;

//This script makes the player aim towards the mouse

public class PlayerAimWeapon : MonoBehaviour
{
    //Takes the angle and puts it into a variable to then later use it to change the players rotation to look towards the mouse
    protected void LookAt(Vector3 target)
    {
        float lookAngle = AngleBetweenTwoPoints(transform.position, target) - 90;

        transform.eulerAngles = new Vector3 (0, 0, lookAngle);
    }

    //Gets the angle between the mouse and the players position
    private float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    //Gets the mouse position
    private void OnLook(InputValue inputValue)
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(inputValue.Get<Vector2>());
        LookAt(mousePosition);
    }

}
