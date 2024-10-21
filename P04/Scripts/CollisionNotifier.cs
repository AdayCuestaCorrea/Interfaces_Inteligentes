using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionNotifier : MonoBehaviour {
  public delegate void CylinderCollisionHandler();
  public static event CylinderCollisionHandler OnCylinderCollision;
  void OnCollisionEnter(UnityEngine.Collision collision) {
    if (collision.gameObject.tag == "Cube") {
      Debug.Log("Cube collided with cylinder");
      OnCylinderCollision();
    }
  }
}