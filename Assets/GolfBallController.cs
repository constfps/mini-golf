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
        currentPower = 0f;
        lineRenderer.enabled = true;
        startShotPos = Input.mousePosition;
    }

    private void Aim()
    {
        Vector3 mouseScreePosition = Input.mousePosition;
        float distance = Vector3.Distance(startShotPos, mouseScreePosition);
        currentPower = Mathf.Clamp(distance * screenWorldConversionFactor * maxPower, 0f, maxPower);

        Vector3 screenDirection = mouseScreePosition - startShotPos;
        shotDirection = new Vector3(screenDirection.x, 0f, screenDirection.y);
        shotDirection = Quaternion.AngleAxis(Camera.main.transform.eulerAngles.y, Vector3.up) * shotDirection;

        shotDirection.Normalize();

        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, transform.position + shotDirection * currentPower * 0.2f);
    }

    private void Shoot()
    {
        rb.AddForce(-shotDirection * currentPower, ForceMode.Impulse);
        isStopped = false;
        currentPower = 0f;
        lineRenderer.enabled = false;

        shotsTaken++;
    }
}
