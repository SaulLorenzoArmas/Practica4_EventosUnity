using UnityEngine;
// Para poder editar el texto
using TMPro;
using UnityEngine.Rendering.RenderGraphModule;
using Unity.VisualScripting;

public class Ejercicio5_6_7_8_ReaccionEscudosTipo1 : MonoBehaviour {
    public Datos_personaje jugador;
    public TextMeshProUGUI textoPuntuacion;
    private Renderer[] componentesRendered; 
    private CapsuleCollider componetesColiders;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        componentesRendered = GetComponentsInChildren<MeshRenderer>();
        componetesColiders = GetComponent<CapsuleCollider>();
    }
    void OnTriggerEnter(Collider other) {
        jugador.puntos += 25;
        textoPuntuacion.text = "Puntos: " + jugador.puntos;
        foreach(Renderer renderActual in componentesRendered){
            renderActual.enabled = false;
        }
        // Pq sino solo desaparece el objeto pero sigue colisionando con el jugador.
        componetesColiders.enabled = false;
        // Esto desactiva por completo.
        //gameObject.SetActive(false);
    }
}
