using System;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float lifetime = 3f;
    public int fireBallDamage = 10;
    public int spearDamage = 1; 
    public string owner;

    private float lifeTimer;
    public Rigidbody2D rb;

    private GameObject boss;
    private GameObject player;


    public void ShootBullet(Transform firePoint)
    {
        owner = "Player";
        lifeTimer = 0;
        rb.linearVelocity = Vector2.zero;
        transform.position = firePoint.position;
        transform.rotation = firePoint.rotation;
        gameObject.SetActive(true);

        rb.AddForce(-transform.up * speed, ForceMode2D.Impulse);
    }

    public void BossShootBullet(Transform shootPoint)
    {
        owner = "Boss";
        lifeTimer = 0;
        rb.linearVelocity = Vector2.zero;
        transform.position = shootPoint.position;
        transform.rotation = shootPoint.rotation;
        gameObject.SetActive(true);

        rb.AddForce(transform.up * speed, ForceMode2D.Impulse);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boss = GameObject.FindWithTag("Boss");
        player = GameObject.FindWithTag("Player");
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
        if (owner == "Player" && collision.gameObject.tag == "Boss")
        {
            BossScript bossScript = boss.GetComponent<BossScript>();
            bossScript.Damage(fireBallDamage);
            Destroy(gameObject);
        }
        if (owner == "Boss" && collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            PlayerScript playerScript = player.GetComponent<PlayerScript>();
            playerScript.Damage(spearDamage);

        }
        if (collision.gameObject.tag == "World")
        {
            Destroy(gameObject);
        }
    }
}
