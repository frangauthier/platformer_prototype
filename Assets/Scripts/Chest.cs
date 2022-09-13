using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    Animator chestAnim;
    bool isOpen = false;

    [SerializeField] GameObject coin;
    [SerializeField] GameObject heart;
    [SerializeField] Transform chest;

    // Start is called before the first frame update
    void Start()
    {
        chestAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InstantiateDrops()
    {

        int coinQuantity = Random.Range(0, 5);
        int heartQuantity = Random.Range(0, 3);

        for (int i = 0; i < coinQuantity; i++)
        {
            Instantiate(coin, chest.position, Quaternion.identity);
        }
        
        for (int i = 0; i < heartQuantity; i++)
        {
            Instantiate(heart, chest.position, Quaternion.identity);
        }
        

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        
            if (collision.gameObject.tag == "Player" && Input.GetKeyDown("f"))
            {
            // Set open bool variable to true
            isOpen = true;

            // Change animator boolean variable to the open state
            chestAnim.SetBool("isOpenned", isOpen);

            InstantiateDrops();
            }
        
    }
}
