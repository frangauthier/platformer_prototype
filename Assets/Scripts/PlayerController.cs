using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float maxSpeed;
    [SerializeField] float jumpForce = 7f;
    [SerializeField] Transform groundChecker;
    [SerializeField] LayerMask groundLayer;


    Rigidbody2D myRB;
    Animator myAnim;

    bool isGrounded;
    float checkGroundRadius = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfGrounded();
        Move();
        Flip();
        Jump();
    }

    private void Move()
    {
        float moveFactor = Input.GetAxisRaw("Horizontal");

        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            // Velocity -- good movement, stops on release
            myRB.velocity = new Vector2(moveFactor * maxSpeed, myRB.velocity.y);

        }

        myAnim.SetFloat("speed", Mathf.Abs(myRB.velocity.x));
    }

    private void Flip()
    {
        if (transform.localScale.x * myRB.velocity.x < 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }

    void Jump()
    {
        if (isGrounded && Input.GetAxis("Jump") > 0)
        {
            myRB.velocity = new Vector2(myRB.velocity.x, jumpForce);
            isGrounded = false;
            myAnim.SetBool("isGrounded", isGrounded);
        }
        myAnim.SetFloat("verticalSpeed", myRB.velocity.y);

    }

    void CheckIfGrounded()
    {
        Collider2D collider = Physics2D.OverlapCircle(groundChecker.position, checkGroundRadius, groundLayer);

        if (collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        myAnim.SetBool("isGrounded", isGrounded);
    }

}
