using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EnemySettings : MonoBehaviour
{
    [SerializeField] private int maxHP = 100;
    [SerializeField] private GameObject deathVFXPrefab;
    [SerializeField] private EnemyHPController hpcont;

    private int currentHP;
    private Flash flash;

    private void Awake()
    {
        flash = GetComponent<Flash>();
    }

    private void Start()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(int damage)
    {
        currentHP = Math.Max(currentHP - damage, 0);
        hpcont.updateHP();
        StartCoroutine(flash.FlashRoutine());
    }

    public void DetectDeath()
    {
        if (currentHP <= 0)
        {
            Instantiate(deathVFXPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public int getcurrentHP()
    {
        return currentHP;
    }

    public int getmaxHP()
    {
        return maxHP;
    }
}
