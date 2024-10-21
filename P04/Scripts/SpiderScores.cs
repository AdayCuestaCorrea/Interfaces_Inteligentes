using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderScores : MonoBehaviour {
  [SerializeField] public static int spiderType1Score = 0;
  [SerializeField] public static int spiderType2Score = 0;
  public int SpiderType1Points = 5;
  public int SpiderType2Points = 10;
  void OnEnable() {
    EggCollisionNotifier.OnSpiderType1Collision += HandleSpiderType1Collision;
    EggCollisionNotifier.OnSpiderType2Collision += HandleSpiderType2Collision;
  }
  void OnDisable() {
    EggCollisionNotifier.OnSpiderType1Collision -= HandleSpiderType1Collision;
    EggCollisionNotifier.OnSpiderType2Collision -= HandleSpiderType2Collision;
  }
  void HandleSpiderType1Collision(GameObject egg) {
    spiderType1Score += SpiderType1Points;
    Debug.Log("Spider Type 1 Score: " + spiderType1Score);
  }
  void HandleSpiderType2Collision(GameObject egg) {
    spiderType2Score += SpiderType2Points;
    Debug.Log("Spider Type 2 Score: " + spiderType2Score);
  }
}
