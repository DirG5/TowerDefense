using System.Collections;
using UnityEngine;

public class TurretAttackingState : State
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform projectileSpawnPosition;

    private IEnumerator ShootProjectile()
    {
        Instantiate(projectile, projectileSpawnPosition.position, Quaternion.identity);
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(ShootProjectile());
    }

    private void OnEnable()
    {
        StartCoroutine(ShootProjectile());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
