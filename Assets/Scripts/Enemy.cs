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
    public GameObject healthbar;
    public Sprite healthFull;
    public Sprite healthMid;
    public Sprite healthLow;


    public int health = 100;
    static int enemyRemaining = 5;

    // Start is called before the first frame update
    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
        healthbar.gameObject.GetComponent<SpriteRenderer>().sprite = healthFull;
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
            Destroy(gameObject);
            Create();
        }
    }

    public void Create()
    {
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
        if(collision.gameObject.tag == "Bullet")
        {
            TakeDamage(34);
            if (health > 66)
            {
                healthbar.gameObject.GetComponent<SpriteRenderer>().sprite = healthFull;
            }
            else if (health > 33)
            {
                healthbar.gameObject.GetComponent<SpriteRenderer>().sprite = healthMid;
            }
            else
            {
                healthbar.gameObject.GetComponent<SpriteRenderer>().sprite = healthLow;
            }
        }
    }
}
