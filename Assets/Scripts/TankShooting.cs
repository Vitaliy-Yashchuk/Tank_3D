using UnityEngine;

public class TankShooting : MonoBehaviour
{
    public GameObject projectilePrefab; // Префаб снаряда
    public Transform firePoint; // Точка спавну снаряда
    public float fireRate = 1f; // Частота пострілів (пострілів за секунду)
    private float nextFireTime = 0f; // Час наступного пострілу

    void Update()
    {
        // Перевіряємо, чи натиснута ліва кнопка миші та чи пройшов час для наступного пострілу
        if (Input.GetMouseButtonDown(0) && Time.time >= nextFireTime)
        {
            Fire();
            OnDrawGizmos();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void Fire()
    {
        if (projectilePrefab != null && firePoint != null)
        {
            // Створюємо снаряд у точці спавну з поворотом firePoint
            Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        }
        else
        {
            Debug.LogWarning("Projectile Prefab або Fire Point не призначені!");
        }
    }
    void OnDrawGizmos()
    {
        if (firePoint != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(firePoint.position, 0.1f); // Малюємо сферу в місці спавну
        }
    }
}