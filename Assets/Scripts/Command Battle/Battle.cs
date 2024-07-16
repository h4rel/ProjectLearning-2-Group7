using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using JetBrains.Annotations;

public class Battle : MonoBehaviour
{
    [SerializeField] private BattleText text;

    [SerializeField] private GameObject enemy;

    [SerializeField] private List<GameObject> players;

    [SerializeField] private List<GameObject> pl_panel;

    [SerializeField] private GameObject p_text;
    [SerializeField] private GameObject p_command;
    [SerializeField] private GameObject p_item;

    [SerializeField] private string result;
    [SerializeField] private string retry;

    public static bool _decided = false;

    public static string _action = "";

    private int pn;

    private int alive;

    private int dead;

    private int end = 0;

    private List<PlayerSettings> plset;

    private int[] order;

    private EnemySettings enset;

    private System.Random rand;

    // Start is called before the first frame update
    void Start()
    {
        p_command.SetActive(false);
        p_item.SetActive(false);



        enset = enemy.GetComponent<EnemySettings>();
        rand = new System.Random(); //Time?
        pn = GlobalVariables.NOP;
        for (int i = 3; i > pn-1; i--)
        {
            pl_panel[i].SetActive(false);
        }
        alive = pn;
        order = new int[pn+1];
        plset = new List<PlayerSettings>();
        for (int i = 0; i < pn; i++)
        {
            plset.Add(players[i].GetComponent<PlayerSettings>());
        }
        for (int i = 0; i < pn+1; i++)
        {
            order[i] = i;
        }
        StartCoroutine(first());
    }

    private IEnumerator first()
    {
        yield return new WaitForSeconds(1);
        text.Show(enset.getname() + "があらわれた！");
        yield return new WaitUntil(() => !text._isRunning);
        yield return new WaitForSeconds(1);
        yield return StartCoroutine(Fight());
        if (end > 0) Win();
        else Lose();
    }

    private IEnumerator Fight()
    {
        while (end == 0)
        {
            OrderDecider();
            foreach (int x in order)
            {
                if (x == 0)
                {
                    yield return StartCoroutine(Enemyturn());
                    if (dead >= 0)
                    {
                        text.Show(plset[dead].getname() + "は力尽きてしまった...");
                        yield return new WaitUntil(() => !text._isRunning);
                        yield return new WaitForSeconds(1);
                        alive--;
                    }
                    if (alive <= 0)
                    {
                        end = -1;
                        break;
                    }

                }
                else
                {
                    if (plset[x - 1].getcurrentHP() > 0)
                    {
                        yield return StartCoroutine(Playerturn(x));
                    }

                    if (enset.getcurrentHP() <= 0)
                    {
                        end = 1;
                        break;
                    }
                }
            }
        }
    }

    private void OrderDecider()
    {
        order = order.OrderBy(x => rand.Next()).ToArray();
        return;
    }

    private IEnumerator Playerturn(int n)
    {
        text.Show(plset[n-1].getname() + "のターン");
        yield return new WaitUntil(() => !text._isRunning);
        yield return new WaitForSeconds(1);
        p_text.SetActive(false);
        _decided = false;
        p_command.SetActive(true);
        yield return new WaitUntil(() => _decided);
        p_command.SetActive(false);
        p_item.SetActive(false);
        p_text.SetActive(true);

        switch (_action)
        {
            case "こうげき":
                text.Show(plset[n-1].getname() + "のこうげき！");
                yield return new WaitUntil(() => !text._isRunning);
                int dmg = ATK_to_damage(plset[n - 1].getATK());
                enset.TakeDamage(dmg);
                yield return new WaitForSeconds(1);

                text.Show(enset.getname() + "に" + dmg + "のダメージ");
                yield return new WaitUntil(() => !text._isRunning);
                yield return new WaitForSeconds(1);
                break;

            case "やくそう":
                text.Show(plset[n-1].getname() + "はやくそうを使った");
                yield return new WaitUntil(() => !text._isRunning);
                plset[n - 1].Healing(20);
                yield return new WaitForSeconds(1);

                text.Show(plset[n-1].getname() + "は20回復した");
                yield return new WaitUntil(() => !text._isRunning);
                yield return new WaitForSeconds(1);
                break;
        }
        
    }

    private IEnumerator Enemyturn()
    {
        int target = rand.Next(0, pn);
        while (plset[target].getcurrentHP() <= 0)
        {
            target = rand.Next(0, pn);
        }
        text.Show(enset.getname() + "のこうげき！");
        yield return new WaitUntil(() => !text._isRunning);
        int dmg = ATK_to_damage(enset.getATK());
        plset[target].TakeDamage(dmg);
        yield return new WaitForSeconds(1);

        text.Show(plset[target].getname() + "に" + dmg + "のダメージ");
        yield return new WaitUntil(() => !text._isRunning);
        yield return new WaitForSeconds(1);
        if (plset[target].getcurrentHP() <= 0)
        {
            dead = target;
        }
        else
        {
            dead = -1;
        }
    }

    private int ATK_to_damage(int atk)
    {
        float x = (float)rand.Next(80, 121)/100f;
        return (int)(atk * x);
        
    }


    private void Win()
    {
        text.Show(enset.getname() + "をたおした！");
        GlobalVariables.enter_times[GlobalVariables.building]++;
        Invoke("nextScene",4f);
        
    }


    private void Lose()
    {
        text.Show("単位を取ることが出来なかった");
        Invoke("nextScene", 4f);
    }

    private void nextScene()
    {
        if (end > 0) SceneManager.LoadScene(result);
        else SceneManager.LoadScene(retry);
    }

}
