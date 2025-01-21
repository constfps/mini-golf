using System;
using com.cyborgAssets.inspectorButtonPro;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    public bool thrusting = true;
    public float duration;

    [SerializeField]
    public Vector3 endPos;
    [SerializeField]
    public Vector3 startPos;

    [ProButton]
    public void setEndPos()
    {
        endPos = transform.localPosition;
    }
    
    [ProButton]
    public void setStartPos()
    {
        startPos = transform.localPosition;
    }

    private void Start()
    {
        if (thrusting)
        {
            Vector3.Lerp(startPos, endPos, Time.deltaTime / duration);
            if (endPos.Equals(transform.localPosition))
            {
                thrusting = false;
            }
        } else
        {
            Vector3.Lerp(endPos, startPos, Time.deltaTime / duration);
            if (startPos.Equals(transform.localPosition))
            {
                thrusting = true;
            }
        }
    }
}
