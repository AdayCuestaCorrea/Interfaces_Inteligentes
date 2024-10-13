using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour {
  public float speed = 5.0f;
  public float rotationSpeed = 100.0f;

  void Update() {
    float horizontalInput = Input.GetAxis("Horizontal");
    transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
    transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
  }
}
