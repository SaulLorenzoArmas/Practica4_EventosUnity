using UnityEngine;

public class Ejercicio4_RespuestaGrupo1 : MonoBehaviour {
    public Ejercicio4_ObjetoReferenciaNotificador notificador;
    public GameObject escudoElegido;
    public Vector3 separacionEntrePersonajes;
    private Rigidbody componenteRigitBody;
    private Vector3 posicionInicial;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        notificador.OnEstaCerca += respuestaGrupo1;
        notificador.OnEstaLejos += respuestaGrupo2;
        componenteRigitBody = GetComponent<Rigidbody>();
        posicionInicial = transform.position;
    }

    void respuestaGrupo1() {
        // la separacion es para que los personajes no choquen entre ellos.
        Vector3 posicionCercana = escudoElegido.transform.position + separacionEntrePersonajes;
        // Pq el MovePosition es para movimientos progresivos osea tipo llegar a algun sitio
        // con esto cambiamos la posicion con el rigid.
        componenteRigitBody.position = posicionCercana;
    }
    void respuestaGrupo2() {
        componenteRigitBody.position = posicionInicial;
    }


}
