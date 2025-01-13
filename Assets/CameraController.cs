using System.Net.Mail;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float sensitivity = 2f;
    private float distance = 30f;
    private float minDistance = 20f;
    private float maxDistance = 50f;
    private float scrollInput;
    private float zoomSpeed = 5f;
    private float damping = 5f;
    private float yaw;

    private float pitch = 30f;
    private float minPitch = 20f;
    private float maxPitch = 90f;

    public Transform player;
    public Transform pivot;
    public Transform focalPoint;

    private Vector3 targetPosition;

    public GolfBallController golfBalController;

    private void Update()
    {
        scrollInput = Input.GetAxis("Mouse ScrollWheel");
        if (scrollInput != 0)
        {
            distance -= scrollInput * zoomSpeed;
            distance = Mathf.Clamp(distance, minDistance, maxDistance);
        }

        if (Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxis("Mouse X") * sensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

            yaw += mouseX;
            pitch += mouseY;
            pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

            transform.eulerAngles = new Vector3(pitch, yaw, 0f);
            pivot.eulerAngles = new Vector3(0f, yaw, 0f);
            transform.position = focalPoint.position - transform.forward * distance;
        }

        transform.eulerAngles = new Vector3(pitch, yaw, 0f);
        pivot.eulerAngles = new Vector3(0f, yaw, 0f);
        targetPosition = focalPoint.position - transform.forward * distance;
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * damping);
    }
}
