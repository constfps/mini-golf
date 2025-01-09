using UnityEngine;

public class GolfBallController : MonoBehaviour
{
    private float maxPower = 50f;
    private float screenWorldConversionFactor = 0.002f;
    private float velocityThreshold = 1f;
    private float currentPower;

    public LineRenderer lineRenderer;
    public Rigidbody rb;
    public bool isStopped = true;

    public Vector3 startShotPos;
    public Vector3 shotDirection;

    public int shotsTaken = 0;

    private void Update()
    {
        if (Mathf.Abs(rb.velocity.y) < 0.0001f && rb.velocity.magnitude < velocityThreshold)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            isStopped = true;
        }

        if (Input.GetMouseButtonDown(0) && isStopped)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    StartAiming();
                }
            }
        }

        if (Input.GetMouseButton(0) && isStopped)
        {
            Aim();
        }

        if (Input.GetMouseButtonUp(0) && isStopped)
        {
            Shoot();
        }
    }

    private void StartAiming()
    {
        
    }

    private void Aim()
    {

    }

    private void Shoot()
    {

    }
}
