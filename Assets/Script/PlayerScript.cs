using System.Threading;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public int hp = 3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
            Thread.Sleep(1000);
        }
    }
    public void Damage(int damage)
    {
        hp -= damage;
    }
}
