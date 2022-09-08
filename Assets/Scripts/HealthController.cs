using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] float addHealth = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float GetAddHealth()
    {
        Destroy(gameObject);
        return addHealth;
    }
}
