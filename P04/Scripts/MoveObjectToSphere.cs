using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectToSphere : MonoBehaviour {
  private GameObject targetSphere;
  private Vector3 targetSpherePosition;
  public float speed = 1.0f;
  private Rigidbody rb;
  void Start() {
    // Inicialmente no hay esfera objetivo
    targetSphere = null;
    rb = GetComponent<Rigidbody>();
  }
  void OnEnable() {
    CollisionNotifier.OnCylinderCollision += MoveToSphereType2;
  }
  void OnDisable() {
    CollisionNotifier.OnCylinderCollision -= MoveToSphereType2;
  }
  void FixedUpdate() {
    if (targetSphere != null) {
      targetSpherePosition = targetSphere.transform.position;
      Vector3 direction = (targetSpherePosition - transform.position).normalized;
      direction.y = 0; // Mantener la componente Y en cero
      rb.velocity = direction * speed;
    } else {
      rb.velocity = Vector3.zero; // Detener el movimiento si no hay objetivo
    }
  }
  void MoveToSphereType2() {
      // Encontrar todas las esferas de tipo 2
      GameObject[] spheres = GameObject.FindGameObjectsWithTag("Type2");
      // Encontrar la esfera más cercana
      float minDistance = float.MaxValue;
      foreach (GameObject sphere in spheres) {
        float distance = Vector3.Distance(transform.position, sphere.transform.position);
        if (distance < minDistance) {
          minDistance = distance;
          targetSphere = sphere;
        }
      }
  }
}
