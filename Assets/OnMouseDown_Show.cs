using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseDown_Show : MonoBehaviour
{
    public List<GameObject> objectsToShow; // 表示にするゲームオブジェクトのリストをInspectorから指定する

    void OnMouseDown()
    {
        // 指定したゲームオブジェクトを全て表示する
        foreach (GameObject obj in objectsToShow)
        {
            if (obj != null)
            {
                obj.SetActive(true);
            }
        }

        this.gameObject.SetActive(false); // 自身のゲームオブジェクト（ボタン）を非表示にする場合はこの行を使う
        //this.gameObject.SetActive(true); // 自身のゲームオブジェクト（ボタン）を表示したままにする場合はこの行を使う
    }
}
