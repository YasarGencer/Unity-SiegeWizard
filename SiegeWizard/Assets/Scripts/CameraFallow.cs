using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFallow : MonoBehaviour
{
    private GameObject targetObject;
    public float smoothSpeed;
    public Vector3 cameraOffset = new Vector3(0,0,-10);
    //TimeManagerden veri alýr
    public bool move = true;

    private void Start()
    {
        targetObject = GameObject.FindGameObjectWithTag("Player");
    }
    private void FixedUpdate()
    {
        Vector3 desiredPosition = targetObject.transform.position + cameraOffset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.fixedDeltaTime);
        transform.position = smoothedPosition;
    }
}
