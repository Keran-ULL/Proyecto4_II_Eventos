using UnityEngine;

public class EsferaTipo1 : MonoBehaviour
{
    public Cilindro cilindro;            
    public Transform esferaObjetivo;     
    public float distanciaParada = 1.5f; 
    public float speed = 2.0f;
    private bool enMovimiento = false;

    void OnEnable()
    {
        if (cilindro == null) cilindro = FindFirstObjectByType<Cilindro>();

        if (cilindro != null)
            cilindro.OnCuboChoca += AlChocarCubo;
        else
            Debug.LogError(gameObject.name + ": no hay ningún Cilindro en la escena");
    }

    void OnDisable()
    {
        if (cilindro != null)
            cilindro.OnCuboChoca -= AlChocarCubo;
    }

    void AlChocarCubo()
    {
        Debug.Log(gameObject.name + " (tipo 1) va hacia " + esferaObjetivo.name);
        enMovimiento = true;
    }

    void Update()
    {
        if (!enMovimiento) return;

        Vector3 destino = esferaObjetivo.position;
        destino.y = transform.position.y;   
        if (Vector3.Distance(transform.position, destino) > distanciaParada)
        {
            transform.LookAt(destino);   
            transform.position = Vector3.MoveTowards(transform.position, destino, speed * Time.deltaTime);
        }
    }
}