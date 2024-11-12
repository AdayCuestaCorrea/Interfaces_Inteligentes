using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] public static int playerScore = 0;
    public int addScore = 25;
    public delegate void ScoreChanged(int newScore);
    public static event ScoreChanged onScoreChanged;

    void OnEnable() {
        PointingEgg.onPointingEgg += AddScoreAndDestroy;
    }

    void OnDisable() {
        PointingEgg.onPointingEgg -= AddScoreAndDestroy;
    }

    void AddScoreAndDestroy(GameObject egg) {
        playerScore += addScore;
        Debug.Log("Player Score = " + playerScore);
        egg.layer = 0; // Set the layer to default (0)
        egg.SetActive(false); // Set the egg to inactive
        onScoreChanged?.Invoke(playerScore); // Notify score change
    }
}