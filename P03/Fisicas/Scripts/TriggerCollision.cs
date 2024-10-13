using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCollision : MonoBehaviour {
  void OnTriggerEnter(UnityEngine.Collider other) {
    Debug.Log("El " + gameObject.name + " tuvo una Trigger collision con: " + other.gameObject.name);
  }
}
