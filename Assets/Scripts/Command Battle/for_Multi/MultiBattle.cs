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

    [SerializeField] private string result;
    [SerializeField] private string retry;

    public static bool _decided = false;

    public static string _action = "";

    private int damage;

    private int target;

    private int pn;

    private int alive;

    private int dead;

    private int end = 0;

    private List<PlayerSettings> plset;

    private int[] order;

    private EnemySettings enset;

    private System.Random rand;




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
        if (propertiesThatChanged.TryGetValue("d", out value))
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
        p_command.SetActive(false);
        p_item.SetActive(false);
        p_waiting.SetActive(false);
    }


    public void after_connected()
    {
        roomHash = new ExitGames.Client.Photon.Hashtable();
        roomHash.Add("a", _action);
        roomHash.Add("d", damage);
        roomHash.Add("t", target);
        if (PhotonNetwork.LocalPlayer.IsMasterClient)
        {
            Debug.Log("master");
            PhotonNetwork.CurrentRoom.SetCustomProperties(roomHash);
        }

        enset = enemy.GetComponent<EnemySettings>();
        rand = new System.Random(); //Time
        pn = GlobalVariables.NOP;
        for (int i = 3; i > pn - 1; i--)
        {
            pl_panel[i].SetActive(false);
        }
        alive = pn;
        order = new int[pn + 1];
        plset = new List<PlayerSettings>();
        for (int i = 0; i < pn; i++)
        {
            plset.Add(players[i].GetComponent<PlayerSettings>());
        }
        for (int i = 0; i < pn + 1; i++)
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
            yield return new WaitForSeconds(1);
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
                    damage = ATK_to_damage(plset[n-1].getATK());
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

            case "やくそう":
                text.Show(plset[n - 1].getname() + "はやくそうを使った");
                yield return new WaitUntil(() => !text._isRunning);
                plset[n - 1].Healing(20);
                yield return new WaitForSeconds(1);

                text.Show(plset[n - 1].getname() + "は20回復した");
                yield return new WaitUntil(() => !text._isRunning);
                yield return new WaitForSeconds(1);
                break;
        }

    }

    private IEnumerator Enemyturn()
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
            yield return new WaitUntil(()=> _decided);
        }
        plset[target].TakeDamage(damage);
        yield return new WaitForSeconds(1);

        text.Show(plset[target].getname() + "に" + damage + "のダメージ");
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
        float x = (float)rand.Next(80, 121) / 100f;
        return (int)(atk * x);

    }


    private void Win()
    {
        text.Show(enset.getname() + "をたおした！");
        GlobalVariables.enter_times[GlobalVariables.building]++;
        Invoke("nextScene", 4f);

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
