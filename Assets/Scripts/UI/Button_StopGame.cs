using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_StopGame : MonoBehaviour
{

    public Button stopButton;

    void Start()
    {
        if (stopButton != null)
        {
            stopButton.onClick.AddListener(StopGame);
        }
    }

    void StopGame()
    {
        // ゲームをストップする
        Time.timeScale = 0;
    }
}
