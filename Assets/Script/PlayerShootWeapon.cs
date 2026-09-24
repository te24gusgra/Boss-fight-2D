using Unity.VisualScripting;
using UnityEngine;

//This script is used so the player is able to shoot and it having a cooldown

public class PlayerShootWeapon : MonoBehaviour
{
    //Variables
    [SerializeField] private float cooldown;
    private float cooldownTimer;

    [SerializeField] private GameObject fireballPrefab;
    [SerializeField] private Transform firepoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Makes the cooldown acually work by updating the time every frame
        cooldownTimer += Time.deltaTime;

        //When the player presses the mouse button it tries to shoot
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }


    private void Shoot()
    {
        //Checks if the cooldown is over and if not it doesnt do anything
        if (cooldownTimer < cooldown) return;

        //Creates and spawns in a fireball and gives it some values
        GameObject fireball = Instantiate(fireballPrefab, firepoint.position, firepoint.rotation,null);
        fireball.GetComponent<Projectile>().ShootBullet(firepoint);

        //Resets the cooldown
        cooldown = 1f;
        cooldownTimer = 0;
    }
}
