using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveAutomaticMovement : MonoBehaviour {
  private GameObject sphere;
  private Vector3 spherePosition;
  public float speed = 1.0f;
  public KeyCode toggleKey = KeyCode.H;
  private bool isMoving = false;
  private Rigidbody rb;
  void Start() {
    sphere = GameObject.Find("Sphere");
    rb = GetComponent<Rigidbody>(); // Obtener el componente Rigidbody
  }
  void Update() {
    // Verificar si se presiona la tecla 'H'
    if (Input.GetKeyDown(toggleKey)) {
      isMoving = !isMoving; // Alternar el estado de movimiento
    }
  }
  void FixedUpdate() {
    // Ejecutar el movimiento solo si isMoving es verdadero
    if (isMoving) {
      spherePosition = sphere.transform.position;
      Vector3 direction = (spherePosition - transform.position).normalized;
      rb.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
      Vector3 lookAtPosition = new Vector3(spherePosition.x, transform.position.y, spherePosition.z);
      transform.LookAt(lookAtPosition);
    }
  }
}
