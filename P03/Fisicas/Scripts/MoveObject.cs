using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour {
  public KeyCode upKey = KeyCode.UpArrow;
  public KeyCode downKey = KeyCode.DownArrow;
  public KeyCode leftKey = KeyCode.LeftArrow;
  public KeyCode rightKey = KeyCode.RightArrow;
  public float speed = 1.0f;
  void Update() {
    if (Input.GetKey(upKey)) {
      transform.Translate(Vector3.forward * speed * Time.deltaTime);
    } else if (Input.GetKey(downKey)) {
      transform.Translate(Vector3.back * speed * Time.deltaTime);
    } else if (Input.GetKey(leftKey)) {
      transform.Translate(Vector3.left * speed * Time.deltaTime);
    } else if (Input.GetKey(rightKey)) {
      transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
  }
}
