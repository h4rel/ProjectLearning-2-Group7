using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    [SerializeField] private Material whiteFlashMat; // ダメージを受けた際に一時的に変更するマテリアル
    [SerializeField] private float restoreDefaultMatTime = .2f; // 元のマテリアルに戻すまでの時間

    private Material defaultMat; // 元のマテリアル
    private SpriteRenderer spriteRenderer; // スプライトレンダラーコンポーネント
    private EnemyHealth enemyHealth; // 敵のヘルスコンポーネント

    private void Awake()
    {
        enemyHealth = GetComponent<EnemyHealth>(); // 敵のヘルスコンポーネントを取得      
        spriteRenderer = GetComponent<SpriteRenderer>(); // スプライトレンダラーコンポーネントを取得
        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer component not found on " + gameObject.name);
        }
        else
        {
            defaultMat = spriteRenderer.material; // 元のマテリアルを保存
        }
    }

    // ダメージを受けた際のフラッシュルーチン
    public IEnumerator FlashRoutine()
    {
        if (spriteRenderer != null && whiteFlashMat != null)
        {
            spriteRenderer.material = whiteFlashMat; // マテリアルを一時的に白フラッシュマテリアルに変更
            yield return new WaitForSeconds(restoreDefaultMatTime); // 一定時間待機
            spriteRenderer.material = defaultMat; // 元のマテリアルに戻す
        }

        if (enemyHealth != null)
        {
            enemyHealth.DetectDeath(); // 敵の死亡を確認
        }
        else
        {
            Debug.Log("EnemyHealth component is not attached to " + gameObject.name + ", skipping DetectDeath.");
        }
    }
}
