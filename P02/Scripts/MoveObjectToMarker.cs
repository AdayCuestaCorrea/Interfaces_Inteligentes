using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectToMarker : MonoBehaviour {
  public GameObject marker;
  private Vector3[] markerPositions;
  private int indexPosition = 0;

    // Start is called before the first frame update
  void Start() {
    // Get the number of child objects
    int childCount = marker.transform.childCount;
    // Initialize the markerPositions array
    markerPositions = new Vector3[childCount];
    // Store the positions of the child objects
    for (int i = 0; i < childCount; i++) {
      markerPositions[i] = marker.transform.GetChild(i).position;
    }
  }

    // Update is called once per frame
  void Update() {
    // Check if the space key is pressed
    if (Input.GetKeyDown(KeyCode.Space)) {
      // Move the object to the current marker position
      transform.position = markerPositions[indexPosition];
      // Update the index to the next position
      indexPosition = (indexPosition + 1) % markerPositions.Length;
    }
  }
}
