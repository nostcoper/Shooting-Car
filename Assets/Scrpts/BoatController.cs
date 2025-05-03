using UnityEngine;

public class BoatController : MonoBehaviour
{
    public float turnSpeed;
    public float acelerateSpeed;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.angularDamping = 0.5f;
        rb.maxAngularVelocity = 2f;
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        rb.AddTorque(0f, h * turnSpeed * Time.deltaTime, 0f);

        if (Mathf.Abs(v) > 0.01f)
        {
            rb.AddForce(transform.forward * v * acelerateSpeed * Time.deltaTime);
        }
        else
        {
            Vector3 horizontalVelocity = rb.linearVelocity;
            horizontalVelocity.y = 0; 

            Vector3 brakeForce = -horizontalVelocity * 2f;
            rb.AddForce(brakeForce, ForceMode.Acceleration);
        }

    }
}