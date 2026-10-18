using UnityEngine;

public class Ejercicio1_BolaVerde : MonoBehaviour {
  public Ejercicio1_CilindroNotificador notificador;
  public float velocidad;
  private bool moverse; 
  void Start() {
    moverse = false;
    notificador.OnAlcanzadoPorCubo += respuestaBolaVerde;
  }
  void Update() {
    if (moverse) {
      transform.Translate((notificador.transform.position - transform.position).normalized * velocidad * Time.deltaTime);
    }
  }
  void respuestaBolaVerde() {
    moverse = true;
  }
}
