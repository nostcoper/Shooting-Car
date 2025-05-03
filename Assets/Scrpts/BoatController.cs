using UnityEngine;

public class BoatController : MonoBehaviour
{
    public float fuerza = 500f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.forward * fuerza);
        }
    }
}
