using UnityEngine;

public class CrowController1 : MonoBehaviour
{
    public float detectionRadius_c = 5.0f;  // プレイヤーを検出する半径
    public Transform player1;  // プレイヤーのTransform

    private AudioSource audioSource;
    private bool isWithinDetectionRadius = false;  // プレイヤーが検出半径内にいるかどうかのフラグ
    public float playInterval = 1.0f;  // 音を再生する間隔（秒）
    private float timeSinceLastPlay = 0.0f;  // 最後に音を再生してからの経過時間

    void Start()
    {
        // AudioSourceコンポーネントを取得
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component not found. Please attach an AudioSource component to the GameObject.");
        }

        if (player1 == null)
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            if (playerObject != null)
            {
                player1 = playerObject.transform;
            }
            else
            {
                Debug.LogError("Player object not found. Make sure there is a GameObject with the tag 'Player' in the scene.");
            }
        }
    }

    void Update()
    {
        if (player1 == null)
        {
            Debug.LogWarning("Player1 is null.");
            return;
        }

        float distanceToPlayer = Vector3.Distance(player1.position, transform.position);

        if (distanceToPlayer < detectionRadius_c)
        {
            if (!isWithinDetectionRadius)
            {
                isWithinDetectionRadius = true;
                timeSinceLastPlay = 0.0f;  // プレイヤーが範囲に入ったらタイマーをリセット
            }

            // 音を再生する間隔で音を再生
            timeSinceLastPlay += Time.deltaTime;
            if (timeSinceLastPlay >= playInterval)
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                    Debug.Log("Audio played.");
                }
                timeSinceLastPlay = 0.0f;  // タイマーをリセット
            }
        }
        else
        {
            if (isWithinDetectionRadius)
            {
                isWithinDetectionRadius = false;
                if (audioSource.isPlaying)
                {
                    audioSource.Stop();
                    Debug.Log("Audio stopped.");
                }
            }
        }
    }
}
