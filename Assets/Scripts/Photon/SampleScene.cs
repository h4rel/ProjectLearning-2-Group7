using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

// MonoBehaviourPunCallbacksを継承して、PUNのコールバックを受け取れるようにする
public class SampleScene : MonoBehaviourPunCallbacks
{
    private int triggerId = -1; // 初期化用の識別子
    private void Start() {
        // PhotonServerSettingsの設定内容を使ってマスターサーバーへ接続する
        PhotonNetwork.ConnectUsingSettings();
    }

    // マスターサーバーへの接続が成功した時に呼ばれるコールバック
    public override void OnConnectedToMaster() {
        // "Room"という名前のルームに参加する（ルームが存在しなければ作成して参加する）
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions(), TypedLobby.Default);
    }

    // ゲームサーバーへの接続が成功した時に呼ばれるコールバック
    public override void OnJoinedRoom() {
        // ランダムな座標に自身のアバター（ネットワークオブジェクト）を生成する
        Vector3 position = GetSpawnPosition();
        PhotonNetwork.Instantiate("Player1", position, Quaternion.identity);
    }

    private Vector3 GetSpawnPosition()
    {
        switch (triggerId)
        {
            case 1:
                return new Vector3(-7.5f, 0f); // トリガー1に対する生成位置
            case 2:
                return new Vector3(7.5f, 0f); // トリガー2に対する生成位置
            default:
                return new Vector3(-3.01f, -0.6f); // デフォルトの生成位置
        }
    }
}