using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject rocketPrefab;
    public GameObject laserPrefab;

    private EProjectileType currentProjectileType = EProjectileType.Bullet;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left click
        {
            ShootProjectile();
        }

        // Switch projectile type (example key binds)
        if (Input.GetKeyDown(KeyCode.Alpha1)) currentProjectileType = EProjectileType.Bullet;
        if (Input.GetKeyDown(KeyCode.Alpha2)) currentProjectileType = EProjectileType.Rocket;
        if (Input.GetKeyDown(KeyCode.Alpha3)) currentProjectileType = EProjectileType.Laser;
    }

    void ShootProjectile()
    {
        GameObject projectilePrefab = null;

        switch (currentProjectileType)
        {
            case EProjectileType.Bullet:
                projectilePrefab = bulletPrefab;
                break;
            case EProjectileType.Rocket:
                projectilePrefab = rocketPrefab;
                break;
            case EProjectileType.Laser:
                projectilePrefab = laserPrefab;
                break;
        }

        if (projectilePrefab != null)
        {
            Instantiate(projectilePrefab, transform.position, transform.rotation);
        }
    }
}
