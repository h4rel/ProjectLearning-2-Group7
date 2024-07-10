using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

// MonoBehaviourPunCallbacksを継承して、PUNのコールバックを受け取れるようにする
public class SampleScene : MonoBehaviourPunCallbacks
{
    // Inspectorで設定するためのpublicフィールドを追加
    public int roomNumber = 1; // デフォルトのルーム番号を1に設定

    private int triggerId = 0; // 初期化用の識別子

    private void Start() {
        // PhotonServerSettingsの設定内容を使ってマスターサーバーへ接続する
        PhotonNetwork.ConnectUsingSettings();
    }

    // マスターサーバーへの接続が成功した時に呼ばれるコールバック
    public override void OnConnectedToMaster() {
        // Inspectorで設定したルーム番号を使ってルーム名を設定する
        string roomName = $"Room{roomNumber}";
        // ルーム名を使ってルームに参加する（ルームが存在しなければ作成して参加する）
        PhotonNetwork.JoinOrCreateRoom(roomName, new RoomOptions(), TypedLobby.Default);
    }

    // ゲームサーバーへの接続が成功した時に呼ばれるコールバック
    public override void OnJoinedRoom() {
        // ランダムな座標に自身のアバター（ネットワークオブジェクト）を生成する
        Vector3 position = GetSpawnPosition();
        PhotonNetwork.Instantiate("Player1", position, Quaternion.identity);
    }

    private Vector3 GetSpawnPosition()
    {
        triggerId = AvatarController.triggerId;
        Debug.Log($"Trigger detected with ID: {AvatarController.triggerId}"); // トリガーIDをログに出力
        if (triggerId == 0)
    {
        return new Vector3(-3.01f, -0.6f); // 0の時デフォルトの生成位置
    }
    else if (triggerId % 2 == 1)
    {
        return new Vector3(-7.5f, 0f); // 奇数の自然数の時
    }
    else if (triggerId % 2 == 0)
    {
        return new Vector3(7.5f, 0f); // 偶数の自然数の時
    }
    return new Vector3(-3.01f, -0.6f); // デフォルトの生成位置
    }
}
