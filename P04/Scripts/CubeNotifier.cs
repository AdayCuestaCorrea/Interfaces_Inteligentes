using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeNotifier : MonoBehaviour {
  public delegate void CubeCollisionHandler();
  public static event CubeCollisionHandler OnCollisionOne;
  public static event CubeCollisionHandler OnCollisionTwo;
  void OnCollisionEnter(UnityEngine.Collision collision) {
    if (collision.gameObject.tag == "Type1") {
      OnCollisionOne();
    } else if (collision.gameObject.tag == "Type2") {
      OnCollisionTwo();
    }
  }
}
