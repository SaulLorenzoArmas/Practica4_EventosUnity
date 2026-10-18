using UnityEngine;

public class Ejercicio4_ObjetoReferenciaNotificador : MonoBehaviour {
    public delegate void mensaje();
    public event mensaje OnEstaCerca;
    public event mensaje OnEstaLejos;
    public Aux_Ejercicio4_MovimientoFisico cuboSeAcerca;
    private bool eventoDisparado;
  void Start() {
    eventoDisparado = false;
  }
  // Update is called once per frame
  void Update() {
        float distancia = Vector3.Distance(transform.position, cuboSeAcerca.gameObject.transform.position);
        if (distancia < 3f && !eventoDisparado) {
            eventoDisparado = true; 
            OnEstaCerca();
        } else if (distancia >= 3f && eventoDisparado) {
            eventoDisparado = false;
            OnEstaLejos();
        }
    }
}
