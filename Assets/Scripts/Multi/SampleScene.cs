using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using System.Collections;

public class SampleScene : MonoBehaviourPunCallbacks
{
    public int roomNumber = 1;

    private int triggerId = 0;

    bool end = false;

    private void Start() {
        end = false;
    if (PhotonNetwork.NetworkClientState == ClientState.Disconnected) {
        PhotonNetwork.ConnectUsingSettings();
    } else {
        Debug.LogWarning("ConnectUsingSettings() failed. Can only connect while in state 'Disconnected'. Current state: " + PhotonNetwork.NetworkClientState);
    }
    if (!end)
        {
            Continue();
        }

}

    public void Continue()
    {
        if (PlayerData.Instance != null && !string.IsNullOrEmpty(PlayerData.Instance.RoomName))
        {
            end = true;
            string room = PlayerData.Instance.RoomName;
            string roomName = $"{room}{roomNumber}";
            PhotonNetwork.JoinOrCreateRoom(roomName, new RoomOptions(), TypedLobby.Default);
        }
        else
        {
            Debug.LogWarning("Room name is not set.");
        }
    }


    public override void OnConnectedToMaster() {
        if (PlayerData.Instance != null && !string.IsNullOrEmpty(PlayerData.Instance.RoomName))
        {
            end = true;
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
        switch (GlobalVariables.mynum)
                {
                    case 1:
                        PhotonNetwork.Instantiate("Player1", position, Quaternion.identity);
                        break;
                    case 2:
                        PhotonNetwork.Instantiate("Player1", position, Quaternion.identity);
                        break;
                    case 3:
                        PhotonNetwork.Instantiate("Player1", position, Quaternion.identity);
                        break;
                    case 4:
                        PhotonNetwork.Instantiate("Player1", position, Quaternion.identity);
                        break;
                    default:
                        break;
                }

        if (triggerId == 131 || triggerId == 141 || triggerId == 151 || triggerId == 161)
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
                GlobalVariables.hasTransitioned = 3; // シーン遷移が実行されたことを記録
                avatarController.TriggerMoveToStartFieldScene("Field03SceneMulti");
                break;
            case 3:
                GlobalVariables.hasTransitioned = 4; // シーン遷移が実行されたことを記録
                avatarController.TriggerMoveToStartFieldScene("Field04SceneMulti");
                break;
            case 4:
                GlobalVariables.hasTransitioned = 5; // シーン遷移が実行されたことを記録
                avatarController.TriggerMoveToStartFieldScene("Field05SceneMulti");
                break;
            case 5:
                GlobalVariables.hasTransitioned = 6; // シーン遷移が実行されたことを記録
                avatarController.TriggerMoveToStartFieldScene("Field06SceneMulti");
                break;
            case 6:
                avatarController.TriggerMoveToStartFieldScene("Multi_CommandBattle");
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
        switch (triggerId)
                {
                    case 0:
                        return new Vector3(-3.0f, -0.5f);
                    case 1:
                        return new Vector3(-8.12f, -0.7f);
                    case 2:
                        return new Vector3(7.74f, -0.54f);
                    case 3:
                        return new Vector3(-8.0f, 0.0f);
                    case 4:
                        return new Vector3(7.82f, -1.08f);
                    case 5:
                        return new Vector3(-7.8f, -1.4f);
                    case 6:
                        return new Vector3(8.0f, 0.0f);
                    case 7:
                        //return new Vector3(-7.66f, -3.3f);
                        return new Vector3(-7.66f, 0.0f);
                    case 8:
                        return new Vector3(7.0f, 3.7f);
                    case 9:
                        return new Vector3(-8.0f, -1.0f); 
                    case 10:
                        //return new Vector3(3.3f, -1.02f);
                        return new Vector3(-7.66f, -3.3f);
                    case 11:
                        return new Vector3(-7.7f, -0.85f);
                    case 12:
                        return new Vector3(8.0f, -1.0f);
                    case 13:
                        return new Vector3(5.8f, -1.3f);
                    case 14:
                        return new Vector3(8.0f, -1.51f);
                    default:
                        Debug.LogWarning("Unknown triggerId: " + triggerId);
                        return new Vector3(-1.02f, -0.5f);
                }
        
    }
}
