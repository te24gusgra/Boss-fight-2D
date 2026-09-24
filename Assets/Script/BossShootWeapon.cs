using UnityEngine;

//This script is used so the boss is able to shoot and it having a cooldown

public class BossShootWeapon : MonoBehaviour
{
    //Variables
    [SerializeField] private float cooldown = 10f;
    private float cooldownTimer;
    [SerializeField] private GameObject spearPrefab;
    [SerializeField] private Transform shootPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Makes the cooldown acually work by updating the time every frame
        cooldownTimer += Time.deltaTime;

        //It tries to shoot every frame
        Shoot();

    }

    private void Shoot()
    {
        //Checks if the cooldown is over and if not it doesnt do anything
        if (cooldownTimer < cooldown) return;

        //Resets the cooldown
        cooldownTimer = 0;

        //Creates and spawns in a spear and gives it some values
        GameObject spear = Instantiate(spearPrefab, shootPoint.position, shootPoint.rotation, null);
        spear.GetComponent<Projectile>().BossShootBullet(shootPoint);
    }
}
