using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderToSomething : MonoBehaviour
{
  public Transform moveToObject; // Reference to the object we have to move to
    public float speed = 4f; // Speed of the spider
    private Rigidbody rb;
    private Animator animator;
    private bool shouldMove = false;

    void Start() {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void OnEnable() {
        PlayerScore.onScoreChanged += CheckScore;
    }

    void OnDisable() {
        PlayerScore.onScoreChanged -= CheckScore;
    }

    void CheckScore(int score) {
        if (score >= 100) {
            shouldMove = true;
        }
    }

    void FixedUpdate() {
        if (shouldMove && moveToObject != null) {
            Vector3 moveToObjectPosition = moveToObject.position;
            Vector3 direction = (moveToObjectPosition - transform.position).normalized;
            direction.y = 0;
            rb.MovePosition(transform.position + direction * speed * Time.deltaTime);
            animator.SetBool("IsRunning", true);
        } else {
            rb.velocity = Vector3.zero;
            animator.SetBool("IsRunning", false);
        }
    }
}
