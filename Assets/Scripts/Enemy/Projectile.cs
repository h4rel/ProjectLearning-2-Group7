using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 22f;
    [SerializeField] private GameObject particleOnHitPrefabVFX;
    [SerializeField] private bool isEnemyProjectile = false;
    [SerializeField] private float projectileRange = 10f;

    private Vector3 startPosition;
    private Rigidbody2D rb;

    private void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component is missing on the projectile.");
        }
    }

    private void Update()
    {
        MoveProjectile();
        DetectFireDistance();
    }

    public void UpdateProjectileRange(float projectileRange)
    {
        this.projectileRange = projectileRange;
    }

    public void UpdateMoveSpeed(float moveSpeed)
    {
        this.moveSpeed = moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Projectile hit something: " + other.gameObject.name);

        EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
        PlayerHealth player = other.gameObject.GetComponent<PlayerHealth>();

        if (!other.isTrigger)
        {
            if (player != null && isEnemyProjectile)
            {
                Debug.Log("Projectile hit a player: " + player.gameObject.name);
                player.TakeDamage(1, transform);
                PlayHitEffectAndDestroy();
            }
            else if (enemyHealth != null && !isEnemyProjectile)
            {
                Debug.Log("Projectile hit an enemy: " + enemyHealth.gameObject.name);
                enemyHealth.TakeDamage(1);
                PlayHitEffectAndDestroy();
            }
            else
            {
                Debug.Log("Projectile hit something else.");
                PlayHitEffectAndDestroy();
            }
        }
    }

    private void PlayHitEffectAndDestroy()
    {
        if (particleOnHitPrefabVFX != null)
        {
            GameObject vfx = Instantiate(particleOnHitPrefabVFX, transform.position, transform.rotation);
            Destroy(vfx, 1f); // ¥Ñ©`¥Æ¥£¥¯¥ë¥¨¥Õ¥§¥¯¥È¤ò1Ãëáá¤ËÆÆ‰²£¨±ØÒª¤Ëê¤¸¤Æ‰ä¸ü£©
        }
        Destroy(gameObject); // ¥×¥í¥¸¥§¥¯¥¿¥¤¥ë¤òÆÆ‰²
    }

    private void DetectFireDistance()
    {
        if (Vector3.Distance(transform.position, startPosition) > projectileRange)
        {
            Destroy(gameObject);
        }
    }

    private void MoveProjectile()
    {
        if (rb != null)
        {
            rb.velocity = transform.right * moveSpeed;
        }
        else
        {
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        }
    }
}
