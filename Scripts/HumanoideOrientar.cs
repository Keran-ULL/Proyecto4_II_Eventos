using UnityEngine;

public class HumanoideOrientar : MonoBehaviour
{
    public Transform objetoAMirar;   
    void OnEnable()  { ObjetoReferencia.OnCuboCerca += Orientarse; }
    void OnDisable() { ObjetoReferencia.OnCuboCerca -= Orientarse; }

    void Orientarse()
    {
        if (objetoAMirar == null)
        {
            Debug.LogError(gameObject.name + ": falta asignar el objeto al que mirar");
            return;
        }

        Vector3 punto = objetoAMirar.position;
        punto.y = transform.position.y;

        transform.LookAt(punto);
        Debug.Log(gameObject.name + " se ha orientado hacia " + objetoAMirar.name);
    }
}