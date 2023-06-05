using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraFollow : MonoBehaviour
{

    public Transform target; // The target that the camera should follow (i.e., your player)
    public Vector3 offset; // The offset at which the camera will follow the target
    public float smoothSpeed = 0.125f; // The speed with which the camera will follow the player.

    void LateUpdate()
    {
        // Transform the offset from the player's local space to world space
        Vector3 worldOffset = target.TransformDirection(offset);

        // Calculate the desired position
        Vector3 desiredPosition = target.position + worldOffset;

        // Smoothly interpolate between the camera's current position and the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Make sure the camera is always looking at the target
        transform.LookAt(target);
    }




}
