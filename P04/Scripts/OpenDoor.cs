using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour {
  private GameObject door;
  public float openAngle = 90f;
  public float openSpeed = 2f;
  private bool isOpen = false; 
  private bool isPlayerNearby = false;
  private Quaternion closedRotation; 
  private Quaternion openRotation;

  void Start() {
    door = this.gameObject;
    closedRotation = door.transform.rotation;
    openRotation = closedRotation * Quaternion.Euler(0, openAngle, 0);
  }

  void Update() {
    if (isPlayerNearby && Input.GetKeyDown(KeyCode.E)) {
      isOpen = !isOpen;
      if (isOpen) {
        DoorListener.DoorOpened();
      }
    }
    if (isOpen) {
      door.transform.rotation = Quaternion.Slerp(door.transform.rotation, openRotation, Time.deltaTime * openSpeed);
    } else {
      door.transform.rotation = Quaternion.Slerp(door.transform.rotation, closedRotation, Time.deltaTime * openSpeed);
    }
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