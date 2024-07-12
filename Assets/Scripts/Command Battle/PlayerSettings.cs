using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerSettings : MonoBehaviour
{
    [SerializeField] private GameObject deathVFXPrefab;
    [SerializeField] private PlayerHPController hpcont;

    private int currentHP;
    private int maxHP;
    private int ATK;
    private newFlash flash;
    

    private void Awake()
    {
        flash = GetComponent<newFlash>();
    }

    private void Start()
    {
        ATK = GlobalVariables.ATK;
        currentHP = GlobalVariables.maxHP;
        maxHP = GlobalVariables.maxHP;
    }

    public void TakeDamage(int damage)
    {
        currentHP = Math.Max(currentHP - damage, 0);
        hpcont.updateHP();
        StartCoroutine(flash.FlashRoutine());
    }

    public void Healing(int heal)
    {
        currentHP = Math.Min(currentHP + heal, maxHP);
        hpcont.updateHP();
        StartCoroutine(flash.GFlashRoutine());
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
