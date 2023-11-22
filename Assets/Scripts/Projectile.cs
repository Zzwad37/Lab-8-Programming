using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public EProjectileType type;
    public float damage = 10f; // Default damage value, can be adjusted for each type

    void Start()
    {
        // Adjusting behaviors based on projectile type
        switch (type)
        {
            case EProjectileType.Bullet:
                speed = 20f; // Faster speed for bullets
                damage = 5f; // Less damage for bullets
                break;
            case EProjectileType.Rocket:
                speed = 10f; // Standard speed for rockets
                damage = 20f; // Higher damage for rockets
                // Additional rocket-specific initialization, like trail effects
                break;
            case EProjectileType.Laser:
                speed = 30f; // Very fast for laser
                damage = 8f; // Moderate damage for laser
                // Additional laser-specific initialization, like continuous effects
                break;
        }
    }

    void Update()
    {
        // Move the projectile forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Handle collision with different objects
        // Example: If the projectile hits an enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Reduce enemy health by this projectile's damage
            // Assuming the enemy has a script with a TakeDamage method
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
        }

        // Special effect for rockets (like explosion)
        if (type == EProjectileType.Rocket)
        {
            // Trigger explosion effect here
        }

        // Destroy the projectile after collision
        Destroy(gameObject);
    }
}
