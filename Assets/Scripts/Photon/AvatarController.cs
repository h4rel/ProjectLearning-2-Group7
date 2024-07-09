using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AvatarController : MonoBehaviourPunCallbacks
{
    public string upAnime = "";     // 上向き：Inspectorで指定
    public string downAnime = "";   // 下向き：Inspectorで指定
    public string rightAnime = "";  // 右向き：Inspectorで指定
    public string leftAnime = "";   // 左向き：Inspectorで指定

    private string nowMode = "";
    private string oldMode = "";
    private bool isMoving = false;

    private Animator animator;
    private int triggerId = -1; // 初期化用の識別子


    private void Start()
    {
        nowMode = downAnime;
        oldMode = "";
        animator = GetComponent<Animator>(); // Animatorコンポーネントを取得
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
                animator.speed = 0; // アニメーションを停止
            }
            else
            {
                animator.speed = 1; // アニメーションを再開
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

    // シーンがロードされたときに呼ばれるコールバック
    public override void OnEnable()
    {
        base.OnEnable();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public override void OnDisable()
    {
        base.OnDisable();
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (photonView.IsMine)
        {
            var position = new Vector3(-3.01f, -0.6f);
            transform.position = position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
{
    SceneChangeTrigger trigger = collision.gameObject.GetComponent<SceneChangeTrigger>();
    if (trigger != null)
    {
        Debug.Log($"Trigger detected with ID: {trigger.triggerId}"); // トリガーIDをログに出力

        triggerId = trigger.triggerId;

        if (SceneManager.GetActiveScene().name == "StartFieldSceneMulti")
        {
            PhotonNetwork.LeaveRoom();
            SceneManager.LoadScene("Field01SceneMulti");
        }
        else if (SceneManager.GetActiveScene().name == "Field01SceneMulti")
        {
            PhotonNetwork.LeaveRoom();
            SceneManager.LoadScene("StartFieldSceneMulti");
        }
    }
}

}
