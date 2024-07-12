using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Battle : MonoBehaviour
{
    [SerializeField] private BattleText text;

    [SerializeField] private GameObject enemy;

    [SerializeField] private List<GameObject> players;

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
        pn = players.Count;
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
        text.Show(enemy.name + "があらわれた！");
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
            Debug.Log(order[0] + " " + order[1]);
            foreach (int x in order)
            {
                if (x == 0)
                {
                    yield return StartCoroutine(Enemyturn());
                    if (dead >= 0)
                    {
                        text.Show(players[dead].name + "は力尽きてしまった...");
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
                        Debug.Log("end to win");
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
        text.Show(players[n-1].name + "のターン");
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
                text.Show(players[n - 1].name + "のこうげき！");
                yield return new WaitUntil(() => !text._isRunning);
                enset.TakeDamage(plset[n - 1].getATK());
                yield return new WaitForSeconds(1);

                text.Show(enemy.name + "に" + plset[n - 1].getATK() + "のダメージ");
                yield return new WaitUntil(() => !text._isRunning);
                yield return new WaitForSeconds(1);
                break;

            case "やくそう":
                text.Show(players[n-1].name + "はやくそうを使った");
                yield return new WaitUntil(() => !text._isRunning);
                plset[n - 1].Healing(20);
                yield return new WaitForSeconds(1);

                text.Show(players[n - 1].name + "は20回復した");
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
        text.Show(enemy.name + "のこうげき！");
        yield return new WaitUntil(() => !text._isRunning);
        plset[target].TakeDamage(enset.getATK());
        yield return new WaitForSeconds(1);

        text.Show(players[target].name + "に" + enset.getATK() + "のダメージ");
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


    private void Win()
    {
        text.Show(enemy.name + "をたおした！");
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
