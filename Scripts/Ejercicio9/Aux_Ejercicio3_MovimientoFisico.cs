using UnityEngine;

public class Aux_Ejercicio3_MovimientoFisico : MonoBehaviour{
     Rigidbody componenteRigidbody;
    public float velocidad; 

    void Start() {
        componenteRigidbody = GetComponent<Rigidbody>();
    } 

    void FixedUpdate() {
        Vector3 movimiento = new Vector3 ( Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical")); 
        componenteRigidbody.MovePosition(transform.position + movimiento * Time.fixedDeltaTime * velocidad);
    }
}
