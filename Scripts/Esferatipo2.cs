using UnityEngine;

public class Esferatipo2 : MonoBehaviour
{
    public Cilindro cilindro;            
    public float speed = 2.0f;
    public float distanciaParada = 1.5f;

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
        Debug.Log(gameObject.name + " (tipo 2) va hacia el cilindro");
        enMovimiento = true;
    }

    void Update()
    {
        if (!enMovimiento) return;

        Vector3 destino = cilindro.transform.position;
        destino.y = transform.position.y;

        if (Vector3.Distance(transform.position, destino) > distanciaParada)
        {
            transform.LookAt(destino);  
            transform.position = Vector3.MoveTowards(transform.position, destino, speed * Time.deltaTime);
        }
    }
}