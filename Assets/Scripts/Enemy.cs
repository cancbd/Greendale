using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rgb;
    public float speed = 2f;
    Vector3 velocity;
    public GameObject Enemy1Prefab;
    public Transform SpawnPoint;

    public int health = 100;
    int colCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += velocity * speedAmount;
        rgb.velocity = new Vector2(speed * -1, rgb.velocity.y);


    }
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            
            Destroy(gameObject);
            Create();
        }
    }

    public void Create()
    {
        Instantiate(Enemy1Prefab, SpawnPoint.position, SpawnPoint.rotation);
    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (colCount >= 1)
        {
            TakeDamage(100);
        }
        colCount++;
    }
}
