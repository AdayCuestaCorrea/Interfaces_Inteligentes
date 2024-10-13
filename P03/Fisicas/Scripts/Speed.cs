using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour {
  public float speed = 5f;
  private float verticalAxis;
  private float horizontalAxis;
  void Update() {
    horizontalAxis = Input.GetAxis("Horizontal");
    verticalAxis = Input.GetAxis("Vertical");
    if (Input.GetKeyDown(KeyCode.UpArrow)) {
      Debug.Log("Up Arrow: " + (speed * verticalAxis));
    }
    else if (Input.GetKeyDown(KeyCode.DownArrow)) {
      Debug.Log("Down Arrow: " + (speed * verticalAxis));
    }
    else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
      Debug.Log("Left Arrow: " + (speed * horizontalAxis));
    }
    else if (Input.GetKeyDown(KeyCode.RightArrow)) {
      Debug.Log("Right Arrow: " + (speed * horizontalAxis));
    }
  }
}
