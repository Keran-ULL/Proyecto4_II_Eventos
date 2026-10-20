using UnityEngine;

public class CuboNotificador : MonoBehaviour
{
    public delegate void Mensaje();

    public static event Mensaje OnTocaTipo1;   
    public static event Mensaje OnTocaTipo2;   

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Tipo1"))
        {
            Debug.Log("Cubo toca a un tipo 1 -> los tipo 2 van a los escudos de tipo 2");
            OnTocaTipo1?.Invoke();
        }
        else if (collision.gameObject.CompareTag("Tipo2"))
        {
            Debug.Log("Cubo toca a un tipo 2 -> los tipo 1 van al escudo seleccionado");
            OnTocaTipo2?.Invoke();
        }
    }
}