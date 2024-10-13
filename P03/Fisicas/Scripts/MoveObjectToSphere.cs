using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectToSphere : MonoBehaviour {
  private GameObject sphere;
  private Vector3 spherePosition;
  public float speed = 1.0f;
  void Start() { // Cambiado a 'Start' con mayúscula
    sphere = GameObject.Find("Sphere");
  }
  void Update() {
    spherePosition = sphere.transform.position;
    Vector3 direction = (spherePosition - transform.position).normalized;
    direction.y = 0; // Mantener la componente Y en cero
    transform.Translate(direction * speed * Time.deltaTime);
  }
}
