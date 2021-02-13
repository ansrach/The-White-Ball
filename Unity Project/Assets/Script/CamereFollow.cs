using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamereFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed;
    public Vector3 offset;
    void LateUpdate()
    {
        //Vector3 desiredPosition = target.position + offset;
        Vector3 desiredPosition = new Vector3(target.position.x, transform.position.y, transform.position.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        //transform.LookAt(target);
    }
}
