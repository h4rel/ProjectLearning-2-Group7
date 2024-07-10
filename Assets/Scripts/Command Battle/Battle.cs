using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Battle : MonoBehaviour
{
    [SerializeField] private BattleText text;

    [SerializeField] private GameObject enemy;

    [SerializeField] private List<GameObject> players;

    private int pn;

    private List<PlayerSettings> plset;

    private EnemySettings enset;

    private System.Random rand;

    private bool can_next;

    // Start is called before the first frame update
    void Start()
    {
        enset = enemy.GetComponent<EnemySettings>();
        rand = new System.Random(); //Time?
        pn = players.Count;
        first();
        Enemyturn();
    }

    private void first()
    {
        text.Show(enemy.name + "があらわれた！");
    }

    private void TurnDecider()
    {
        return;
    }

    private void Enemyturn()
    {
        int target = rand.Next(0, pn);
        text.Show(enemy.name + "のこうげき！");
        Debug.Log(enset.getATK());
    }

    void Update()
    {

    }
}