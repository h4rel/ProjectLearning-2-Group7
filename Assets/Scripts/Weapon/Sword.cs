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
        // ��Ҫ�ʥ���ݩ`�ͥ�Ȥ�ȡ��
        playerControllers = GetComponentInParent<PlayerControllers>();
        activeWeapon = GetComponent<ActiveWeapon>();
        myAnimator = GetComponent<Animator>();
        playerControls = new PlayerControls();

        // ����ݩ`�ͥ�Ȥγ��ڻ������å�
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
        // ����ץåȥ����������Є���
        playerControls.Enable();
    }

    private void OnDisable()
    {
        // ����ץåȥ���������o����
        playerControls.Disable();
    }

    private void Start()
    {
        // ����ץåȥ��������˥��`��Хå����O��
        playerControls.Combat.Attack.started += _ => StartAttacking();
        playerControls.Combat.Attack.canceled += _ => StopAttacking();
    }

    private void Update()
    {
        MouseFollowWithOffset(); // �������򤭤�ޥ����˺Ϥ碌��
        Attack(); // ���ĄI��
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
        // ���ĥܥ���Ѻ���졢�����ФǤʤ����Ϥ˹��Ĥ��_ʼ
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
        // playerControllers�����������ڻ�����Ƥ��뤫�_�J
        if (playerControllers == null)
        {
            Debug.LogError("PlayerControllers is not assigned in MouseFollowWithOffset.");
            return;
        }

        // Camera.main��null�Ǥʤ����_�J
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
