using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    // 敵の状態を表す列挙型
    private enum State
    {
        Roaming // 散策中の状態
    }

    private State state; // 現在の状態
    private EnemyPathfinding enemyPathfinding; // 敵のパスファインディングクラス

    private void Awake()
    {
        enemyPathfinding = GetComponent<EnemyPathfinding>(); // パスファインディングクラスの取得
        state = State.Roaming; // 初期状態を散策中に設定
    }

    private void Start()
    {
        StartCoroutine(RoamingRoutine()); // 散策ルーチンを開始
    }

    // 散策ルーチン
    private IEnumerator RoamingRoutine()
    {
        while (state == State.Roaming) // 散策中の状態が続く限りループ
        {
            Vector2 roamPosition = GetRoamingPosition(); // 散策位置を取得
            enemyPathfinding.MoveTo(roamPosition); // 散策位置へ移動
            yield return new WaitForSeconds(2f); // 2秒待機
        }
    }

    // 散策位置をランダムに生成
    private Vector2 GetRoamingPosition()
    {
        return new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized; // ランダムな方向を正規化して返す
    }
}
