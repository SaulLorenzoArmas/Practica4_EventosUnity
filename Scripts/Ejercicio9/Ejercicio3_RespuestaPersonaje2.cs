using UnityEngine;

public class Ejercicio3_RespuestaPersonaje2 : MonoBehaviour {
    public Ejercicio3_CuboNotificador notificador;
    public float velocidad;
    private GameObject escudoSeleccionado;
    private bool perseguir;
    private Rigidbody componenteRigidbody;

    void Start() {
        perseguir = false;
        notificador.OnEventoPersonaje2 += respuestaPersonaje2;
        componenteRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        if (perseguir) {
            Vector3 nuevaPosicion = Vector3.MoveTowards(transform.position, escudoSeleccionado.transform.position,  velocidad * Time.fixedDeltaTime); 
            componenteRigidbody.MovePosition(nuevaPosicion);
        }
    }

    void respuestaPersonaje2() {
        GameObject[] escudos = GameObject.FindGameObjectsWithTag("Escudo2");
        escudoSeleccionado = escudos[Random.Range(0, escudos.Length)];
        perseguir = true;
    }
    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Escudo2") || collision.gameObject.CompareTag("Escudo1")) {
            // Salta la cápsula padre -> entra al hijo -> entra a "Mesh"
            // Osea, entra al hijo del hijo del objeto con el que colisiona, que es el que tiene el MeshRenderer
            Renderer[] todosLosRenderers = collision.gameObject.GetComponentsInChildren<Renderer>();
            foreach (Renderer renderActual in todosLosRenderers) {
                renderActual.material.color = Color.red;
            }
            perseguir = false;
        }
    }
}