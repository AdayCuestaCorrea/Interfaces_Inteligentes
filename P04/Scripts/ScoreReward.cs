using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video; // Add this line to include the VideoPlayer namespace

public class ScoreReward : MonoBehaviour {
  [SerializeField] private VideoPlayer videoPlayer; // Reference to the VideoPlayer component
  private bool rewardDisplayed = false;

  void Start() {
    if (videoPlayer != null) {
      videoPlayer.enabled = false; // Disable the VideoPlayer initially
    }
  }

  void Update() {
    if (!rewardDisplayed && (SpiderScores.spiderType1Score >= 100 || SpiderScores.spiderType2Score >= 100)) {
      PlayRewardVideo();
      rewardDisplayed = true;
    }
  }

  private void PlayRewardVideo() {
    if (videoPlayer != null) {
      videoPlayer.enabled = true; // Enable the VideoPlayer
      videoPlayer.Play();
    }
  }
}