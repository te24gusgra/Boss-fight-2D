using System;
using Unity.VisualScripting;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    [SerializeField]
    public int hp = 500;
    public int bossDamage = 1;

    [SerializeField] 
    public GameObject player;

    [SerializeField] 
    public PlayerScript playerScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerScript = player.GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            Debug.Log("Boss: Nu dog jag");
            Destroy(gameObject);
        }
    }

    public void Damage(int damage)
    {
        hp -= damage;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //playerScript.Damage(bossDamage);
        }
    }
}
