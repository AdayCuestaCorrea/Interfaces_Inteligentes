using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderType1 : MonoBehaviour {
  private GameObject egg;
  private Vector3 eggPosition;
  public float speed = 1.0f;
  private Rigidbody rb;
  private Animator animator;
  void Start() {
    egg = null;
    rb = GetComponent<Rigidbody>();
    animator = GetComponent<Animator>();
  }
  void OnEnable() {
    CubeNotifier.OnCollisionOne += MoveToEgg;
  }
  void OnDisable() {
    CubeNotifier.OnCollisionOne -= MoveToEgg;
  }
  void FixedUpdate() {
    if (egg != null) {
      eggPosition = egg.transform.position;
      Vector3 direction = (eggPosition - transform.position).normalized;
      direction.y = 0;
      rb.MovePosition(transform.position + direction * speed * Time.deltaTime);
      animator.SetBool("IsRunning", true);
    } else {
      rb.velocity = Vector3.zero;
      animator.SetBool("IsRunning", false);
    }
  }
  void MoveToEgg() {
    egg = GameObject.FindGameObjectWithTag("Egg_Type2");
  }
}
