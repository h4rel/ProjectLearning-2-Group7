using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnCollision_SwitchScene1 : MonoBehaviourPunCallbacks
{
    public string targetObjectName; // 目標オブジェクト名：Inspectorで指定
    public string sceneName;  // シーン名：Inspectorで指定
    public string from; // どこから移動するか：Inspectorで指定

    void OnCollisionEnter2D(Collision2D collision)
    {
        // もし、衝突したものの名前が目標オブジェクトだったら
        if (collision.gameObject.name == targetObjectName && photonView.IsMine)
        {
            // 画面遷移の方向の保存
            GlobalVariables.dir = from;
            // ルームから退室する
            PhotonNetwork.LeaveRoom();
        }
    }

    public override void OnLeftRoom()
    {
        // ルームを退室した後、シーンを切り替える
        PhotonNetwork.LoadLevel(sceneName);
    }
}
