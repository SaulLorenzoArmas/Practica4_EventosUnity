using UnityEngine;

public class Ejercicio1_MovimientoCubo : MonoBehaviour {
  public float velocidad;
  private Rigidbody componenteBody;
  private GameObject cilindro;
  private bool chocado;
  void Start() {
    chocado = false;
    componenteBody = GetComponent<Rigidbody>();
    cilindro = GameObject.FindWithTag("cilindro");
  }
  void FixedUpdate() {
    if (!chocado) {
      // Osea, esto lo que hace es coje el origen y el destino y la velocidad maxima
      // a la que se puede desplazar, y crea un vector nuevo con un cambio muy pequeño
      // con respecto al original.
      Vector3 nuevaPosicion = Vector3.MoveTowards(transform.position, cilindro.transform.position,  velocidad * Time.fixedDeltaTime);
      //Lo anterior es pq el MovePosition solo acepta posiciones absolutas
      componenteBody.MovePosition(nuevaPosicion);
    }
  }

  void OnTriggerEnter(Collider other) {
    if (other.gameObject == cilindro) {
      chocado = true;
    }
  }
}
