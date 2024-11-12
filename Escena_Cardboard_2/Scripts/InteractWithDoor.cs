using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithDoor : MonoBehaviour {
  private GameObject door;
  public float openAngle = 90f;
  public float openSpeed = 2f;
  private bool isOpen = false; 
  private bool isPlayerNearby = false;
  private bool lookingAtDoor = false;
  private bool isAnimating = false;
  private Quaternion closedRotation; 
  private Quaternion openRotation;

  void Start() {
    door = this.gameObject;
    closedRotation = door.transform.rotation;
    openRotation = closedRotation * Quaternion.Euler(0, openAngle, 0);
  }

  void Update() {
    if (isPlayerNearby && lookingAtDoor && !isAnimating) {
      isOpen = !isOpen;
      isAnimating = true;
    }

    if (isOpen) {
      door.transform.rotation = Quaternion.Slerp(door.transform.rotation, openRotation, Time.deltaTime * openSpeed);
      if (Quaternion.Angle(door.transform.rotation, openRotation) < 0.1f) {
        door.transform.rotation = openRotation;
        isAnimating = false;
      }
    } else {
      door.transform.rotation = Quaternion.Slerp(door.transform.rotation, closedRotation, Time.deltaTime * openSpeed);
      if (Quaternion.Angle(door.transform.rotation, closedRotation) < 0.1f) {
        door.transform.rotation = closedRotation;
        isAnimating = false;
      }
    }
  }

  public void OnPointerEnter() {
    lookingAtDoor = true;
  }

  public void OnPointerExit() {
    lookingAtDoor = false;
  }

  void OnTriggerEnter(Collider other) {
    if (other.CompareTag("Player")) {
      isPlayerNearby = true;
    }
  }

  void OnTriggerExit(Collider other) {
    if (other.CompareTag("Player")) {
      isPlayerNearby = false;
    }
  }
}