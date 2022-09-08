using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float maxHealth = 1f;
    [SerializeField] float enemyDamage = 1f;
    // [SerializeField] HealthBar healthBar;
    // Start is called before the first frame update
    float currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
        //healthBar.SetHealth(currentHealth);
        //healthBar.SetMaxHealth(maxHealth);
    }
    public void ChangeHealth(float changeValue)
    {
        currentHealth += changeValue;

        if (currentHealth <= 0) Destroy(gameObject);
        // healthBar.SetHealth(currentHealth);
    }
    public float GetHitValue()
    {
        return enemyDamage;
    }
}
