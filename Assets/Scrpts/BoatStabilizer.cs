using UnityEngine;

public class BoatStabilizer : MonoBehaviour
{
    [Header("Stabilization Settings")]
    [Tooltip("How strongly to limit maximum tilt")]
    [Range(0f, 10f)]
    public float autoStabilizationStrength = 3.0f;
    
    [Tooltip("Maximum allowed tilt in degrees")]
    [Range(10f, 90f)]
    public float maxTiltAngle = 45.0f;
    
    [Tooltip("Visual debug of stabilization forces")]
    public bool showDebugVisuals = false;
    
    private Rigidbody rb;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    private void FixedUpdate()
    {
        // Only apply stabilization if we're significantly tilted
        if (IsExcessivelyTilted())
        {
            ApplyStabilizationForce();
        }
    }
    
    private bool IsExcessivelyTilted()
    {
        // Check if our current rotation exceeds the maximum tilt angle
        float currentTiltX = Mathf.Abs(Vector3.Angle(transform.up, Vector3.up) - 180f);
        float currentTiltZ = Mathf.Abs(Vector3.Angle(transform.right, Vector3.right) - 90f);
        
        return currentTiltX > maxTiltAngle || currentTiltZ > maxTiltAngle;
    }
    
    private void ApplyStabilizationForce()
    {
        // Calculate the rotation needed to get back to level
        Quaternion targetRotation = Quaternion.FromToRotation(transform.up, Vector3.up) * transform.rotation;
        
        // Get the rotation difference
        Quaternion rotationDifference = targetRotation * Quaternion.Inverse(transform.rotation);
        
        // Convert to axis-angle representation
        rotationDifference.ToAngleAxis(out float angle, out Vector3 axis);
        
        // Normalize angle (ToAngleAxis can return large angles)
        if (angle > 180f)
        {
            angle -= 360f;
        }
        
        // Apply a torque to stabilize the boat
        Vector3 stabilizingTorque = axis * (angle * Mathf.Deg2Rad) * autoStabilizationStrength;
        rb.AddTorque(stabilizingTorque, ForceMode.Acceleration);
        
        // Visualize the stabilizing force
        if (showDebugVisuals)
        {
            Debug.DrawRay(transform.position, stabilizingTorque.normalized * 2f, Color.yellow);
        }
    }
}