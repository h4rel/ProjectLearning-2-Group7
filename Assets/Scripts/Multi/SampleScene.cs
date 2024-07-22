using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using System.Collections;

public class SampleScene : MonoBehaviourPunCallbacks
{
    public int roomNumber = 1;

    private int triggerId = 0;

    private void Start() {
    if (PhotonNetwork.NetworkClientState == ClientState.Disconnected) {
        PhotonNetwork.ConnectUsingSettings();
    } else {
        Debug.LogWarning("ConnectUsingSettings() failed. Can only connect while in state 'Disconnected'. Current state: " + PhotonNetwork.NetworkClientState);
    }
}


    public override void OnConnectedToMaster() {
        if (PlayerData.Instance != null && !string.IsNullOrEmpty(PlayerData.Instance.RoomName))
        {
            string room = PlayerData.Instance.RoomName;
            string roomName = $"{room}{roomNumber}";
            PhotonNetwork.JoinOrCreateRoom(roomName, new RoomOptions(), TypedLobby.Default);
        }
        else
        {
            Debug.LogWarning("Room name is not set.");
        }
    }

    public override void OnJoinedRoom()
    {
        Vector3 position = GetSpawnPosition();
        PhotonNetwork.Instantiate("Player1", position, Quaternion.identity);

        // 遅延処理を開始
        if (triggerId == 13)
        {
            AvatarController avatarController = FindObjectOfType<AvatarController>();
            if (avatarController != null)
            {
                StartCoroutine(HandleSceneTransition(avatarController));
            }
        }
    }

    private IEnumerator HandleSceneTransition(AvatarController avatarController)
    {
        yield return new WaitForSeconds(0f);

        switch (GlobalVariables.hasTransitioned)
        {
            case 0:
                GlobalVariables.hasTransitioned = 1; // シーン遷移が実行されたことを記録
                avatarController.TriggerMoveToStartFieldScene("Field01SceneMulti");
                break;
            case 1:
                GlobalVariables.hasTransitioned = 2; // シーン遷移が実行されたことを記録
                avatarController.TriggerMoveToStartFieldScene("Field02SceneMulti");
                break;
            case 2:
                avatarController.TriggerMoveToStartFieldScene("Field03SceneMulti");
                GlobalVariables.hasTransitioned = 0; // 次回の遷移を記録
                AvatarController.triggerId = 0;
                break;
            default:
                // 追加のケースが必要な場合はここに記述
                break;
        }
    }


    private Vector3 GetSpawnPosition()
    {
        triggerId = AvatarController.triggerId;
        Debug.Log($"Trigger detected with ID: {AvatarController.triggerId}");
        if (triggerId == 0)
        {
            return new Vector3(-3.01f, -0.6f);
        }
        else if (triggerId % 2 == 1)
        {
            return new Vector3(-7.5f, 0f);
        }
        else if (triggerId % 2 == 0)
        {
            return new Vector3(7.5f, 0f);
        }
        return new Vector3(-3.01f, -0.6f);
    }
}
