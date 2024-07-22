using Photon.Pun;
using Photon.Realtime;
using Unity.VisualScripting;
using UnityEngine;

// MonoBehaviourPunCallbacksを継承して、PUNのコールバックを受け取れるようにする
public class MultiBattleEnter : MonoBehaviourPunCallbacks
{
    [SerializeField] private MultiBattle mb;

    // Inspectorで設定するためのpublicフィールドを追加
    public int roomNumber = 1; // デフォルトのルーム番号を1に設定

   // private int triggerId = 0; // 初期化用の識別子

    bool end = false;
    private void Start()
    {
        // PhotonServerSettingsの設定内容を使ってマスターサーバーへ接続する
        Debug.Log("start");
        end = false;
        // PlayerData.Instance.RoomName = "aaa";     //遷移してこれるようになったら多分消す
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("puppy");
        if (!end) Continue();

        
    }

    public void Continue()
    {
        if (PhotonNetwork.IsConnectedAndReady)
        {
            Debug.Log("connected to master");
            if (PlayerData.Instance != null && !string.IsNullOrEmpty(PlayerData.Instance.RoomName))
            {
                // 外部入力から取得したルーム名でルームに参加または作成
                string room = PlayerData.Instance.RoomName;
                string roomName = $"{room}{roomNumber}";
                Debug.Log("before create room");
                PhotonNetwork.JoinOrCreateRoom(roomName, new RoomOptions(), TypedLobby.Default);
                Debug.Log("after create room");
            }
            else
            {
                Debug.Log("no");
                Debug.LogWarning("Room name is not set.");
            }
            Debug.Log("out");
        }
    }

    // マスターサーバーへの接続が成功した時に呼ばれるコールバック
    public override void OnConnectedToMaster()
    {
        Debug.Log("connected to master");
        end = true;
        if (PlayerData.Instance != null && !string.IsNullOrEmpty(PlayerData.Instance.RoomName))
        {
            // 外部入力から取得したルーム名でルームに参加または作成
            string room = PlayerData.Instance.RoomName;
            string roomName = $"{room}{roomNumber}";
            Debug.Log("before create room");
            PhotonNetwork.JoinOrCreateRoom(roomName, new RoomOptions(), TypedLobby.Default);
            Debug.Log("after create room");
        }
        else
        {
            Debug.Log("no");
            Debug.LogWarning("Room name is not set.");
        }
        Debug.Log("out");
        // // Inspectorで設定したルーム番号を使ってルーム名を設定する
        // string roomName = $"Room{roomNumber}";
        // // ルーム名を使ってルームに参加する（ルームが存在しなければ作成して参加する）
        // PhotonNetwork.JoinOrCreateRoom(roomName, new RoomOptions(), TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        ExitGames.Client.Photon.Hashtable myHash = new ExitGames.Client.Photon.Hashtable();
        myHash["n"] = GlobalVariables._name;
        myHash["h"] = GlobalVariables.maxHP;
        myHash["pn"] = GlobalVariables.mynum;
        myHash["a"] = GlobalVariables.ATK + GlobalVariables.weaponATK[GlobalVariables.hold+1];
        PhotonNetwork.LocalPlayer.SetCustomProperties(myHash);
        Debug.Log("joinedroom");

        Debug.Log("plnum =" + PhotonNetwork.CurrentRoom.PlayerCount);
        if (PhotonNetwork.CurrentRoom.PlayerCount == GlobalVariables.NOP)
        {
            Debug.Log("should start");
            mb.Invoke("after_connected", 1);
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount == GlobalVariables.NOP)
        {
            mb.Invoke("after_connected", 1);
        }

    }
}