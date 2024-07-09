using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int startingHealth = 100; 
    [SerializeField] private GameObject deathVFXPrefab; 

    private int currentHealth; 
    private Knockback knockback; 
    private Flash flash; 

    private void Awake()
    {
        flash = GetComponent<Flash>(); 
        knockback = GetComponent<Knockback>(); 
    }

    private void Start()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth = Math.Max(currentHealth - damage, 0);
        knockback.GetKnockedBack(PlayerControllers.Instance.transform, 5f); 
        StartCoroutine(flash.FlashRoutine()); 
    }

    public void DetectDeath()
    {
        if (currentHealth <= 0)
        {
            Instantiate(deathVFXPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject); 
        }
    }
}
