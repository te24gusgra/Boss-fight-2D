using UnityEngine;

public class BossShootWeapon : MonoBehaviour
{
    [SerializeField] private float cooldown;
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
        cooldownTimer += Time.deltaTime;

        Shoot();

    }

    private void Shoot()
    {
        if (cooldownTimer < cooldown) return;
        Debug.Log("Här ska jag skjuta");
        cooldown = 10f;
        cooldownTimer = 0;

        GameObject spear = Instantiate(spearPrefab, shootPoint.position, shootPoint.rotation, null);
        spear.GetComponent<Projectile>().BossShootBullet(shootPoint);
    }
}
