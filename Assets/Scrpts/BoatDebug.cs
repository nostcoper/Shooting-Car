using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BoatDebug : MonoBehaviour
{
    [Header("Debug Settings")]
    public bool showDebugUI = false;
    public bool showForceVectors = false;
    
    [Header("UI References")]
    public Canvas debugCanvas;
    public TextMeshProUGUI speedText;
    public TextMeshProUGUI rotationText;
    
    private Rigidbody rb;
    private BoatController controller;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        controller = GetComponent<BoatController>();
        
        // Create debug UI if set to show and not already available
        SetupDebugUI();
    }
    
    private void SetupDebugUI()
    {
        if (showDebugUI && debugCanvas == null)
        {
            // This is just a placeholder for UI creation
            // In a real implementation, you would create UI elements here
            Debug.Log("Debug UI would be created here");
        }
        
        // Toggle existing UI if it exists
        if (debugCanvas != null)
        {
            debugCanvas.gameObject.SetActive(showDebugUI);
        }
    }
    
    private void Update()
    {
        if (showDebugUI)
        {
            UpdateDebugDisplay();
        }
        
        if (showForceVectors)
        {
            DrawForceVectors();
        }
    }
    
    private void UpdateDebugDisplay()
    {
        if (speedText != null)
        {
            speedText.text = $"Speed: {rb.linearVelocity.magnitude:F1} m/s";
        }
        
        if (rotationText != null)
        {
            rotationText.text = $"Rotation: {rb.angularVelocity.y:F1} rad/s";
        }
    }
    
    private void DrawForceVectors()
    {
        // Forward velocity
        Debug.DrawRay(transform.position, rb.linearVelocity, Color.green);
        
        // Angular velocity
        Debug.DrawRay(transform.position, rb.angularVelocity, Color.red);
        
        // Up direction
        Debug.DrawRay(transform.position, transform.up * 2, Color.blue);
    }
}