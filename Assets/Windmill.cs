using UnityEngine;

public class Windmill : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, Time.deltaTime * 180f * 2f, Space.Self);
    }
}
