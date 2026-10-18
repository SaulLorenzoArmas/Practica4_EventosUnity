using System.Globalization;
using UnityEngine;

public class Ejercicio4_RespuestaGrupo2 : MonoBehaviour
{
    public Ejercicio4_ObjetoReferenciaNotificador notificador;
    public GameObject objetElegido;
    private Rigidbody componenteRigitBody;
    private Vector3 rotacionInicial;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        notificador.OnEstaCerca += respuestaGrupo2;
        notificador.OnEstaLejos += respuestaGrupo1;
        componenteRigitBody = GetComponent<Rigidbody>();
        // Coge ese Quaternion y lo convierte en un Vector3
        rotacionInicial = transform.rotation.eulerAngles;
    }

    void respuestaGrupo2() {
        Vector3 aDondeVer = objetElegido.gameObject.transform.position - transform.position;
        // Esto calcula el angulo a donde, ya que moverotation necesita un quaternion.
        Quaternion anguloAver = Quaternion.LookRotation(aDondeVer);
        componenteRigitBody.MoveRotation(anguloAver);
    }

    void respuestaGrupo1() {
        // Coge ese Vector3 y lo convierte en un Quaternion
        Quaternion anguloAver = Quaternion.Euler(rotacionInicial);
        componenteRigitBody.MoveRotation(anguloAver);
    }
}
