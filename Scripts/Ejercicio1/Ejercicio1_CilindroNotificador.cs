using UnityEngine;

public class Ejercicio1_CilindroNotificador : MonoBehaviour{
  public  delegate void mensaje();
  public event mensaje OnAlcanzadoPorCubo;
  void OnTriggerEnter(Collider other) {
    OnAlcanzadoPorCubo();
  }
}
