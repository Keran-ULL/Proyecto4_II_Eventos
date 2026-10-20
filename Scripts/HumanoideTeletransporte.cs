using UnityEngine;

public class HumanoideTeletransporte : MonoBehaviour
{
    public Transform escudoObjetivo;                        
    public Vector3 desplazamiento = new Vector3(0, 0, 1.5f); 
    void OnEnable()  { ObjetoReferencia.OnCuboCerca += Teletransportar; }
    void OnDisable() { ObjetoReferencia.OnCuboCerca -= Teletransportar; }

    void Teletransportar()
    {
        if (escudoObjetivo == null)
        {
            Debug.LogError(gameObject.name + ": falta asignar el escudo objetivo");
            return;
        }

        Vector3 destino = escudoObjetivo.position + desplazamiento;
        destino.y = transform.position.y;          

        transform.position = destino;              
        Debug.Log(gameObject.name + " se ha teletransportado al escudo");
    }
}