using System;
using Unity.VisualScripting;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public int hp = 30;
    public int damage = 1;

    [SerializeField] public GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player.GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
            Console.WriteLine("Boss: Nu dog jag");
        }
    }

    public void Damage(int damage)
    {
        Console.WriteLine("Aj");
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Console.WriteLine(collision.gameObject.tag);
    //    if (collision.gameObject.tag == "Fireball")
    //    {
    //        Console.WriteLine("Aj");
    //    }
    //}
}
