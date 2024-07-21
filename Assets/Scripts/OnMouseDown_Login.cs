using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class OnMouseDown_Login : MonoBehaviour
{
    public InputField usernameInput; // ユーザネーム入力フィールドをInspectorから指定
    public string loginUrl = "http://localhost:5000/login"; // サーバのURL
    public AudioSource clickSound; // オーディオソースをInspectorから指定

    // ボタンをクリックした際に音を再生する関数
    public void PlayClickSound()
    {
        // ユーザネームが空でない場合にクリック音を再生
        if (!string.IsNullOrEmpty(usernameInput.text) && clickSound != null)
        {
            clickSound.Play();
        }
    }

    void OnMouseDown()
    {
        // ユーザネームが空でない場合のみ処理を続ける
        if (!string.IsNullOrEmpty(usernameInput.text))
        {
            GlobalVariables._name = usernameInput.text;

            // クリック音を再生
            PlayClickSound();

            // シーンを変更
            SceneManager.LoadScene("SelectGameScene");  // サーバプログラム無しで実行する時
        }
        else
        {
            Debug.Log("Username is empty");
        }
    }

    IEnumerator Login()
    {
        string username = usernameInput.text;
        if (string.IsNullOrEmpty(username))
        {
            Debug.Log("Username is empty");
            yield break;
        }

        WWWForm form = new WWWForm();
        form.AddField("username", username);

        UnityWebRequest www = UnityWebRequest.Post(loginUrl, form);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Login successful");
            // 受理されたら画面遷移
            SceneManager.LoadScene("SelectGameScene"); // 遷移するシーン名に置き換えてください
        }
    }
}
