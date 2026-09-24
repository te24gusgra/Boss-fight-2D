using System;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float lifetime = 3f;
    public int fireBallDamage = 10;
    public string owner;

    private float lifeTimer;
    public Rigidbody2D rb;

    [HideInInspector] [SerializeField] private GameObject boss;


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

        rb.AddForce(-transform.up * speed, ForceMode2D.Impulse);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Jag är ett nytt spjut och jag har stora drömmar i livet!");
        Debug.Log(transform.position);
        boss = GameObject.FindWithTag("Boss");
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
