using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OnMouseDown_Login1 : MonoBehaviour
{
    public InputField usernameInput; // ユーザネーム入力フィールドをInspectorから指定

    void OnMouseDown()
    {
        string username = usernameInput.text;
        if (string.IsNullOrEmpty(username))
        {
            Debug.Log("Username is empty");
            return;
        }

        // シングルトンにプレイヤー名を設定
        PlayerData.Instance.PlayerName = username;

        // シーンを変更
        SceneManager.LoadScene("SelectGameScene");
    }

}
