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
                nowMode = upAnime;
                isMoving = true;
            }
            else if (Input.GetKey("down"))
            {
                nowMode = downAnime;
                isMoving = true;
            }
            else if (Input.GetKey("right"))
            {
                nowMode = rightAnime;
                isMoving = true;
            }
            else if (Input.GetKey("left"))
            {
                nowMode = leftAnime;
                isMoving = true;
            }

            if (nowMode != oldMode)
            {
                oldMode = nowMode;
                animator.Play(nowMode);
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
            Vector3 position = new Vector3(Random.Range(-100f, 100f), Random.Range(-100f, 100f));
            transform.position = position;
        }
    }
}
