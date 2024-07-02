using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    // ノックバック中であることを示すプロパティ
    public bool gettingKnockedBack { get; private set; }

    [SerializeField] private float knockBackTime = .2f; // ノックバックの持続時間

    private Rigidbody2D rb; // 物理挙動を制御するためのRigidbody2Dコンポーネント

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2Dコンポーネントを取得
    }

    // ノックバックを受けるメソッド
    public void GetKnockedBack(Transform damageSource, float knockBackThrust)
    {
        gettingKnockedBack = true; // ノックバック中であることを示すフラグを設定
        Vector2 difference = (transform.position - damageSource.position).normalized * knockBackThrust * rb.mass;
        rb.AddForce(difference, ForceMode2D.Impulse); // ノックバックの力を加える
        StartCoroutine(KnockRoutine()); // ノックバックの持続時間を制御するコルーチンを開始
    }

    // ノックバックの持続時間を制御するコルーチン
    private IEnumerator KnockRoutine()
    {
        yield return new WaitForSeconds(knockBackTime); // ノックバックの持続時間だけ待機
        rb.velocity = Vector2.zero; // ノックバック終了後に速度をゼロにする
        gettingKnockedBack = false; // ノックバックが終了したことを示すフラグを解除
    }
}
