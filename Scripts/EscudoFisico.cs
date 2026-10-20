using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EscudoFisico : MonoBehaviour
{
    public Color colorAlChocar = Color.yellow;

    void OnCollisionEnter(Collision collision)
    {
        GameObject otro = collision.gameObject;

        if (otro.CompareTag("Tipo1") || otro.CompareTag("Tipo2"))
        {
            Debug.Log(otro.name + " ha chocado con el escudo " + gameObject.name);

            foreach (Renderer r in GetComponentsInChildren<Renderer>())
            {
                r.material.color = colorAlChocar;
            }
        }
    }
}