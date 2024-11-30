using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMove : MonoBehaviour
{
    public Transform bodyTank; // Силка на дочірній об'єкт BodyTank
    public float tiltAngle = 5f; // Максимальний кут нахилу (в градусах)
    public float tiltSpeed = 2f; // Швидкість зміни нахилу
    public float moveForce = 10f; // Сила розгону
    public float maxSpeed = 20f; // Максимальна швидкість

    private Rigidbody rb;
    private float targetTiltAngle = 0f; // Поточний цільовий нахил

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Отримуємо напрямок руху (W/S)
        float moveDirection = Input.GetAxis("Vertical");

        // Рух вперед/назад
        if (moveDirection != 0)
        {
            Vector3 force = transform.forward * moveDirection * moveForce;

            if (rb.velocity.magnitude < maxSpeed)
            {
                rb.AddForce(force, ForceMode.Acceleration);
            }

            // Встановлюємо цільовий нахил
            targetTiltAngle = -moveDirection * tiltAngle;
        }
        else
        {
            // Якщо немає введення, поступово повертаємо об'єкт у нормальне положення
            targetTiltAngle = 0f;
        }

        // Плавний перехід до цільового кута
        float currentTiltAngle = Mathf.LerpAngle(bodyTank.localEulerAngles.x, targetTiltAngle, Time.deltaTime * tiltSpeed);

        // Застосовуємо нахил
        bodyTank.localRotation = Quaternion.Euler(currentTiltAngle, bodyTank.localEulerAngles.y, bodyTank.localEulerAngles.z);
    }

    
}
