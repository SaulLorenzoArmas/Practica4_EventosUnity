using UnityEngine;
using TMPro;
public class Ejercicio5_6_7_8_juegoJugador : MonoBehaviour {
    public Datos_personaje jugador;
    public TextMeshProUGUI masaJugador;
    private Rigidbody comoponenteRigid;
    private float siguienteMeta;
    void Start() {
        siguienteMeta = 100;
        comoponenteRigid = GetComponent<Rigidbody>();    
    }
    void OnTriggerEnter(Collider other){
        Debug.Log("He chocado con " + other.gameObject.name);
        ComprobarRecompensa();
    }
    void ComprobarRecompensa() {
        while (jugador.puntos >= siguienteMeta) {
            comoponenteRigid.mass += 10f;
            // Osea con mas masa impulsa los objetos con mas fuerza
            masaJugador.text = "Masa: " + comoponenteRigid.mass;
            // Con esto se aumenta el tamaño al personaje. 
            transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
            siguienteMeta += 100;
        }
    }
}
