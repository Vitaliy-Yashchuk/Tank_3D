using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankTurretController : MonoBehaviour
{
    public Transform turretBase; // Трансформ основи дула (танка)

    public float rotationSpeed = 2f;  // Швидкість обертання дула
    public float maxTurretAngle = 70f; // Максимальний кут для підйому дула
    public float minTurretAngle = -10f; // Мінімальний кут для опускання дула
    public float maxHorizontalAngle = 70f; // Максимальний горизонтальний кут для обертання дула
    public float minHorizontalAngle = -70f; // Мінімальний горизонтальний кут для обертання дула

    private float currentTurretAngle = 0f; // Поточний вертикальний кут нахилу дула
    private float currentHorizontalAngle = 0f; // Поточний горизонтальний кут нахилу дула

    void Update()
    {
        // Отримання вводу від миші для вертикального та горизонтального обертання дула
        float verticalInput = Input.GetAxis("Mouse Y");
        float horizontalInput = Input.GetAxis("Mouse X");

        // Обмеження вертикального кута нахилу дула
        currentTurretAngle -= verticalInput * rotationSpeed;
        currentTurretAngle = Mathf.Clamp(currentTurretAngle, minTurretAngle, maxTurretAngle);

        // Обмеження горизонтального кута обертання дула
        currentHorizontalAngle += horizontalInput * rotationSpeed;
        currentHorizontalAngle = Mathf.Clamp(currentHorizontalAngle, minHorizontalAngle, maxHorizontalAngle);

        // Оновлюємо обертання дула тільки по осях X (вертикально) і Y (горизонтально)
        turretBase.localRotation = Quaternion.Euler(currentTurretAngle, 0f, currentHorizontalAngle);
    }
}
