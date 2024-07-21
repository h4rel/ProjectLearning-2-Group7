using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NoOneHere : MonoBehaviour
{
    [SerializeField] private BattleText text;
    void Start()
    {
        text.Show("今ここには何もないようだ...");
        Invoke("back", 3f);
    }

    void back()
    {
        SceneManager.LoadScene(GlobalVariables.beforeScene);
    }
}
