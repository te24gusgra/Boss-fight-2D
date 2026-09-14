using Unity.VisualScripting;
using UnityEngine;

public class PlayerShootWeapon : MonoBehaviour
{
    [SerializeField] private float cooldown = 5f;
    private float cooldownTimer;

    [SerializeField] private GameObject fireballPrefab;
    [SerializeField] private Transform firepoint;
    [SerializeField] private Animator sparkFlashAnimator;
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
        sparkFlashAnimator.SetTrigger("shoot");

        cooldownTimer = 0;
    }
}
