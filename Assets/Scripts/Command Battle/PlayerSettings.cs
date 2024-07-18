using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class PlayerSettings : MonoBehaviour
{
    [SerializeField] private GameObject deathVFXPrefab;
    [SerializeField] private TextMeshProUGUI tmp;
    [SerializeField] private PlayerHPController hpcont;

    private int currentHP;
    private int maxHP;
    private int ATK;
    private string _name;
    private newFlash flash;
    

    private void Awake()
    {
        flash = GetComponent<newFlash>();
    }



    public void init()
    {
        tmp.SetText(_name);
        hpcont.updateHP();
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

    public string getname()
    {
        return _name;
    }

    public void setname(string nm)
    {
        _name = nm;
    }

    public void setHP(int hp)
    {
        maxHP = hp;
        currentHP = hp;
    }

    public void setATK(int atk)
    {
        ATK = atk;
    }
}
