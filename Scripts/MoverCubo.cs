using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MoverCubo : MonoBehaviour
{
    public float speed = 5.0f;

    private Rigidbody rb;
    private Vector3 direccion;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;   
    }

    void Update()
    {
        direccion = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
    }

    void FixedUpdate()
    {
        Vector3 v = direccion * speed;
        v.y = rb.linearVelocity.y;      
        rb.linearVelocity = v;
    }
}
