using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseDown_Hide : MonoBehaviour
{
    public List<GameObject> objectsToHide; // 非表示にするゲームオブジェクトのリストをInspectorから指定する

    void OnMouseDown()
    {
        // 指定したゲームオブジェクトを全て非表示にする
        foreach (GameObject obj in objectsToHide)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }

        this.gameObject.SetActive(false); // 自身のゲームオブジェクト（ボタン）も非表示にする
    }
}
