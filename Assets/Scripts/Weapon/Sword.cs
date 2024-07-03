using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] private GameObject slashAnimPrefab;
    [SerializeField] private Transform slashAnimSpawnPoint;
    [SerializeField] private Transform weaponCollider;
    [SerializeField] private float swordAttackCD = 0.5f;

    private PlayerControls playerControls;
    private Animator myAnimator;
    private PlayerControllers playerControllers;
    private ActiveWeapon activeWeapon;
    private bool attackButtonDown, isAttacking = false;

    private GameObject slashAnim;

    private void Awake()
    {
        // 必要なコンポーネントを取得
        playerControllers = GetComponentInParent<PlayerControllers>();
        activeWeapon = GetComponent<ActiveWeapon>();
        myAnimator = GetComponent<Animator>();
        playerControls = new PlayerControls();

        // コンポーネントの初期化チェック
        if (playerControllers == null)
        {
            Debug.LogError("PlayerControllers is not assigned in Sword script.");
        }
        if (activeWeapon == null)
        {
            Debug.LogError("ActiveWeapon is not assigned in Sword script.");
        }
        if (myAnimator == null)
        {
            Debug.LogError("Animator is not assigned in Sword script.");
        }
    }

    private void OnEnable()
    {
        // インプットアクションを有効化
        playerControls.Enable();
    }

    private void OnDisable()
    {
        // インプットアクションを無効化
        playerControls.Disable();
    }

    private void Start()
    {
        // インプットアクションにコールバックを設定
        playerControls.Combat.Attack.started += _ => StartAttacking();
        playerControls.Combat.Attack.canceled += _ => StopAttacking();
    }

    private void Update()
    {
        MouseFollowWithOffset(); // 武器の向きをマウスに合わせる
        Attack(); // 攻撃処理
    }

    private void StartAttacking()
    {
        attackButtonDown = true;
    }

    private void StopAttacking()
    {
        attackButtonDown = false;
    }

    private void Attack()
    {
        // 攻撃ボタンが押され、攻撃中でない場合に攻撃を開始
        if (attackButtonDown && !isAttacking)
        {
            isAttacking = true;
            myAnimator.SetTrigger("Attack");
            weaponCollider.gameObject.SetActive(true);
            slashAnim = Instantiate(slashAnimPrefab, slashAnimSpawnPoint.position, Quaternion.identity);
            slashAnim.transform.parent = this.transform.parent;
            StartCoroutine(AttackCDRoutine());
        }
    }

    private IEnumerator AttackCDRoutine()
    {
        yield return new WaitForSeconds(swordAttackCD);
        isAttacking = false;
    }

    public void DoneAttackingAnimEvent()
    {
        weaponCollider.gameObject.SetActive(false);
    }

    private void SwingUpFlipAnimEvent()
    {
        slashAnim.gameObject.transform.rotation = Quaternion.Euler(-180, 0, 0);

        if (playerControllers.FacingLeft)
        {
            slashAnim.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    private void SwingDownFlipAnimEvent()
    {
        slashAnim.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);

        if (playerControllers.FacingLeft)
        {
            slashAnim.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    private void MouseFollowWithOffset()
    {
        // playerControllersが正しく初期化されているか確認
        if (playerControllers == null)
        {
            Debug.LogError("PlayerControllers is not assigned in MouseFollowWithOffset.");
            return;
        }

        // Camera.mainがnullでないか確認
        if (Camera.main == null)
        {
            Debug.LogError("Main Camera is not assigned in the scene.");
            return;
        }

        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(playerControllers.transform.position);

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        if (mousePos.x < playerScreenPoint.x)
        {
            activeWeapon.transform.rotation = Quaternion.Euler(0, -180, angle);
            weaponCollider.transform.rotation = Quaternion.Euler(0, -180, 0);
        }
        else
        {
            activeWeapon.transform.rotation = Quaternion.Euler(0, 0, angle);
            weaponCollider.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
