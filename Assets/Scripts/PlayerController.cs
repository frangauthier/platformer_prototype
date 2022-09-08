using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float maxSpeed;
    [SerializeField] float jumpForce = 7f;
    [SerializeField] Transform groundChecker;
    [SerializeField] LayerMask groundLayer;

    // Firing
    [SerializeField] float fireRate = 0.5f;
    [SerializeField] Transform gunTip;
    [SerializeField] GameObject bullet;

    // Health 
    [SerializeField] float maxHealth = 10f;
    [SerializeField] HealthBar healthBar;
    private float currentHealth;

    Rigidbody2D myRB;
    Animator myAnim;

    float nextFire = 0f;
    bool isGrounded;
    float checkGroundRadius = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currentHealth);
        healthBar.Show();
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfGrounded();
        Move();
        Flip();
        Jump();
        if (Input.GetAxisRaw("Fire1") > 0)
        {
            FireBullet();
        }

    }

    private void Move()
    {
        float moveFactor = Input.GetAxis("Horizontal");

        if (Input.GetAxis("Horizontal") != 0)
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

    private void FireBullet()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            if (transform.localScale.x > 0)
            {
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            else
            {
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 180f)));
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyController ec = collision.gameObject.GetComponent<EnemyController>();
        if (ec != null) TakeDamage(ec.GetHitValue());
    }

    private void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
