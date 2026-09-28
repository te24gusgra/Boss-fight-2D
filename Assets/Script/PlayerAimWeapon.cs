using System;
using UnityEngine;
using UnityEngine.InputSystem;

//This script makes the player aim and look towards the mouse

public class PlayerAimWeapon : MonoBehaviour
{
    protected void LookAt(Vector3 target)
    {
        float lookAngle = AngleBetweenTwoPoints(transform.position, target) - 90;

        transform.eulerAngles = new Vector3 (0, 0, lookAngle);
    }

    private float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    private void OnLook(InputValue inputValue)
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(inputValue.Get<Vector2>());
        LookAt(mousePosition);
    }

}
