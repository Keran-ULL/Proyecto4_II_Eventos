using UnityEngine;

public class HumanoideTipo2 : MonoBehaviour
{
    public float speed = 2.0f;

    private Transform objetivo;
    private bool enMovimiento = false;

    void OnEnable()  { CuboNotificador.OnTocaTipo1 += IrAEscudosTipo2; }
    void OnDisable() { CuboNotificador.OnTocaTipo1 -= IrAEscudosTipo2; }

    void IrAEscudosTipo2()
    {
        objetivo = EscudoMasCercano();
        if (objetivo != null) enMovimiento = true;
    }

    Transform EscudoMasCercano()
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
        if (!enMovimiento) return;

        Vector3 destino = objetivo.position;
        destino.y = transform.position.y;

        transform.LookAt(destino);
        transform.position = Vector3.MoveTowards(transform.position, destino, speed * Time.deltaTime);
    }
}