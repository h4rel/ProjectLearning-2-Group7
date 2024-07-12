using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;
using UnityEditor;

public class EnemySettings : MonoBehaviour
{
    private int maxHP;
    private int ATK;
    [SerializeField] private GameObject deathVFXPrefab;
    [SerializeField] private EnemyHPController hpcont;
    [SerializeField] private TextMeshProUGUI _name;

    public struct enemyset
    {
        public string e_name;
        public int hp;
        public int atk;
    }

    public static enemyset[] eset = new enemyset[50];


    private int currentHP;
    private newFlash flash;

    private void Awake()
    {
        eset[0].e_name = "èÓïÒçHäwäTò_";

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
