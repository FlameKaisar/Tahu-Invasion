using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int startHp;
    int hp;
    public float bulletCooldown;
    float bulletTimer;
    // Start is called before the first frame update
    void Start()
    {
        hp = startHp;
    }

    // Update is called once per frame
    void Update()
    {
        bulletTimer -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet") && bulletTimer <= 0) // jika terkena "bullet" dan bullettimernya 0 maka hp player berkurang
        {
            hp -= 1;
            print(hp);
            bulletTimer = bulletCooldown;
        }
    }
}
