using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class AvatarController : MonoBehaviourPunCallbacks
{
    public string upAnime = "";
    public string downAnime = "";
    public string rightAnime = "";
    public string leftAnime = "";

    private string nowMode = "";
    private string oldMode = "";
    private bool isMoving = false;

    private Animator animator;
    public static int triggerId = -1;

    private void Start()
    {
        nowMode = downAnime;
        oldMode = "";
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (photonView.IsMine)
        {
            var input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
            transform.Translate(6f * Time.deltaTime * input.normalized);

            isMoving = false;

            if (Input.GetKey("up"))
            {
                ChangeDirection(upAnime);
            }
            else if (Input.GetKey("down"))
            {
                ChangeDirection(downAnime);
            }
            else if (Input.GetKey("right"))
            {
                ChangeDirection(rightAnime);
            }
            else if (Input.GetKey("left"))
            {
                ChangeDirection(leftAnime);
            }

            if (!isMoving)
            {
                animator.speed = 0;
            }
            else
            {
                animator.speed = 1;
            }
        }
    }

    private void ChangeDirection(string direction)
    {
        nowMode = direction;
        isMoving = true;

        if (nowMode != oldMode)
        {
            oldMode = nowMode;
            photonView.RPC("SyncAnimation", RpcTarget.All, nowMode);
        }
    }

    [PunRPC]
    private void SyncAnimation(string animation)
    {
        animator.Play(animation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneChangeTrigger trigger = collision.gameObject.GetComponent<SceneChangeTrigger>();
        if (trigger != null)
        {
            Debug.Log($"Trigger detected with ID: {trigger.triggerId}");

            triggerId = trigger.triggerId;

            if (triggerId == 131 || triggerId == 141 || triggerId == 151 || triggerId == 161)
            {
                TriggerMoveToStartFieldScene("StartFieldSceneMulti");
            }
            else
            {
                PhotonNetwork.LeaveRoom();
                switch (triggerId)
                {
                    case 1:
                        SceneManager.LoadScene("Field01SceneMulti");
                        break;
                    case 2:
                        SceneManager.LoadScene("StartFieldSceneMulti");
                        break;
                    case 3:
                        SceneManager.LoadScene("Field02SceneMulti");
                        break;
                    case 4:
                        SceneManager.LoadScene("Field01SceneMulti");
                        break;
                    case 5:
                        SceneManager.LoadScene("Field03SceneMulti");
                        break;
                    case 6:
                        SceneManager.LoadScene("Field02SceneMulti");
                        break;
                    case 7:
                        SceneManager.LoadScene("Field04SceneMulti");
                        break;
                    case 8:
                        SceneManager.LoadScene("Field03SceneMulti");
                        break;
                    case 9:
                        SceneManager.LoadScene("Field05SceneMulti");
                        break;
                    case 10:
                        SceneManager.LoadScene("Field04SceneMulti");
                        break;
                    case 11:
                        SceneManager.LoadScene("Field06SceneMulti");
                        break;
                    case 12:
                        SceneManager.LoadScene("Field05SceneMulti");
                        break;
                    case 13:
                        SceneManager.LoadScene("Field04SceneMulti");
                        break;
                    case 14:
                        SceneManager.LoadScene("Field06SceneMulti");
                        break;
                    default:
                        Debug.LogWarning("Unknown triggerId: " + triggerId);
                        break;
                }
            }
        }
    }
    public void TriggerMoveToStartFieldScene(string sceneName)
    {
        photonView.RPC("MoveToStartFieldScene", RpcTarget.All, sceneName);
    }

    [PunRPC]
private void MoveToStartFieldScene(string sceneName)
{
    if(triggerId == 131 || triggerId == 141 || triggerId == 151 || triggerId == 161){
        // ルームから退出
    PhotonNetwork.LeaveRoom();
    // シーンを読み込む
    PhotonNetwork.LoadLevel(sceneName);
    } else {
    PhotonNetwork.LeaveRoom();
    // シーンを読み込む
    PhotonNetwork.LoadLevel("Multi_CommandBattle");
    }
    
}
}
