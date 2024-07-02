using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathfinding : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f; // 移動速度

    private Rigidbody2D rb; // Rigidbody2Dコンポーネント
    private Vector2 moveDir; // 移動方向ベクトル
    private Knockback knockback; // ノックバック処理クラス

    private void Awake()
    {
        knockback = GetComponent<Knockback>(); // ノックバック処理クラスの取得
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2Dコンポーネントの取得
    }

    private void FixedUpdate()
    {
        if (knockback.gettingKnockedBack) { return; } // ノックバック中は動かない

        rb.MovePosition(rb.position + moveDir * (moveSpeed * Time.fixedDeltaTime)); // 指定した方向に移動する
    }

    // ターゲットの位置へ移動するメソッド
    public void MoveTo(Vector2 targetPosition)
    {
        moveDir = targetPosition; // 移動方向を設定する
    }
}
