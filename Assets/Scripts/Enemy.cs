using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rgb;
    public float speed = 2f;
    Vector3 velocity;
    public GameObject Enemy1Prefab;
    public Transform SpawnPoint;
    

    public int health = 100;
    int colCount = 0;
    static int enemyRemaining = 5;

    // Start is called before the first frame update
    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rgb.velocity = new Vector2(speed * -1, rgb.velocity.y);
    }
    public void TakeDamage(int damage)
    {
        health -= damage;


        if (health <= 0)
        {
            //obf1.img = cb2.
            Destroy(gameObject);
            Create();
        }
    }

    public void Create()
    {
        ChangeSprite();
        enemyRemaining = enemyRemaining - 1;
        if (enemyRemaining == 0 && SceneManager.GetActiveScene().buildIndex < 4 )
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            enemyRemaining = 5;
        }
        Instantiate(Enemy1Prefab, SpawnPoint.position, SpawnPoint.rotation);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (colCount >= 1)
        {
            TakeDamage(34);
        }
        colCount++;
    }
}
