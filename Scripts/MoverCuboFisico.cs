using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MoverCuboFisico : MonoBehaviour
{
    public float fuerza = 20.0f;            
    public float velocidadMaxima = 5.0f; 

    private Rigidbody rb;
    private Vector3 direccion;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;    
        rb.useGravity = true;      
        rb.linearDamping = 1.0f;   
    }                              

    void Update()
    {
        direccion = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
    }

    void FixedUpdate()
    {
        rb.AddForce(direccion * fuerza);

        Vector3 v = rb.linearVelocity;               
        Vector3 horizontal = new Vector3(v.x, 0, v.z);

        if (horizontal.magnitude > velocidadMaxima)
        {
            horizontal = horizontal.normalized * velocidadMaxima;
            rb.linearVelocity = new Vector3(horizontal.x, v.y, horizontal.z);
        }
    }
}