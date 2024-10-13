using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour {
  void OnCollisionEnter(UnityEngine.Collision collision) {
    Debug.Log("El " + gameObject.name + " colisionó con: " + collision.gameObject.name);
  }
}
