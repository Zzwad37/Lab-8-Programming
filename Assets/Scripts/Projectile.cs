using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public EProjectileType type;
    private float lifetime;

    void Start()
    {
        switch (type)
        {
            case EProjectileType.Bullet:
                speed *= 2; 
                lifetime = 2f; 
                break;
            case EProjectileType.Rocket:
                GetComponent<Rigidbody>().AddForce(new Vector3(0, 10f, 0), ForceMode.Impulse); 
                lifetime = 4f; 
                break;
            case EProjectileType.Laser:
                speed *= 3; 
                lifetime = 6f; 
                break;
        }

        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (type == EProjectileType.Rocket)
        {

            Collider[] colliders = Physics.OverlapSphere(transform.position, 5f); 
            foreach (var hitCollider in colliders)
            {
                if (hitCollider.attachedRigidbody != null)
                {
                    hitCollider.attachedRigidbody.AddExplosionForce(500f, transform.position, 5f); 
                }
            }
        }

        if (type != EProjectileType.Laser)
        {
            Destroy(gameObject);
        }
    }
}
