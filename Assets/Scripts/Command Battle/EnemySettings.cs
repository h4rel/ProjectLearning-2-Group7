using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class EnemySettings : MonoBehaviour
{
    [SerializeField] private int maxHP = 100;
    [SerializeField] private int ATK = 10;
    [SerializeField] private GameObject deathVFXPrefab;
    [SerializeField] private EnemyHPController hpcont;
    [SerializeField] private TextMeshProUGUI _name;

    private int currentHP;
    private newFlash flash;

    private void Awake()
    {
        flash = GetComponent<newFlash>();
    }

    private void Start()
    {
        currentHP = maxHP;
        _name.SetText(this.name);
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

    public int getATK()
    {
        return ATK;
    }
}
