using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ダメージを与えるオブジェクトを定義するクラス
public class DamageSource : MonoBehaviour
{
    // ダメージの量を設定するための変数（インスペクタで設定可能）
    [SerializeField] private int damageAmount = 1;

    // 他のオブジェクトがトリガーゾーンに入ったときに呼び出されるメソッド
    public void OnTriggerEnter2D(Collider2D other)
    {
        // トリガーゾーンに入ったオブジェクトがEnemyHealthコンポーネントを持っているかチェック
        if (other.gameObject.GetComponent<EnemyHealth>())
        {
            // EnemyHealthコンポーネントを取得
            EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
            // ダメージを与えるメソッドを呼び出す
            enemyHealth.TakeDamage(damageAmount);
        }
    }
}
