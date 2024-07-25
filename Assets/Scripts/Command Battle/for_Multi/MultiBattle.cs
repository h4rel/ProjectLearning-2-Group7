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
using Photon.Pun;
using Photon.Realtime;
using System.Linq.Expressions;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;

public class MultiBattle : MonoBehaviourPunCallbacks
{
    [SerializeField] private BattleText text;
    [SerializeField] private TextMeshProUGUI waitmsg;

    [SerializeField] private GameObject enemy;

    [SerializeField] private List<GameObject> players;

    [SerializeField] private List<GameObject> pl_panel;

    [SerializeField] private GameObject p_text;
    [SerializeField] private GameObject p_command;
    [SerializeField] private GameObject p_item;
    [SerializeField] private GameObject p_waiting;
    [SerializeField] private GameObject p_entry;
    [SerializeField] private GameObject p_oneentry;
    [SerializeField] private GameObject p_enemy;

    [SerializeField] private string result;
    [SerializeField] private string retry;

    [SerializeField] private GameObject th;

    [SerializeField] private Sprite[] monsters;

    public static bool _decided = false;

    public static string _action = "";

    private int damage;

    private int target;

    private int pn;

    private int alive;

    private int dead;

    private List<int> now_dead = new List<int> { };

    private List<int> dead_list = new List<int> { };

    private int end = 0;

    private List<PlayerSettings> plset;

    private int[] order;

    private EnemySettings enset;

    private Image enimg;

    private System.Random rand;

    private int trg;

    private int turn = 0;

    private static float[] multiatk = new float[] { 1, 1.25f, 1.5f, 1.75f };

    private static float[] multihp = new float[] { 1, 1.5f, 2.0f, 2.5f };




    ExitGames.Client.Photon.Hashtable roomHash;



    public override void OnRoomPropertiesUpdate(ExitGames.Client.Photon.Hashtable propertiesThatChanged)
    {
        object value = null;
        if (propertiesThatChanged.TryGetValue("a", out value))
        {
            _action = (string)value;
        }
        if (propertiesThatChanged.TryGetValue("d", out value))
        {
            damage = (int)value;
        }
        if (propertiesThatChanged.TryGetValue("t", out value))
        {
            target = (int)value;
        }
        roomHash["a"] = _action;
        roomHash["d"] = damage;
        roomHash["t"] = target;

        _decided = true;

    }



    void Start()
    {
        if (GlobalVariables.NOP == 1)
        {
            p_oneentry.SetActive(true);
            p_entry.SetActive(false);
        }
        else
        {
            p_entry.SetActive(true);
            p_oneentry.SetActive(false);
        }
        p_command.SetActive(false);
        p_item.SetActive(false);
        p_waiting.SetActive(false);
        p_enemy.SetActive(false);
        pl_panel[0].SetActive(false);
        pl_panel[1].SetActive(false);
        pl_panel[2].SetActive(false);
        pl_panel[3].SetActive(false);

    }


    public void after_connected()
    {
        Debug.Log("start battle");
        roomHash = new ExitGames.Client.Photon.Hashtable();
        roomHash.Add("a", _action);
        roomHash.Add("d", damage);
        roomHash.Add("t", target);
        if (PhotonNetwork.LocalPlayer.IsMasterClient)
        {
            Debug.Log("master");
            PhotonNetwork.CurrentRoom.SetCustomProperties(roomHash);
        }

        pn = GlobalVariables.NOP;
        alive = pn;
        turn = 0;



        plset = new List<PlayerSettings>();
        for (int i = 0; i < pn; i++)
        {
            plset.Add(players[i].GetComponent<PlayerSettings>());
        }


        foreach (Player pl in PhotonNetwork.PlayerList)
        {
            int id = (int)pl.CustomProperties["pn"];
            plset[id - 1].setname((string)pl.CustomProperties["n"]);
            plset[id - 1].setHP((int)pl.CustomProperties["h"]);
            plset[id - 1].setATK((int)pl.CustomProperties["a"]);
            plset[id - 1].init();
            if (id == 1)
            {
                PhotonNetwork.SetMasterClient(pl);
            }
        }

        p_entry.SetActive(false);
        p_oneentry.SetActive(false);

        for (int i = 0; i < pn; i++)
        {
            pl_panel[i].SetActive(true);
        }

        p_enemy.SetActive(true);

        enimg = enemy.GetComponent<Image>();
        if (enimg != null)
        {
            enimg.sprite = monsters[GlobalVariables.id[GlobalVariables.building, GlobalVariables.enter_times[GlobalVariables.building]]%10];
        }

        enset = enemy.GetComponent<EnemySettings>();
        Debug.Log(pn);
        rand = new System.Random((int)Time.time); //Time
        order = new int[pn + 1];
        plset = new List<PlayerSettings>();
        trg = 0;
        for (int i = 0; i < pn; i++)
        {
            plset.Add(players[i].GetComponent<PlayerSettings>());
        }
        for (int i = 0; i < pn + 1; i++)
        {
            order[i] = (i + 1) % (pn + 1);
        }
        StartCoroutine(first());
    }

