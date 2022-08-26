using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testMove : MonoBehaviour
{
    public float thrust;
    Rigidbody2D myRb;

    // Start is called before the first frame update
    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // float move = Input.GetAxis("Horizontal");
        float move = Input.GetAxisRaw("Horizontal");

        //GameObject player = gameObject;
        //player.transform.position = new Vector3(player.transform.position.x + move, player.transform.position.y, player.transform.position.z);

        //myRb.AddForce(new Vector2(move * thrust, 0), ForceMode2D.Impulse);

        myRb.velocity = new Vector2(move * thrust, 0);
    }

    private void FixedUpdate()
    {
        
    }
}
