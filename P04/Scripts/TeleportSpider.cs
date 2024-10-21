using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportSpider : MonoBehaviour {
  private GameObject egg;
  private Vector3 eggPosition;
  public float speed = 1.0f;
  private Rigidbody rb;
  public float teleportOffsetRange = 1.0f;

  private bool isTeleporting = false;
    // Start is called before the first frame update
  void Start() {
    egg = null;
    rb = GetComponent<Rigidbody>();
  }

  void OnEnable() {
    MovingTo.OnMovingToEggType1 += HandleTpToEggType1;
  }

  void OnDisable() {
    MovingTo.OnMovingToEggType1 -= HandleTpToEggType1;
  }

  void FixedUpdate() {
    if (egg != null && !isTeleporting) {
      isTeleporting = true;
      eggPosition = egg.transform.position;
      float randomOffsetX = Random.Range(-teleportOffsetRange, teleportOffsetRange);
      Vector3 newPosition = new Vector3(eggPosition.x + randomOffsetX, 3, eggPosition.z);
      rb.MovePosition(newPosition);
    }
  }

  void HandleTpToEggType1() {
    egg = GameObject.FindGameObjectWithTag("Egg_Type1");
  }
}
