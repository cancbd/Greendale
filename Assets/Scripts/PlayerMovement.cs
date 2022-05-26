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

    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
        StandingSize = Collider.size;
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

    
}
