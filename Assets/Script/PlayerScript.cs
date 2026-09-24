using System.Threading;
using UnityEngine;

//This script controlls the players hp and damage taken

public class PlayerScript : MonoBehaviour
{
    //Variables
    public int hp = 3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //If the player dies it disappears
        if (hp <= 0)
        {
            gameObject.SetActive(false);
        }
    }
    //The player takes damage
    public void Damage(int damage)
    {
        hp -= damage;
    }
}
