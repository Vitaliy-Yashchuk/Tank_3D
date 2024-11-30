using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMove : MonoBehaviour
{
   public Transform bodyTank; // Силка на дочірній об'єкт BodyTank для нахилу
    public float moveForce = 10f; // Сила розгону
    public float maxSpeed = 20f; // Максимальна швидкість руху
    public float turnSpeed = 50f; // Швидкість повороту танка
    public float tiltAngle = 10f; // Максимальний нахил корпусу
    public float tiltSpeed = 2f; // Швидкість зміни нахилу

    private Rigidbody rb;
    private float targetTiltAngle = 0f; 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveDirection = Input.GetAxis("Vertical");

        if (moveDirection != 0)
        {
            Vector3 force = transform.forward * moveDirection * moveForce;

            if (rb.velocity.magnitude < maxSpeed)
            {
                rb.AddForce(force, ForceMode.Acceleration);
            }
            targetTiltAngle = -moveDirection * tiltAngle;
        }
        else
        {
            targetTiltAngle = 0f;
        }
        
        float turnDirection = Input.GetAxis("Horizontal");

        if (turnDirection != 0)
        {
            float turn = turnDirection * turnSpeed * Time.fixedDeltaTime;
            transform.Rotate(0, turn, 0);
        }
        
        float currentTiltAngle = Mathf.LerpAngle(bodyTank.localEulerAngles.x, targetTiltAngle, Time.deltaTime * tiltSpeed);
        
        bodyTank.localRotation = Quaternion.Euler(currentTiltAngle, bodyTank.localEulerAngles.y, bodyTank.localEulerAngles.z);
    }

    
}
