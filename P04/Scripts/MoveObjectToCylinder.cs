using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectToCylinder : MonoBehaviour {
  private GameObject cylinder;
  private Vector3 cylinderPosition;
  public float speed = 1.0f;
  private Rigidbody rb;
  void Start() {
    // Inicialmente no hay esfera objetivo
    cylinder = null;
    rb = GetComponent<Rigidbody>();
  }
  void OnEnable() {
    CollisionNotifier.OnCylinderCollision += MoveToCylinder;
  }
  void OnDisable() {
    CollisionNotifier.OnCylinderCollision -= MoveToCylinder;
  }
  void FixedUpdate() {
    if (cylinder != null) {
      cylinderPosition = cylinder.transform.position;
      Vector3 direction = (cylinderPosition - transform.position).normalized;
      direction.y = 0; // Mantener la componente Y en cero
      rb.velocity = direction * speed;
    } else {
      rb.velocity = Vector3.zero;
    }
  }
  void MoveToCylinder() {
    // Encontrar todas las esferas de tipo 2
    cylinder = GameObject.FindGameObjectWithTag("Cylinder");
  }
}
