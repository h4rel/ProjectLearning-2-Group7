using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class OnMouseDown_TeamName : MonoBehaviour
{
    public InputField usernameInput; // ユーザネーム入力フィールドをInspectorから指定
    public string loginUrl = "http://localhost:5000/login"; // サーバのURL
    public AudioSource clickSound; // オーディオソースをInspectorから指定
    public string sceneToLoad; // 遷移先のシーン名をInspectorから指定

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
        // デバッグ情報を追加
        if (PlayerData.Instance == null)
        {
            Debug.LogError("PlayerData.Instance is null");
        }
        else
        {
            Debug.Log("PlayerData.Instance is not null");
        }

        string roomName = usernameInput.text;

        if (PlayerData.Instance != null && !string.IsNullOrEmpty(usernameInput.text) && !string.IsNullOrEmpty(roomName))
        {
            PlayerData.Instance.RoomName = roomName; // シングルトンにルーム名を設定
            // クリック音を再生
            PlayClickSound();

            // シーンを変更
            if (!string.IsNullOrEmpty(sceneToLoad))
            {
                SceneManager.LoadScene(sceneToLoad);  // Inspectorで指定したシーンに遷移
            }
            else
            {
                Debug.Log("Scene to load is not specified");
            }
        }
        else
        {
            Debug.Log("Username is empty or PlayerData.Instance is null");
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
            if (!string.IsNullOrEmpty(sceneToLoad))
            {
                SceneManager.LoadScene(sceneToLoad); // Inspectorで指定したシーンに遷移
            }
            else
            {
                Debug.Log("Scene to load is not specified");
            }
        }
    }
}
