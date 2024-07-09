using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllers : MonoBehaviour
{
    public bool FacingLeft { get { return facingLeft; } set { facingLeft = value; } }
    public static PlayerControllers Instance;

    [SerializeField] private float moveSpeed = 1f;

    AudioManger audioManger;

    private PlayerControls playerControls;
    private Vector2 movement;
    private Rigidbody2D rb;
    private SpriteRenderer mySpriteRender;
    private Knockback knockback;

    private bool facingLeft = false;

    private void Awake()
    {
        Instance = this;

        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
        mySpriteRender = GetComponent<SpriteRenderer>();
        knockback = GetComponent<Knockback>();
        audioManger = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManger>(); //Add Music
    }

    private void OnEnable()
    {
        // 入力アクションの有効化
        playerControls.Enable();
    }

    private void OnDisable()
    {
        // 入力アクションの無効化
        playerControls.Disable();
    }

    private void Update()
    {
        // プレイヤーの入力処理を行うメソッドの呼び出し
        PlayerInput();
    }

    private void FixedUpdate()
    {
        // プレイヤーの向きを調整するメソッドと移動処理を行うメソッドの呼び出し
        AdjustPlayerFacingDirection();
        Move();
    }

    private void PlayerInput()
    {
        // 入力アクションから移動方向を取得
        movement = playerControls.Movement.Move.ReadValue<Vector2>();
    }

    private void Move()
    {
        if (knockback.gettingKnockedBack) { return; }

        // プレイヤーを移動させる処理
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }

    private void AdjustPlayerFacingDirection()
    {
        // プレイヤーの向きをマウスの位置に応じて調整する
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);

        if (mousePos.x < playerScreenPoint.x)
        {
            // プレイヤーが左を向いていることを示すフラグとスプライトの反転
            mySpriteRender.flipX = true;
            facingLeft = true;
        }
        else
        {
            // プレイヤーが右を向いていることを示すフラグとスプライトの反転
            mySpriteRender.flipX = false;
            facingLeft = false;
        }
    }
}
