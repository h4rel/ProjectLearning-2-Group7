using UnityEngine;

public class SquirrelController : MonoBehaviour
{
    public float fadeDuration = 1.0f;  // フェードアウトの時間
    public float detectionRadius = 5.0f;  // プレイヤーを検出する半径
    public Transform player;  // プレイヤーのTransform

    private SpriteRenderer spriteRenderer;
    private bool isFading = false;
    private float fadeStartTime;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (player == null)
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            if (playerObject != null)
            {
                player = playerObject.transform;
            }
            else
            {
                Debug.LogError("Player object not found. Make sure there is a GameObject with the tag 'Player' in the scene.");
            }
        }
    }

    void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector3.Distance(player.position, transform.position);

        if (distanceToPlayer < detectionRadius && !isFading)
        {
            StartFadeOut();
        }

        if (isFading)
        {
            float elapsed = Time.time - fadeStartTime;
            float alpha = Mathf.Lerp(1.0f, 0.0f, elapsed / fadeDuration);
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, alpha);

            if (alpha <= 0.0f)
            {
                isFading = false;
                gameObject.SetActive(false);
            }
        }
    }

    void StartFadeOut()
    {
        isFading = true;
        fadeStartTime = Time.time;
    }
}
