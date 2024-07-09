using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooters : MonoBehaviour //,IEnemy
{
    [SerializeField] private GameObject bulletPrefabs;
    [SerializeField] private float bulletMoveSpeed;
    [SerializeField] private int burstCount;
    [SerializeField] private float timeBetweenBursts;
    [SerializeField] private float restTime = 1f;

    private bool isShooting = false;

    public void Attacks()
    {
        if(!isShooting)
        {
            StartCoroutine(ShootRoutine());
        }
    }

    private IEnumerator ShootRoutine()
    {
        isShooting = true;

        for(int i = 0; i < burstCount; i++)
        {
            Vector2 targetDirection = PlayerControllers.Instance.transform.position - transform.position;

            GameObject newBullet = Instantiate(bulletPrefabs, transform.position, Quaternion.identity);
            newBullet.transform.right = targetDirection;

            if(newBullet.TryGetComponent(out Projectile projectile))
            {
                projectile.UpdateMoveSpeed(bulletMoveSpeed);
            }

            yield return new WaitForSeconds(timeBetweenBursts);
        }

        yield return new WaitForSeconds(restTime);
        isShooting = false;
    }
}
