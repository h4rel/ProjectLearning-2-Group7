using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseDown_Hide : MonoBehaviour{

    public GameObject objectToHide; // 非表示にするゲームオブジェクトをInspectorから指定する

    void OnMouseDown(){

        if (objectToHide != null)
        {
            objectToHide.SetActive(false); // 指定したゲームオブジェクトを非表示にする
        }

        this.gameObject.SetActive(false); // 自身のゲームオブジェクト（ボタン）も非表示にする

    }
}
