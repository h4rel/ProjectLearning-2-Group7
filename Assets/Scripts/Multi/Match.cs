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
        Debug.Log("Connected to Master");
        string roomName = $"MatchRoom{maxPlayers}"; // マッチ人数に基づいた部屋名を設定
        Debug.Log($"Attempting to join or create room: {roomName}");
        PhotonNetwork.JoinOrCreateRoom(roomName, new RoomOptions { MaxPlayers = (byte)maxPlayers }, TypedLobby.Default);
    }

    public override void OnJoinedRoom() {
        Debug.Log("Joined Room");
        Debug.Log($"Current player count: {PhotonNetwork.CurrentRoom.PlayerCount}");

        // 全プレイヤーが揃ったらシーン遷移を行う
        if (PhotonNetwork.CurrentRoom.PlayerCount == maxPlayers) {
            // 全プレイヤーに対してシーン遷移を行う
            PhotonNetwork.LoadLevel("StartFieldSceneMulti");
            PhotonNetwork.LeaveRoom();
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer) {
        Debug.Log("Player entered room");
        Debug.Log($"Current player count: {PhotonNetwork.CurrentRoom.PlayerCount}");

        // 新しいプレイヤーが入ったときも、全プレイヤーが揃ったらシーン遷移を行う
        if (PhotonNetwork.CurrentRoom.PlayerCount == maxPlayers) {
            PhotonNetwork.LoadLevel("StartFieldSceneMulti");
            PhotonNetwork.LeaveRoom();
        }
    }
}
