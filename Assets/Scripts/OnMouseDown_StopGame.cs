using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseDown_StopGame : MonoBehaviour
{

    void OnMouseDown()
    {
        // ゲームをストップする
        Time.timeScale = 0;
    }
}
