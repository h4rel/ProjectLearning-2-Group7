using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{
    [SerializeField] private BattleText text;

    [SerializeField] private GameObject enemy;

    [SerializeField] private GameObject player;

    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(first());

    }

    private IEnumerator first()
    {
        yield return new WaitForSeconds(1);
        text.Show(enemy.name + "があらわれた！");
    }
}