using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Ejercicio3_RespuestaPersonaje1 : MonoBehaviour {
    public Ejercicio3_CuboNotificador notificador;
    public GameObject escudoSeleccionado;
    public float velocidad;
    private bool perseguir;
    private Rigidbody componenteRigidbody; 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        perseguir = false;
        notificador.OnEventoPersonaje1 += respuestaPersonaje1;
        componenteRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (perseguir) {
            Vector3 nuevaPosicion = Vector3.MoveTowards(transform.position, escudoSeleccionado.transform.position,  velocidad * Time.fixedDeltaTime);
            componenteRigidbody.MovePosition(nuevaPosicion);
        }
    }
    void respuestaPersonaje1() {
        perseguir = true;
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Escudo1") || collision.gameObject.CompareTag("Escudo2")) {
            // Salta la cápsula padre -> entra al hijo -> entra a "Mesh"
            // Osea, entra al hijo del hijo del objeto con el que colisiona, que es el que tiene el MeshRenderer
            Renderer[] todosLosRenderers = collision.gameObject.GetComponentsInChildren<Renderer>();
            foreach (Renderer r in todosLosRenderers) {
                r.material.color = Color.red;
            }
            perseguir = false;
        }
    }
}
