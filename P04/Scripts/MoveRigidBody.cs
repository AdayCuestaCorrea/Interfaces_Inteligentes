using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRigidBody : MonoBehaviour {
  public KeyCode upKey = KeyCode.W;
  public KeyCode downKey = KeyCode.S;
  public KeyCode leftKey = KeyCode.A;
  public KeyCode rightKey = KeyCode.D;
  public float speed = 1.0f;
  private Rigidbody rb;
  void Start() {
    rb = GetComponent<Rigidbody>(); // Obtener el componente Rigidbody
  }
  void FixedUpdate() {
    Vector3 movement = Vector3.zero;
    if (Input.GetKey(upKey)) {
      movement += Vector3.forward;
    } 
    if (Input.GetKey(downKey)) {
      movement += Vector3.back;
    } 
    if (Input.GetKey(leftKey)) {
      movement += Vector3.left;
    } 
    if (Input.GetKey(rightKey)) {
      movement += Vector3.right;
    }
    rb.MovePosition(transform.position + movement * speed * Time.fixedDeltaTime);
  }
}
