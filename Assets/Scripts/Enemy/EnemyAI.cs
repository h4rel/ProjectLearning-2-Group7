using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float roamChangeDirFloat = 2f;
    [SerializeField] private float attackRange = 5f;
    [SerializeField] private MonoBehaviour enemyType;
    [SerializeField] private float attackCooldown = 2f;
    [SerializeField] private bool stopMovingWhileSttacking = false;

    private bool canAttack = true;

    // 敵の状態を表す列挙型
    private enum State
    {
        Roaming, // 散策中の状態
        Attacking
    }

    private Vector2 roamPosition;
    private float timeRoaming = 0f;

    private State state; // 現在の状態
    private EnemyPathfinding enemyPathfinding; // 敵のパスファインディングクラス

    private void Awake()
    {
        enemyPathfinding = GetComponent<EnemyPathfinding>(); // パスファインディングクラスの取得
        state = State.Roaming; // 初期状態を散策中に設定
    }

    private void Start()
    {
        roamPosition = GetRoamingPosition();
    }

    private void Update()
    {
        MovementStateControl();
    }

    private void MovementStateControl()
    {
        switch (state)
        {
            default:
            case State.Roaming:
                Roaming();
                break;

            case State.Attacking:
                Attacking();
                break;
        }
    }

    private void Roaming()
    {
        timeRoaming += Time.deltaTime;

        enemyPathfinding.MoveTo(roamPosition);

        if(Vector2.Distance(transform.position, PlayerControllers.Instance.transform.position) < attackRange)
        {
            state = State.Attacking;
        }

        if(timeRoaming > roamChangeDirFloat)
        {
            roamPosition = GetRoamingPosition();
        }
    }

    private void Attacking() 
    { 
        if(Vector2.Distance(transform.position, PlayerControllers.Instance.transform.position)>attackRange)
        {
            state = State.Roaming;
        }

        if (attackRange != 0 && canAttack)
        {
            canAttack = false;
            (enemyType as IEnemy).Attack();

            if (stopMovingWhileSttacking)
            {
                enemyPathfinding.StopMoving();
            }
            else
            {
                enemyPathfinding.MoveTo(roamPosition);
            }

            StartCoroutine(AttackCooldownRoutine());
        }
    }

    private IEnumerator AttackCooldownRoutine()
    {
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    // 散策位置をランダムに生成
    private Vector2 GetRoamingPosition()
    {
        timeRoaming = 0f;
        return new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized; // ランダムな方向を正規化して返す
    }
}
