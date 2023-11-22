using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject rocketPrefab;
    public GameObject laserPrefab;

    private EProjectileType currentProjectileType = EProjectileType.Bullet;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            ShootProjectile();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1)) currentProjectileType = EProjectileType.Bullet;
        if (Input.GetKeyDown(KeyCode.Alpha2)) currentProjectileType = EProjectileType.Rocket;
        if (Input.GetKeyDown(KeyCode.Alpha3)) currentProjectileType = EProjectileType.Laser;
    }

    void ShootProjectile()
    {
        if (currentProjectileType.HasFlag(EProjectileType.Bullet))
        {
            Instantiate(bulletPrefab, transform.position, transform.rotation);
        }
        if (currentProjectileType.HasFlag(EProjectileType.Rocket))
        {
            Instantiate(rocketPrefab, transform.position, transform.rotation);
        }
        if (currentProjectileType.HasFlag(EProjectileType.Laser))
        {
            Instantiate(laserPrefab, transform.position, transform.rotation);
        }
    }
}
