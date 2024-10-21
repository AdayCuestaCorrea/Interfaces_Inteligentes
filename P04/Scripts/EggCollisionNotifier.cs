using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggCollisionNotifier : MonoBehaviour {
  public delegate void SpiderType1CollisionHandler(GameObject egg);
  public static event SpiderType1CollisionHandler OnSpiderType1Collision;
  public delegate void SpiderType2CollisionHandler(GameObject egg);
  public static event SpiderType2CollisionHandler OnSpiderType2Collision;
  void OnCollisionEnter(UnityEngine.Collision collision) {
    if (collision.gameObject.CompareTag("Type1")) {
      OnSpiderType1Collision?.Invoke(gameObject);
    }
    else if (collision.gameObject.CompareTag("Type2")) {
      OnSpiderType2Collision?.Invoke(gameObject);
    }
    Destroy(gameObject);
  }
}