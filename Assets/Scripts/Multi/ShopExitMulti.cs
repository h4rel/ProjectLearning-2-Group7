using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class ShopExitMulti : MonoBehaviourPunCallbacks
{

    void Start()
    {
        // ボタンコンポーネントを取得し、クリックイベントにリスナーを追加します
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(OnButtonClick);
        }
    }

    // ボタンがクリックされたときの処理
    void OnButtonClick()
    {
        // 指定したシーンに遷移します
        if (GlobalVariables.NOP == 1)
        {
            SceneManager.LoadScene("Field05Scene");
        }
        else
        {
            AvatarController.triggerId++;
            PhotonNetwork.LeaveRoom();
            PhotonNetwork.LoadLevel("Field05SceneMulti");
        }
        
    }
}