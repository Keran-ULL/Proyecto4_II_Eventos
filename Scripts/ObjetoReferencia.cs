using UnityEngine;

public class ObjetoReferencia : MonoBehaviour
{
    public delegate void Mensaje();
    public static event Mensaje OnCuboCerca;

    public Transform cubo;                 
    public float distanciaAviso = 3.0f;    

    private bool cercaAntes = false;       

    void Start()
    {
        if (cubo == null)
        {
            GameObject c = GameObject.FindWithTag("Cubo");
            if (c != null) cubo = c.transform;
            else Debug.LogError("No hay ningún objeto con la etiqueta 'Cubo'");
        }
    }

    void Update()
    {
        if (cubo == null) return;

        bool cercaAhora = Vector3.Distance(cubo.position, transform.position) < distanciaAviso;

        if (cercaAhora && !cercaAntes)
        {
            Debug.Log("El cubo se ha acercado al objeto de referencia: envío el mensaje");
            OnCuboCerca?.Invoke();
        }

        cercaAntes = cercaAhora;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, distanciaAviso);
    }
}