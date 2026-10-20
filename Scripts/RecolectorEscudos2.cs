using UnityEngine;
using TMPro;   

public class RecolectorEscudos2 : MonoBehaviour
{
    public int puntosEscudo1 = 5;
    public int puntosEscudo2 = 10;

    public int puntuacion = 0;

    public TextMeshProUGUI textoPuntuacion;   

    void Start()
    {
        ActualizarTexto();   
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

        Debug.Log("Recogido " + escudo.name + " (" + escudo.tag + "). Puntuación: " + puntuacion);
        ActualizarTexto();   
        Destroy(escudo);
    }

    void ActualizarTexto()
    {
        if (textoPuntuacion != null)
            textoPuntuacion.text = "Puntuación: " + puntuacion;
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