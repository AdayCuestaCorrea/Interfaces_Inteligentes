using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowScore : MonoBehaviour {
  [SerializeField] private TMP_Text scoreText;
  // Update is called once per frame
  void Update() {
    scoreText.text = $"Spider Type 1 Score: {SpiderScores.spiderType1Score}\nSpider Type 2 Score: {SpiderScores.spiderType2Score}";
  }
}