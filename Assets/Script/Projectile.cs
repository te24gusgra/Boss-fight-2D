using System;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float lifetime = 3f;
    public int fireBallDamage = 10;

    private float lifeTimer;
    public Rigidbody2D rb;

    [SerializeField] public GameObject boss;

    public void ShootBullet(Transform shootPoint)
    {
        lifeTimer = 0;
        rb.linearVelocity = Vector2.zero;
        transform.position = shootPoint.position;
        transform.rotation = shootPoint.rotation;
        gameObject.SetActive(true);

        rb.AddForce(-transform.up * speed, ForceMode2D.Impulse);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        lifeTimer += Time.deltaTime;
        if (lifeTimer >= lifetime)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Boss")
        {
            BossScript bossScript = boss.GetComponent<BossScript>();
            bossScript.Damage(fireBallDamage);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "World")
        {
            Destroy(gameObject);
        }
    }
}
