using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 2f;
    [SerializeField] float weaponDamage = 1f;

    [SerializeField] AudioClip explosionAudioClip;
    [SerializeField] GameObject explosionEffect;

    Rigidbody2D rb2d;
    AudioSource playerAudioSource;

    // Start is called before the first frame update
    void Start()
    {
    }
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();

        if (transform.localRotation.z == 0)
        {
            rb2d.AddForce(new Vector2(1 * bulletSpeed, 0), ForceMode2D.Impulse);
        }
        else
        {
            rb2d.AddForce(new Vector2(-1 * bulletSpeed, 0), ForceMode2D.Impulse);
        }
        Destroy(gameObject, 5);
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Shootable") || collision.gameObject.tag == "Shootable")
        {
            Instantiate(explosionEffect, transform.position, collision.transform.rotation);
            rb2d.velocity *= 0.01f;
            gameObject.GetComponent<AudioSource>().PlayOneShot(explosionAudioClip);
            Destroy(gameObject, 0.2f);

            EnemyController enemyController = collision.gameObject.GetComponent<EnemyController>();
            if(enemyController)
            {
                enemyController.ChangeHealth(-weaponDamage);
            }
        }
    }

}
