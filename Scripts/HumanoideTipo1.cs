using UnityEngine;

public class HumanoideTipo1 : MonoBehaviour
{
    public Transform escudoSeleccionado;   
    public float speed = 3.0f;
    public float distanciaParada = 1.0f;   

    private Transform objetivo;            
    private float paradaActual;            

    void OnEnable()
    {
        CuboNotificador.OnTocaTipo2 += IrAlEscudoSeleccionado;
        CuboNotificador.OnTocaTipo1 += IrAlEscudoTipo2MasCercano;
    }

    void OnDisable()
    {
        CuboNotificador.OnTocaTipo2 -= IrAlEscudoSeleccionado;
        CuboNotificador.OnTocaTipo1 -= IrAlEscudoTipo2MasCercano;
    }

    void Start()
    {
        if (escudoSeleccionado == null)
        {
            GameObject e = GameObject.FindWithTag("Escudo1");
            if (e != null) escudoSeleccionado = e.transform;
            else Debug.LogError(gameObject.name + ": no hay ningún escudo con la etiqueta 'Escudo1'");
        }
    }

    void IrAlEscudoSeleccionado()
    {
        objetivo = escudoSeleccionado;
        paradaActual = distanciaParada;    
    }
    void IrAlEscudoTipo2MasCercano()
    {
        objetivo = EscudoTipo2MasCercano();
        paradaActual = 0.0f;               
    }

    Transform EscudoTipo2MasCercano()
    {
        GameObject[] escudos = GameObject.FindGameObjectsWithTag("Escudo2");
        Transform masCercano = null;
        float menorDistancia = Mathf.Infinity;

        foreach (GameObject e in escudos)
        {
            float d = Vector3.Distance(transform.position, e.transform.position);
            if (d < menorDistancia)
            {
                menorDistancia = d;
                masCercano = e.transform;
            }
        }
        return masCercano;
    }

    void Update()
    {
        if (objetivo == null) return;      

        Vector3 destino = objetivo.position;
        destino.y = transform.position.y;

        if (Vector3.Distance(transform.position, destino) > paradaActual)
        {
            transform.LookAt(destino);
            transform.position = Vector3.MoveTowards(transform.position, destino, speed * Time.deltaTime);
        }
    }
}