using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 50f; // Швидкість польоту снаряда
    public float explosionRadius = 5f; // Радіус вибуху
    public float explosionForce = 2f; // Сила вибуху
    public GameObject explosionEffect; // Префаб ефекту вибуху

    void Start()
    {
        // Задаємо початкову швидкість руху снаряда
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = transform.up * speed;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Створення ефекту вибуху
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }

        // Застосування сили вибуху до об'єктів в радіусі
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }
        }

        // Знищення снаряда
        Destroy(gameObject);
    }
}
