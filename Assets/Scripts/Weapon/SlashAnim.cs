using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashAnim : MonoBehaviour
{
    private ParticleSystem ps; // ParticleSystemコンポーネントを保持する変数

    private void Awake()
    {
        ps = GetComponent<ParticleSystem>(); // このGameObjectにアタッチされたParticleSystemコンポーネントを取得
    }

    private void Update()
    {
        // ParticleSystemが存在し、かつ生存していない場合
        if (ps && !ps.IsAlive())
        {
            DestroySelf(); // このGameObjectを破壊するメソッドを呼び出す
        }
    }

    public void DestroySelf()
    {
        Destroy(gameObject); // このGameObjectを破壊
    }

    // スラッシュエフェクトを再生するメソッド
    public void PlaySlashEffect()
    {
        if (ps != null)
        {
            Debug.Log("スラッシュパーティクルエフェクトを再生");
            ps.Play(); // パーティクルシステムを再生
        }
    }
}
