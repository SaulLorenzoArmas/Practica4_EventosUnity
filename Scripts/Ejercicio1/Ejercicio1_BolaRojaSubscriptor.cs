using UnityEngine;

public class Ejercicio1_BolaRoja : MonoBehaviour {
  public Ejercicio1_CilindroNotificador notificador;
  // Al hacerlos asi solos los que tengan el script de la bola verde 
  // podran selecionarse.
  public Ejercicio1_BolaVerde bolaAperseguir;
  public float velocidad;
  private bool perseguir; 
  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start() {
    perseguir = false;
    notificador.OnAlcanzadoPorCubo += respuestaBolaRoja;
  }
  // Update is called once per frame
  void Update() {
    if (perseguir) {
      transform.Translate((bolaAperseguir.transform.position - transform.position).normalized * velocidad * Time.deltaTime);
    }
  }
  void respuestaBolaRoja() {
    perseguir = true;
  }
}
