using UnityEngine;
using TMPro;

public class RecolectorEscudos3 : MonoBehaviour
{
    [Header("Puntos")]
    public int puntosEscudo1 = 5;
    public int puntosEscudo2 = 10;
    public int puntuacion = 0;

    [Header("Recompensas")]
    public int puntosPorRecompensa = 100;      
    public int recompensas = 0;                
    public float duracionMensaje = 3.0f;       

    [Header("Interfaz")]
    public TextMeshProUGUI textoPuntuacion;    
    public TextMeshProUGUI textoRecompensas;   
    public TextMeshProUGUI textoAviso;         

    private int siguienteRecompensa;           
    private float tiempoAviso = 0.0f;          

    void Start()
    {
        siguienteRecompensa = puntosPorRecompensa;
        if (textoAviso != null) textoAviso.text = "";   
        ActualizarTextos();
    }

    void Update()
    {
        if (tiempoAviso > 0)
        {
            tiempoAviso -= Time.deltaTime;
            if (tiempoAviso <= 0 && textoAviso != null)
                textoAviso.text = "";
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Recoger(other.gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        Recoger(collision.collider.gameObject);
    }

    void Recoger(GameObject tocado)
    {
        GameObject escudo = BuscarConEtiqueta(tocado);
        if (escudo == null) return;

        if (escudo.CompareTag("Escudo1"))
            puntuacion += puntosEscudo1;
        else
            puntuacion += puntosEscudo2;

        Debug.Log("Recogido " + escudo.name + ". Puntuación: " + puntuacion);

        ComprobarRecompensa();
        ActualizarTextos();

        Destroy(escudo);
    }

    void ComprobarRecompensa()
    {
        while (puntuacion >= siguienteRecompensa)
        {
            recompensas++;
            Debug.Log("¡Recompensa por llegar a " + siguienteRecompensa + " puntos! Total: " + recompensas);

            if (textoAviso != null)
            {
                textoAviso.text = "¡Recompensa! Has llegado a " + siguienteRecompensa + " puntos";
                tiempoAviso = duracionMensaje;
            }

            siguienteRecompensa += puntosPorRecompensa;   
        }
    }

    void ActualizarTextos()
    {
        if (textoPuntuacion != null)
            textoPuntuacion.text = "Puntuación: " + puntuacion;

        if (textoRecompensas != null)
            textoRecompensas.text = "Recompensas: " + recompensas;
    }

    GameObject BuscarConEtiqueta(GameObject obj)
    {
        Transform t = obj.transform;
        while (t != null)
        {
            if (t.CompareTag("Escudo1") || t.CompareTag("Escudo2"))
                return t.gameObject;
            t = t.parent;
        }
        return null;
    }
}