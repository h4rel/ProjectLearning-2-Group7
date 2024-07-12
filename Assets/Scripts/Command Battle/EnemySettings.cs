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






    private void init()
    {
        eset[0].e_name = "���H�w�T�_";
        eset[0].hp = 20;
        eset[0].atk = 5;
        eset[1].e_name = "��񃊃e���V";
        eset[1].hp = 30;
        eset[1].atk = 10;
        eset[2].e_name = "���`�㐔I";
        eset[2].hp = 50;
        eset[2].atk = 15;
        eset[3].e_name = "���`�㐔II";
        eset[3].hp = 30;
        eset[3].atk = 10;
        eset[4].e_name = "�v�Z�@�A�[�L�e�N�`��";
        eset[4].hp = 30;
        eset[4].atk = 10;
        eset[5].e_name = "�����E���w����";
        eset[5].hp = 30;
        eset[5].atk = 10;
        eset[6].e_name = "�A���S���Y���ƃf�[�^�\��";
        eset[6].hp = 30;
        eset[6].atk = 10;
        eset[7].e_name = "�v���O���~���O���K�T";
        eset[7].hp = 30;
        eset[7].atk = 10;
        eset[8].e_name = "�v���O���~���O���K�U";
        eset[8].hp = 30;
        eset[8].atk = 10;
        eset[9].e_name = "�v���W�F�N�g���[�j���O";
        eset[9].hp = 30;
        eset[9].atk = 10;
        eset[10].e_name = "�d�q���H�w����";
        eset[10].hp = 30;
        eset[10].atk = 10;
        eset[11].e_name = "���H�w���ʉ��K";
        eset[11].hp = 30;
        eset[11].atk = 10;
        eset[12].e_name = "���ƌ���";
        eset[12].hp = 30;
        eset[12].atk = 10;
    }
}
