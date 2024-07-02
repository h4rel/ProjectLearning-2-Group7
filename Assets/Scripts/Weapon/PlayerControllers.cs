using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllers : MonoBehaviour
{
    // プロパティとフィールドの定義
    public bool FacingLeft { get { return facingLeft; } set { facingLeft = value; } }
    public static PlayerControllers Instance;

    [SerializeField] private float moveSpeed = 1f;

    // クラス内で使用する変数の宣言
    private PlayerControls playerControls;
    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator myAnimator;
    private SpriteRenderer mySpriteRender;

    private bool facingLeft = false;

    private void Awake()
    {
        Instance = this;

        // PlayerControlsクラスのインスタンス化とコンポーネントの取得
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        mySpriteRender = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        // 入力アクションの有効化
        playerControls.Enable();
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
        // 入力アクションから移動方向を取得し、アニメーターにパラメーターとして渡す
        movement = playerControls.Movement.Move.ReadValue<Vector2>();

        myAnimator.SetFloat("moveX", movement.x);
        myAnimator.SetFloat("moveY", movement.y);
    }

    private void Move()
    {
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
