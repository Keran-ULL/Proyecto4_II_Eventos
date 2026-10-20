using UnityEngine;

public class Cilindro : MonoBehaviour
{
    public delegate void MensajeColision();

    public event MensajeColision OnCuboChoca;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cubo"))
        {
            Debug.Log("El cubo ha chocado con el cilindro: envío el mensaje");
            OnCuboChoca?.Invoke();
        }
    }
}