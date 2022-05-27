using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D rgb;
    Vector3 velocity;

    float speedAmount = 3f;
    float jumpAmount = 8f;

    public bool isFacingRight = true;
    public Animator animator;
    public BoxCollider2D Collider;
    public Vector2 StandingSize;
    public Vector2 CrouchingSize;

    public GameObject Britta;
    public Transform SpawnPoint;
    public GameObject healthbar;
    public Sprite healthFull;
    public Sprite healthMid;
    public Sprite healthLow;

    public int health = 100;


    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
        StandingSize = Collider.size;
        healthbar.gameObject.GetComponent<SpriteRenderer>().sprite = healthFull;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        velocity = new Vector3(Input.GetAxis("Horizontal"), 0f);

        animator.SetFloat("Speed", Mathf.Abs(velocity.x));

        transform.position += velocity * speedAmount * Time.deltaTime;

        if (Input.GetButtonDown("Jump") && Mathf.Approximately(rgb.velocity.y, 0f)) {
            rgb.AddForce(Vector3.up * jumpAmount, ForceMode2D.Impulse);
        }

        if (Input.GetAxisRaw("Horizontal") == -1) {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            isFacingRight = false ;
        }

        else if (Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            isFacingRight = true;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Collider.size = CrouchingSize;
            animator.SetBool("isCrouching", true);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            Collider.size = StandingSize;
            animator.SetBool("isCrouching", false);
        }
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
        Instantiate(Britta, SpawnPoint.position, SpawnPoint.rotation);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
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