    private IEnumerator first()
    {
        yield return null;
        enset.setHP((int)(enset.getmaxHP() * multihp[pn - 1]));
        enset.setATK((int)(enset.getATK() * multiatk[pn - 1]));
        enset.TakeDamage(0);

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
            // OrderDecider();
            turn++;
            foreach (int x in order)
            {
                if (x == 0)
                {
                    now_dead.Clear();
                    yield return StartCoroutine(Enemyturn());
                    if (dead > 0)
                    {
                        string ss = "";
                        if (dead == 1)
                        {
                            ss = plset[now_dead[0]].getname();
                        }
                        else
                        {
                            for (int i = 0; i < dead; i++)
                            {
                                if (i == 0)
                                {
                                    ss = ss + plset[now_dead[i]].getname();
                                }
                                else
                                {
                                    ss = ss + "と" + plset[now_dead[i]].getname();
                                }
                            }
                        }
                        text.Show(ss + "は力尽きてしまった...");
                        yield return new WaitUntil(() => !text._isRunning);
                        yield return new WaitForSeconds(1);
                        alive -= dead;
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
        // order = order.OrderBy(x => rand.Next()).ToArray();
        for (int i = 0; i < pn; i++)
        {
            order[i] = (i + 1) % pn;
        }
        return;
    }

    private IEnumerator Playerturn(int n)
    {
        text.Show(plset[n - 1].getname() + "のターン");
        yield return new WaitUntil(() => !text._isRunning);
        yield return new WaitForSeconds(1);
        _decided = false;
        if (n == GlobalVariables.mynum)
        {
            p_text.SetActive(false);
            p_command.SetActive(true);
            Debug.Log("before");
            yield return new WaitUntil(() => _decided);
            Debug.Log("better");
            roomHash["a"] = _action;
            PhotonNetwork.CurrentRoom.SetCustomProperties(roomHash);
            Debug.Log("good");

        }
        else
        {
            waitmsg.SetText(plset[n - 1].getname() + "が行動を選択中...");
            p_waiting.SetActive(true);
            yield return new WaitUntil(() => _decided);
            for (int i = 0; i < 10; i++)
            {
                yield return null;
            }
        }
        p_command.SetActive(false);
        p_item.SetActive(false);
        p_waiting.SetActive(false);
        p_text.SetActive(true);

        switch (_action)
        {
            case "こうげき":
                text.Show(plset[n - 1].getname() + "のこうげき！");
                yield return new WaitUntil(() => !text._isRunning);
                _decided = false;
                if (PhotonNetwork.LocalPlayer.IsMasterClient)
                {
                    damage = ATK_to_damage(plset[n - 1].getATK());
                    roomHash["d"] = damage;
                    yield return new WaitForSeconds(1);
                    PhotonNetwork.CurrentRoom.SetCustomProperties(roomHash);
                }
                else
                {
                    yield return new WaitUntil(() => _decided);
                }
                enset.TakeDamage(damage);
                yield return new WaitForSeconds(1);

                text.Show(enset.getname() + "に" + damage + "のダメージ");
                yield return new WaitUntil(() => !text._isRunning);
                yield return new WaitForSeconds(1);
                break;

            case "エナジードリンク":
                text.Show(plset[n - 1].getname() + "はエナジードリンクを使った");
                yield return new WaitUntil(() => !text._isRunning);
                plset[n - 1].Healing(plset[n-1].getmaxHP()/2);
                yield return new WaitForSeconds(1);

                text.Show(plset[n - 1].getname() + "は" + plset[n - 1].getmaxHP() / 2 + "回復した");
                yield return new WaitUntil(() => !text._isRunning);
                yield return new WaitForSeconds(1);
                break;
        }

    }

    private IEnumerator Enemyturn()
    {
        trg = (trg + 1) % 3;
        if (trg == 0 && pn > 1)
        {
            text.Show(enset.getname() + "のこうげき！");
            yield return new WaitUntil(() => !text._isRunning);
            _decided = false;
            if (PhotonNetwork.LocalPlayer.IsMasterClient)
            {
                damage = ATK_to_damage((int)(enset.getATK() * 0.7));
                roomHash["d"] = damage;
                yield return new WaitForSeconds(1);
                PhotonNetwork.CurrentRoom.SetCustomProperties(roomHash);
            }
            else
            {
                yield return new WaitUntil(() => _decided);
            }
            foreach (var pl in plset)
            {
                pl.TakeDamage(damage);
            }
            yield return new WaitForSeconds(1);
            text.Show("全員に" + damage + "のダメージ");
            yield return new WaitUntil(() => !text._isRunning);
            yield return new WaitForSeconds(1);
        }
        else
        {
            target = rand.Next(0, pn);
            while (plset[target].getcurrentHP() <= 0)
            {
                target = rand.Next(0, pn);
            }
            text.Show(enset.getname() + "のこうげき！");
            yield return new WaitUntil(() => !text._isRunning);
            _decided = false;
            if (PhotonNetwork.LocalPlayer.IsMasterClient)
            {
                damage = ATK_to_damage(enset.getATK());
                roomHash["d"] = damage;
                roomHash["t"] = target;
                yield return new WaitForSeconds(1);
                PhotonNetwork.CurrentRoom.SetCustomProperties(roomHash);
            }
            else
            {
                yield return new WaitUntil(() => _decided);
            }
            plset[target].TakeDamage(damage);
            yield return new WaitForSeconds(1);

            text.Show(plset[target].getname() + "に" + damage + "のダメージ");
            yield return new WaitUntil(() => !text._isRunning);
            yield return new WaitForSeconds(1);
        }

        for (int i = 0; i < pn; i++)
        {
            if (plset[i].getcurrentHP() <= 0 && (!dead_list.Contains(i)))
            {
                now_dead.Add(i);
                dead_list.Add(i);
            }
        }
        dead = now_dead.Count;
    }

    private int ATK_to_damage(int atk)
    {
        float x = (float)rand.Next(80, 121) / 100f;
        return (int)(atk * x);

    }


    private void Win()
    {
        if (turn == 1) GlobalVariables.battleresult = 4;
        else if (turn == 2) GlobalVariables.battleresult = 3;
        else if (turn == 3) GlobalVariables.battleresult = 2;
        else GlobalVariables.battleresult = 1;
        text.Show(enset.getname() + "をたおした！");
        Invoke("nextScene", 4f);

    }


    private void Lose()
    {
        text.Show("単位を取ることが出来なかった");
        GlobalVariables.life--;
        Invoke("nextScene", 4f);
    }

    private void nextScene()
    {
        PhotonNetwork.LeaveRoom();
        if (end > 0)
        {
            if (GlobalVariables.NOP == 1)
            {
                SceneManager.LoadScene(result);
            }
            else
            {
                PhotonNetwork.LoadLevel(result);
            }

        }
        else
        {
            if (GlobalVariables.NOP == 1 && GlobalVariables.life > 0)
            {
                SceneManager.LoadScene("RetryScene");
            }
            else
            {
                SceneManager.LoadScene("FailureScene");
            }

        }
    }

}
