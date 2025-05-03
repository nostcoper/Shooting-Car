using UnityEngine;

public class BoatController : MonoBehaviour
{
    public float turnSpeed = 1000f;
    public float acelerateSpeed = 1000f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.angularDamping = 2f;
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        rb.AddTorque(0f, h * turnSpeed * Time.deltaTime, 0f);

        if (Mathf.Abs(v) > 0.01f)
        {
            // Si hay input, aplicamos fuerza normalmente
            rb.AddForce(transform.forward * v * acelerateSpeed * Time.deltaTime);
        }
        else
        {
            // Si NO hay input, frenamos el bote aplicando resistencia al movimiento
            Vector3 horizontalVelocity = rb.linearVelocity;
            horizontalVelocity.y = 0; // evitamos afectar el eje vertical

            Vector3 brakeForce = -horizontalVelocity * 0.5f; // puedes ajustar la intensidad
            rb.AddForce(brakeForce, ForceMode.Acceleration);
        }

    }
}
