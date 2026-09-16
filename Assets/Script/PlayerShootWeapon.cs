using Unity.VisualScripting;
using UnityEngine;

public class PlayerShootWeapon : MonoBehaviour
{
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
        cooldownTimer += Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (cooldownTimer < cooldown) return;

        GameObject fireball = Instantiate(fireballPrefab, firepoint.position, firepoint.rotation,null);
        fireball.GetComponent<Projectile>().ShootBullet(firepoint);

        cooldown = 1f;
        cooldownTimer = 0;
    }
}
