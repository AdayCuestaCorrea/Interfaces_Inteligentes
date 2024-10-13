using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
  public Vector3 moveDirection = new Vector3(0, 0, 1);
  public float moveSpeed = 1.5f;
  void Update() {
    transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
  }
}
