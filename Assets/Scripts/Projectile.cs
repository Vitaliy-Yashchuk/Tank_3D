using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 50f; 
    public float explosionRadius = 5f; 
    public float explosionForce = 2f; 
    public GameObject explosionEffect; 
    public GameObject StartExplosionEffect;

    void Start()
    {
        if (StartExplosionEffect != null)
        {
            Instantiate(StartExplosionEffect, transform.position, Quaternion.identity);
        }
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = transform.up * speed;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }
        }
        Destroy(gameObject);
    }
}
