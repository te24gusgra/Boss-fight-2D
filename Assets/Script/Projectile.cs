using System;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

//This script gives the different projectiles movement and collision events

public class Projectile : MonoBehaviour
{
    //Variables
    [SerializeField] private float speed;
    [SerializeField] private float lifetime = 3f;
    private int fireBallDamage = 10;
    private int spearDamage = 1; 
    public string owner;

    private float lifeTimer;
    public Rigidbody2D rb;

    private GameObject boss;
    private GameObject player;

    //Gets called when the player shots their weapon and gives the fireball values and movement
    public void ShootBullet(Transform firePoint)
    {
        owner = "Player";
        speed = 5f;
        lifeTimer = 0;
        rb.linearVelocity = Vector2.zero;
        transform.position = firePoint.position;
        transform.rotation = firePoint.rotation;
        gameObject.SetActive(true);

        rb.AddForce(-transform.up * speed, ForceMode2D.Impulse);
    }

    //Gets called when the boss shots their weapon and gives the spear values and movement
    public void BossShootBullet(Transform shootPoint)
    {
        owner = "Boss";
        speed = 10f;
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
        //Gets the different entities 
        boss = GameObject.FindWithTag("Boss");
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //If the projectile exists for too long it gets deleted
        lifeTimer += Time.deltaTime;
        if (lifeTimer >= lifetime)
        {
            Destroy(gameObject);
        }
    }

    //Collision events
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //If the fireball hits the boss the boss takes damage and the fireball gets deleted
        if (owner == "Player" && collision.gameObject.tag == "Boss")
        {
            BossScript bossScript = boss.GetComponent<BossScript>();
            bossScript.Damage(fireBallDamage);
            Destroy(gameObject);
        }
        //If the spear hits the boss the player takes damage and the spear gets deleted
        if (owner == "Boss" && collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            PlayerScript playerScript = player.GetComponent<PlayerScript>();
            playerScript.Damage(spearDamage);

        }
        //If the projectile hits any decorations in the world it gets deleted
        if (collision.gameObject.tag == "World")
        {
            Destroy(gameObject);
        }
    }
}
