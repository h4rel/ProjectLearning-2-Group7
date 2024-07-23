using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Match : MonoBehaviourPunCallbacks
{
    // インスペクターで設定するための変数
    [SerializeField] private int maxPlayers = 2; // マッチする人数を指定

    private void Start() {
        Debug.Log("Connecting to Photon...");
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster() {
        if (PlayerData.Instance != null && !string.IsNullOrEmpty(PlayerData.Instance.RoomName))
        {
            // 外部入力から取得したルーム名でルームに参加または作成
            string room = PlayerData.Instance.RoomName;
            string roomName = $"{room}{maxPlayers}";
            PhotonNetwork.JoinOrCreateRoom(roomName, new RoomOptions { MaxPlayers = (byte)maxPlayers }, TypedLobby.Default);
        }
        else
        {
            Debug.LogWarning("Room name is not set.");
        }
    }

    public override void OnJoinedRoom() {
        Debug.Log("Joined Room");
        Debug.Log($"Current player count: {PhotonNetwork.CurrentRoom.PlayerCount}");

        // 自分の順番を設定する
        GlobalVariables.mynum = PhotonNetwork.CurrentRoom.PlayerCount;
        if (GlobalVariables.mynum == maxPlayers)
        {
            var roomHash = new ExitGames.Client.Photon.Hashtable();
            string tt = Time.time.ToString("F2");
            roomHash.Add("tt", tt);
            PhotonNetwork.CurrentRoom.SetCustomProperties(roomHash);
            PlayerData.Instance.RoomName = PlayerData.Instance.RoomName + tt;
        }
        Debug.Log($"My player number: {GlobalVariables.mynum}");

        // 全プレイヤーが揃ったらシーン遷移を行う
        if (PhotonNetwork.CurrentRoom.PlayerCount == maxPlayers) {
            GlobalVariables.init();
            // 全プレイヤーに対してシーン遷移を行う
            PhotonNetwork.LoadLevel("StartFieldSceneMulti");
            PhotonNetwork.LeaveRoom();
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer) {
        Debug.Log("Player entered room");
        Debug.Log($"Current player count: {PhotonNetwork.CurrentRoom.PlayerCount}");

        // ここでは新しいプレイヤーに番号を設定しない (OnJoinedRoomで既に設定済み)

        // 新しいプレイヤーが入ったときも、全プレイヤーが揃ったらシーン遷移を行う
       /* if (PhotonNetwork.CurrentRoom.PlayerCount == maxPlayers) {
            PhotonNetwork.LoadLevel("StartFieldSceneMulti");
            PhotonNetwork.LeaveRoom();
        }*/
    }



    public override void OnRoomPropertiesUpdate(ExitGames.Client.Photon.Hashtable propertiesThatChanged)
    {
        object value = null;
        if (propertiesThatChanged.TryGetValue("tt", out value))
        {
            string qwe = (string)value;
            PlayerData.Instance.RoomName = PlayerData.Instance.RoomName +qwe;
            Debug.Log(PlayerData.Instance.RoomName);
            GlobalVariables.init();
            PhotonNetwork.LoadLevel("StartFieldSceneMulti");
            PhotonNetwork.LeaveRoom();
        }

    }

}
