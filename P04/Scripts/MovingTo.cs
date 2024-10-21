using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTo : MonoBehaviour {
  public delegate void MovingToEggType1Handler();
  public static event MovingToEggType1Handler OnMovingToEggType1;
  private GameObject egg;
  private Rigidbody rb;
  public float speed = 1.0f;
  public float detectionRadius = 1.0f; // Umbral de distancia para detectar la proximidad al huevo
  void Start() {
    egg = GameObject.FindGameObjectWithTag("Egg_Type1");
    rb = GetComponent<Rigidbody>();
  }
  void FixedUpdate() {
    if (egg != null) {
      float distance = Vector3.Distance(rb.transform.position, egg.transform.position);
      if (distance <= detectionRadius) {
        OnMovingToEggType1?.Invoke();
      }
    }
  }
}
