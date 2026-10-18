using UnityEngine;

public class Ejercicio3_CuboNotificador : MonoBehaviour {
    public  delegate void mensaje();
    public event mensaje OnEventoPersonaje1;
    public event mensaje OnEventoPersonaje2;
  void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.tag == "Tipo1") {
        OnEventoPersonaje2();
    } else if (collision.gameObject.tag == "Tipo2") {
        OnEventoPersonaje1();
    }
  }
}
