using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

//This script controlls the boss hp, damage taken and collision with the player

public class BossScript : MonoBehaviour
{
    //Variables
    private int hp = 500;
    private int maxHp = 500;
    private int bossDamage = 1;

    [SerializeField] private TMP_Text hpCounter;

    [SerializeField] public GameObject player;
    [SerializeField] public PlayerScript playerScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Gets the players script
        playerScript = player.GetComponent<PlayerScript>();

        //Shows how much hp the boss has left
        hpCounter.text = $"{hp}/{maxHp}";
    }

    // Update is called once per frame
    void Update()
    {
        //If the boss dies it gets destroyed
        if (hp <= 0)
        {
            Debug.Log("Boss: Nu dog jag");
            Destroy(gameObject);
        }
    }

    //The boss takes damage and updates the text so you can see how much hp the boss has left
    public void Damage(int damage)
    {
        hp -= damage;
        hpCounter.text = $"{hp}/{maxHp}";
    }

    //When the player collides with the boss the players takes damage
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerScript.Damage(bossDamage);
        }
    }
}
