using UnityEngine;

public class TankTurretController : MonoBehaviour
{
    public Transform turretBase;       
    public Transform cameraTransform; 

    public float rotationSpeed = 2f;
    public float maxTurretAngle = 70f;
    public float minTurretAngle = -10f;
    public float maxHorizontalAngle = 70f;
    public float minHorizontalAngle = -70f;

    public float maxCameraVerticalAngle = 60f;
    public float minCameraVerticalAngle = -30f;
    public float maxCameraHorizontalAngle = 90f;
    public float minCameraHorizontalAngle = -90f;

    private float currentTurretAngle = 0f;    
    private float currentHorizontalAngle = 0f;
    private float cameraVerticalAngle = 0f;
    private float cameraHorizontalAngle = 0f;

    void Update()
    {
        float verticalInput = Input.GetAxis("Mouse Y");
        float horizontalInput = Input.GetAxis("Mouse X");

        cameraVerticalAngle -= verticalInput * rotationSpeed;
        cameraVerticalAngle = Mathf.Clamp(cameraVerticalAngle, minCameraVerticalAngle, maxCameraVerticalAngle);

        cameraHorizontalAngle += horizontalInput * rotationSpeed;
        cameraHorizontalAngle = Mathf.Clamp(cameraHorizontalAngle, minCameraHorizontalAngle, maxCameraHorizontalAngle);

        currentTurretAngle -= verticalInput * rotationSpeed;
        currentTurretAngle = Mathf.Clamp(currentTurretAngle, minTurretAngle, maxTurretAngle);

        float desiredHorizontalAngle = currentHorizontalAngle + horizontalInput * rotationSpeed;

        if (desiredHorizontalAngle > maxHorizontalAngle || desiredHorizontalAngle < minHorizontalAngle)
        {
        }
        else
        {
            currentHorizontalAngle = desiredHorizontalAngle;
        }

        turretBase.localRotation = Quaternion.Euler(currentTurretAngle, 0f, currentHorizontalAngle);

        cameraTransform.localRotation = Quaternion.Euler(cameraVerticalAngle, cameraHorizontalAngle, 0f);
    }
}
