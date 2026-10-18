using UnityEngine;
using TMPro;
using UnityEngine.Rendering.RenderGraphModule;

public class Ejercicio5_6_7_8_ReaccionEscudosTipo2 : MonoBehaviour {
    public Datos_personaje jugador;
    public TextMeshProUGUI textoPuntuacion;
    private Renderer[] componentesRendered; 
    private CapsuleCollider componenteColider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        componentesRendered = GetComponentsInChildren<MeshRenderer>();
        componenteColider = GetComponent<CapsuleCollider>();
    }
    void OnTriggerEnter(Collider other) {
        jugador.puntos += 50; 
        textoPuntuacion.text = "Puntos: " + jugador.puntos;
        foreach(Renderer renderActual in componentesRendered){
            renderActual.enabled = false;
        }   
        // Pq sino solo desaparece el objeto pero sigue colisionando con el jugador.
        componenteColider.enabled = false;
        // Esto desactiva por completo.
        //gameObject.SetActive(false);

    }
}
