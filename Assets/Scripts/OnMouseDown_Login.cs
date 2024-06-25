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

    void OnMouseDown()
    {
        //StartCoroutine(Login());
        SceneManager.LoadScene("SelectGameScene");  // サーバプログラム無しで実行する時
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
