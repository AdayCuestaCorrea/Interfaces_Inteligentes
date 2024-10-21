using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpiders : MonoBehaviour {
  public float speed = 3.0f;
  private Transform player; 
  private Animator animator;
  private Rigidbody rb; 
  private bool isFollowing = false; 

  void Start() {
    player = GameObject.FindGameObjectWithTag("Player").transform;
    animator = GetComponent<Animator>();
    rb = GetComponent<Rigidbody>();
  }
  void FixedUpdate() {
    if (isFollowing) {
      Vector3 direction = (player.position - transform.position).normalized;
      Vector3 newPosition = transform.position + direction * speed * Time.deltaTime;
      rb.MovePosition(newPosition);
      animator.SetBool("IsRunning", true);
    }
  }
  void OnCollisionEnter(UnityEngine.Collision collision) {
    if (collision.gameObject.CompareTag("Player")) {
      animator.SetTrigger("Attack");
    }
  }
  void OnEnable() {
    DoorListener.OnDoorOpened += StartFollowing;
  }
  void OnDisable() {
    DoorListener.OnDoorOpened -= StartFollowing;
  }
  void StartFollowing() {
    isFollowing = true;
  }
}