using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

//This script controlls the players hp and damage taken

public class PlayerScript : MonoBehaviour
{
    //Variables
    private int hp = 3;
    private int maxHp = 3;

    [SerializeField] private TMP_Text hpCounter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Displays how much hp the player has left
        hpCounter.text = $"{hp}/{maxHp}";
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
    //The player takes damage and updates how much hp the player has left
    public void Damage(int damage)
    {
        hp -= damage;
        hpCounter.text = $"{hp}/{maxHp}";
    }
}
