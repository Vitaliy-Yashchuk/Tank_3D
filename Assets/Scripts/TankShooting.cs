using UnityEngine;

public class TankShooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float fireRate = 3f;
    private float nextFireTime = 0f;
    public Rigidbody tankRigidbody;
    public float recoilForce = 20f;

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= nextFireTime)
        {
            Fire();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void Fire()
    {
        if (projectilePrefab != null && firePoint != null)
        {
            Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            
            if (tankRigidbody != null)
            {
                Vector3 recoilDirection = -firePoint.up;
                tankRigidbody.AddForce(recoilDirection * recoilForce, ForceMode.Impulse);
                
            }
        }
        else
        {
            Debug.LogWarning("Projectile Prefab або Fire Point не призначені!");
        }
    }
    
}