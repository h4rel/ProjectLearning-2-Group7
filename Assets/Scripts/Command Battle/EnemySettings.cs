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
    private string _name;
    [SerializeField] private GameObject deathVFXPrefab;
    [SerializeField] private EnemyHPController hpcont;
    [SerializeField] private TextMeshProUGUI nametmp;

    public struct enemyset
    {
        public string e_name;
        public int hp;
        public int atk;
        public int point;
        public int credit;
    }

    public static enemyset[] eset = new enemyset[13];


    private int currentHP;
    private newFlash flash;

    private void Awake()
    {
        init();

        flash = GetComponent<newFlash>();
    }

    private void Start()
    {
        int e_num = GlobalVariables.id[GlobalVariables.building, GlobalVariables.enter_times[GlobalVariables.building]];
        maxHP = eset[e_num].hp;
        ATK = eset[e_num].atk;
        _name = eset[e_num].e_name;
        currentHP = maxHP;
        nametmp.SetText(_name);
        hpcont.updateHP();
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

    public string getname()
    {
        return _name;
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





    private void init()
    {
        eset[0].e_name = "情報工学概論";
        eset[0].hp = 20;
        eset[0].atk = 5;
        eset[0].point = 3;
        eset[0].credit = 2;

        eset[1].e_name = "情報リテラシ";
        eset[1].hp = 25;
        eset[1].atk = 5;
        eset[1].point = 3;
        eset[1].credit = 2;

        eset[2].e_name = "線形代数I";
        eset[2].hp = 30;
        eset[2].atk = 10;
        eset[2].point = 3;
        eset[2].credit = 2;

        eset[3].e_name = "線形代数II";
        eset[3].hp = 50;
        eset[3].atk = 15;
        eset[3].point = 3;
        eset[3].credit = 2;

        eset[4].e_name = "計算機アーキテクチャ";
        eset[4].hp = 40;
        eset[4].atk = 10;
        eset[4].point = 3;
        eset[4].credit = 2;

        eset[5].e_name = "物理・化学実験";
        eset[5].hp = 60;
        eset[5].atk = 20;
        eset[5].point = 3;
        eset[5].credit = 2;
    
        eset[6].e_name = "アルゴリズムとデータ構造";
        eset[6].hp = 70;
        eset[6].atk = 20;
        eset[6].point = 3;
        eset[6].credit = 2;

        eset[7].e_name = "プログラミング演習I";
        eset[7].hp = 80;
        eset[7].atk = 25;
        eset[7].point = 3;
        eset[7].credit = 2;

        eset[8].e_name = "プログラミング演習II";
        eset[8].hp = 120;
        eset[8].atk = 30;
        eset[8].point = 3;
        eset[8].credit = 2;

        eset[9].e_name = "プロジェクトラーニング";
        eset[9].hp = 115;
        eset[9].atk = 30;
        eset[9].point = 3;
        eset[9].credit = 3;

        eset[10].e_name = "電子情報工学実験";
        eset[10].hp = 150;
        eset[10].atk = 40;
        eset[10].point = 3;
        eset[10].credit = 1;

        eset[11].e_name = "情報工学特別演習";
        eset[11].hp = 150;
        eset[11].atk = 40;
        eset[11].point = 3;
        eset[11].credit = 3;

        eset[12].e_name = "卒業研究";
        eset[12].hp = 200;
        eset[12].atk = 50;
        eset[12].point = 3;
        eset[12].credit = 5;

    }
}
